using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using electronic_journal;
using Newtonsoft.Json;

namespace electronic_journal
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            var requests = new Requests("http://127.0.0.1:8000");

            string username = LoginTextBox.Text;
            string password = PasswordTextBox.Text;

            try
            {
                var token = await requests.AuthenticateUser(username, password);

                JournalForm mainForm = new JournalForm(token);
                mainForm.Show();
                this.Hide();
                //MessageBox.Show($"{token}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Авторизация не удалась. Попробуйте снова.");
            }
        }
    }
}
