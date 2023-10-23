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
using electronic_journal;

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

                label1.Text = ($"Здравствуйте: {user.username}");
            }
            catch (Exception exception)
            {
                Console.WriteLine("....");
                throw;
            }
        }
    }
}
