using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace electronic_journal
{
    public partial class JournalForm : Form
    {
        private string access_token;
        Dictionary<int, Models.Subject> saved_subjects;

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
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = mark.mark });
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
            try
            {
                if (e.ColumnIndex == 0)
                {
                    string input_text = e.FormattedValue.ToString();
                    string cell_text = JournalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

                    if (!string.IsNullOrWhiteSpace(input_text) && input_text != cell_text)
                    {
                        string[] name_parts = input_text.Split(' ');

                        if (name_parts.Length >= 2)
                        {
                            string first_name = name_parts[0];
                            string last_name = name_parts[1];

                            var requests = new Requests("http://127.0.0.1:8000");
                            await requests.AddStudent(access_token, first_name, last_name, saved_subjects[SubjectListBox.SelectedIndex].id);
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(input_text) && !string.IsNullOrWhiteSpace(cell_text))
                    {
                        int studentId = (int)JournalDataGridView.Rows[e.RowIndex].Cells[0].Tag;
                        var requests = new Requests("http://127.0.0.1:8000");
                        await requests.DeleteStudent(access_token, studentId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}
