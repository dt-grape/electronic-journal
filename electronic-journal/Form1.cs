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
    public partial class Form1 : Form
    {
        private string access_token;

        public Form1(string access_token)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            this.access_token = access_token;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var requests = new Requests("http://127.0.0.1:8000");

            try
            {
                var user = await requests.GetMyProfile(access_token);
                var subjects = await requests.GetSubjects(access_token);

                foreach (var subject in subjects)
                {
                    SubjectListBox.Items.Add(subject.name);
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
            }
            catch (Exception exception)
            {
                Console.WriteLine("....");
                throw;
            }
        }
    }
}
