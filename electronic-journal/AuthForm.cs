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

        public class Token
        {
            public string Auth_Token { get; set; }
        }

        private string authToken;

        public async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "http://127.0.0.1:8000/api/auth/token/login/";

                var requestData = new
                {
                    username = username,
                    password = password
                };
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    //byte[] tokenBytes = await response.Content.ReadAsByteArrayAsync();
                    //authToken = Encoding.UTF8.GetString(tokenBytes);

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Token tokenResponse = JsonConvert.DeserializeObject<Token>(jsonResponse);

                    authToken = tokenResponse.Auth_Token;

                    return true;
                }
                else
                {
                    return false;
                }
            }
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


            bool isAuthenticated = await AuthenticateUserAsync(username, password);


            if (isAuthenticated)
            {
                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Hide();
                MessageBox.Show($"{authToken}");
            }
            else
            {
                MessageBox.Show("Авторизация не удалась. Попробуйте снова.");
            }
        }
    }
}
