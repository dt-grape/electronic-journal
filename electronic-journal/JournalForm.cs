using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace electronic_journal
{
    public partial class JournalForm : Form
    {
        private string access_token;
        public Dictionary<int, Models.Subject> saved_subjects;

        public JournalForm(string access_token)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            this.access_token = access_token;
            saved_subjects = new Dictionary<int, Models.Subject>();
        }
        
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            var requests = new Requests("http://127.0.0.1:8000");

            try
            {
                requests.LogoutUser(access_token);

                AuthForm authForm = new AuthForm();
                authForm.Show();
                this.Close();
                saved_subjects.Clear();
            }
            catch (Exception exception)
            {
                Console.WriteLine("....");
                throw;
            }
        }

        private void OpenAddSubjectFormButton_Click(object sender, EventArgs e)
        {
            AddSubjectForm addSubjectForm = new AddSubjectForm(access_token);
            addSubjectForm.Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //закрыть приложение 
            Application.Exit();
        }
        
        private async void JournalForm_Load(object sender, EventArgs e)
        {
            var requests = new Requests("http://127.0.0.1:8000");

            try
            {   
                var user = await requests.GetMyProfile(access_token);
                var subjects = await requests.GetSubjects(access_token);

                var i = 0;

                foreach (var subject in subjects)
                {
                    saved_subjects[i++] = subject;
                    SubjectListBox.Items.Add($"{subject.name} {subject.group_number}");
                }

                label1.Text = $"Здравствуйте: {user.username}";

            }
            catch (Exception exception)
            {
                Console.WriteLine("....");
                throw;
            }
        }
        
        private async void SubjectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var requests = new Requests("http://127.0.0.1:8000");

            if (SubjectListBox.SelectedIndex != -1)
            {
                try
                {
                    var students = await requests.GetStudents(access_token, saved_subjects[SubjectListBox.SelectedIndex].id);
                    var dates = await requests.GetDates(access_token, saved_subjects[SubjectListBox.SelectedIndex].id);
                    
                    SubjectNameLabel.Text = saved_subjects[SubjectListBox.SelectedIndex].name;
                    GroupNameLabel.Text = saved_subjects[SubjectListBox.SelectedIndex].group_number;
                    
                    JournalDataGridView.Columns.Clear();
                    JournalDataGridView.Rows.Clear();

                    DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
                    nameColumn.HeaderText = "Имя и фамилия";
                    JournalDataGridView.Columns.Add(nameColumn);

                    foreach (var date in dates)
                    {
                        DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn();
                        dateColumn.HeaderText = date.date;
                        dateColumn.HeaderCell.Tag = date.id;
                        JournalDataGridView.Columns.Add(dateColumn);
                    }

                    foreach (var student in students)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{student.first_name} {student.last_name}" });
                        row.Cells[0].Tag = student.id;

                        foreach (var date in dates)
                        {
                            var marks = await requests.GetMarks(access_token, student.id, date.id);
                            var mark = marks.FirstOrDefault();

                            if (mark != null)
                            {
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = mark.mark, Tag = mark.id });
                            }
                            else
                            {
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                            }
                        }
                        JournalDataGridView.Rows.Add(row);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("....");
                    throw;
                }
            }
        }

        private async void UpdateListBox_Click(object sender, EventArgs e)
        {
            var requests = new Requests("http://127.0.0.1:8000");
            SubjectListBox.Items.Clear();

            try
            {
                var user = await requests.GetMyProfile(access_token);
                var subjects = await requests.GetSubjects(access_token);

                var i = 0;

                foreach (var subject in subjects)
                {
                    saved_subjects[i++] = subject;
                    SubjectListBox.Items.Add($"{subject.name} {subject.group_number}");
                }

                label1.Text = $"Здравствуйте: {user.username}";

            }
            catch (Exception exception)
            {
                Console.WriteLine("....");
                throw;
            }
        }


        private async void JournalDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var requests = new Requests("http://127.0.0.1:8000");
            string input_text = e.FormattedValue.ToString();

            try
            {
                if (e.ColumnIndex == 0)
                {
                    string cell_text = JournalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

                    if (!string.IsNullOrWhiteSpace(input_text) && input_text != cell_text)
                    {
                        string[] name_parts = input_text.Split(' ');

                        if (name_parts.Length >= 2)
                        {
                            string first_name = name_parts[0];
                            string last_name = name_parts[1];
                            
                            await requests.AddStudent(access_token, first_name, last_name, saved_subjects[SubjectListBox.SelectedIndex].id);
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(input_text) && !string.IsNullOrWhiteSpace(cell_text))
                    {
                        int studentId = (int)JournalDataGridView.Rows[e.RowIndex].Cells[0].Tag;
                        await requests.DeleteStudent(access_token, studentId);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(input_text))
                    {
                        if (JournalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != null)
                        {
                            var mark_id = (int)JournalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;

                            await requests.DeleteMark(access_token, mark_id);
                        }
                        return;
                    }
                    
                    if (JournalDataGridView.Rows[e.RowIndex].Cells[0] == null || JournalDataGridView.Columns[e.ColumnIndex].HeaderCell == null)
                    {
                        return;
                    }
                    
                    var student_id = (int)JournalDataGridView.Rows[e.RowIndex].Cells[0].Tag;
                    
                    var date_id = (int)JournalDataGridView.Columns[e.ColumnIndex].HeaderCell.Tag;

                    if (JournalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag == null)
                    {
                        var new_mark = await requests.AddMark(access_token, input_text, student_id, date_id);

                        JournalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = new_mark.id;
                    }
                    else
                    {
                        var mark_id = (int)JournalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;

                        await requests.EditMark(access_token, mark_id, input_text ,student_id, date_id);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        private async void AddDateButton_Click(object sender, EventArgs e)
        {
            var requests = new Requests("http://127.0.0.1:8000");

            string date = DateTextBox.Text;

            try
            {
                await requests.AddDate(access_token, date, saved_subjects[SubjectListBox.SelectedIndex].id);
                MessageBox.Show("Дата добавлена");
                DateTextBox.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Дата не добавлена");
            }
        }

        private void DateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            { 
                e.Handled = true;
            }
        }

        private void DateTextBox_Validating(object sender, CancelEventArgs e)
        {
            string input = DateTextBox.Text;
            if (!Regex.IsMatch(input, @"^\d{4}-\d{2}-\d{2}$"))
            {
                MessageBox.Show("Неверный формат даты. Используйте формат 'ГГГГ-ММ-ДД'.");
                e.Cancel = true;
            }
        }

        private void DateTextBox_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DateTextBox.Text))
            {
                try
                {
                    DateTime date = DateTime.Parse(DateTextBox.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Неверная дата.");
                    DateTextBox.Text = "";
                }
            }
        }

        private void CalculateAverageButton_Click_Click(object sender, EventArgs e)
        {
            CalculateAndAddAverageColumn();
        }

        private void CalculateAndAddAverageColumn()
        {
            if (JournalDataGridView.Rows.Count == 0 || JournalDataGridView.Columns.Count == 0)
            {
                // Проверка наличия данных для расчета
                MessageBox.Show("Нет данных для расчета.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем наличие столбца "Средний балл"
            if (JournalDataGridView.Columns["Средний балл"] == null)
            {
                // Если столбца нет, то добавляем его
                DataGridViewTextBoxColumn averageColumn = new DataGridViewTextBoxColumn();
                averageColumn.HeaderText = "Средний балл";
                averageColumn.Name = "Средний балл";  // Добавь эту строку, чтобы присвоить имя столбцу
                JournalDataGridView.Columns.Add(averageColumn);
            }

            // Проходим по каждой строке и рассчитываем среднее арифметическое
            for (int rowIndex = 0; rowIndex < JournalDataGridView.Rows.Count; rowIndex++)
            {
                double sum = 0;
                int count = 0;

                // Проходим по каждой ячейке в строке
                for (int colIndex = 1; colIndex < JournalDataGridView.Columns.Count; colIndex++)
                {
                    object cellValue = JournalDataGridView.Rows[rowIndex].Cells[colIndex].Value;

                    if (cellValue != null && cellValue.ToString().Trim().ToLower() != "н")
                    {
                        // Проверяем, что значение не равно "н"
                        if (double.TryParse(cellValue.ToString(), out double mark))
                        {
                            // Конвертируем значение в число и добавляем к сумме
                            sum += mark;
                            count++;
                        }
                    }
                }

                // Рассчитываем среднее арифметическое и добавляем в новый столбец
                double average = count > 0 ? sum / count : 0;
                JournalDataGridView.Rows[rowIndex].Cells["Средний балл"].Value = average.ToString("0.00");

                // Добавляем цветовую метку в зависимости от значения среднего балла
                Color cellColor = GetColorForAverage(average);
                JournalDataGridView.Rows[rowIndex].Cells["Средний балл"].Style.BackColor = cellColor;
            }
        }
        private Color GetColorForAverage(double average)
        {
            if (average > 4.6)
            {
                // Зеленый цвет для высоких оценок
                return Color.Green;
            }
            else if (average < 2.6)
            {
                // Красный цвет для низких оценок
                return Color.Red;
            }
            else
            {
                // Белый цвет для оценок в среднем диапазоне
                return Color.White;
            }
        }
    }
}
