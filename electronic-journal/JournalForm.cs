using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using electronic_journal;
using Newtonsoft.Json;
using static electronic_journal.Requests;

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

        private async void LogoutButton_Click(object sender, EventArgs e)
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

        
        private async void SubjectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var requests = new Requests("http://127.0.0.1:8000");

            if (SubjectListBox.SelectedIndex != -1)
            {
                try
                {
                    var students = await requests.GetStudents(access_token, saved_subjects[SubjectListBox.SelectedIndex].id);


                    SubjectNameLabel.Text = saved_subjects[SubjectListBox.SelectedIndex].name;
                    GroupNameLabel.Text = saved_subjects[SubjectListBox.SelectedIndex].group_number;

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();

                    DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
                    nameColumn.HeaderText = "Имя и фамилия";
                    dataGridView1.Columns.Add(nameColumn);

                    foreach (var student in students)
                    {
                        DataGridViewRow row = new DataGridViewRow();

                        // Добавляем студентов в столбец с именем и фамилией
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{student.first_name} {student.last_name}" });

                        // Добавляем строку в DataGridView
                        dataGridView1.Rows.Add(row);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("....");
                    throw;
                }
            }
        }
    }
}
