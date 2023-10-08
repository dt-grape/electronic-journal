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

namespace electronic_journal
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        public async Task<bool> IsServerAvailable(string apiUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (HttpRequestException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //test
        private async void LoginButton_Click(object sender, EventArgs e)
        {
            bool isServerAvailable = await IsServerAvailable("http://127.0.0.1:8000/api/");
            if (!isServerAvailable)
            {
                MessageBox.Show("Не работает");
                return;
            }

            string username = LoginTextBox.Text;
            string password = PasswordTextBox.Text;

            Requests request = new Requests();

            bool isAuthenticated = await request.AuthenticateUserAsync(username, password);

            if (isAuthenticated)
            {
                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Авторизация не удалась. Попробуйте снова.");
            }
        }
    }
}
