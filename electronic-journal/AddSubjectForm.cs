using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace electronic_journal
{
    public partial class AddSubjectForm : Form
    {

        private string access_token;
        public AddSubjectForm(string access_token)
        {
            InitializeComponent();
            this.access_token = access_token;
        }
        
        private async void AddSubjectButton_Click(object sender, EventArgs e)
        {
            var requests = new Requests("http://127.0.0.1:8000");

            string name = SubjectNameTextBox.Text;
            string group_number = GroupNumberTextBox.Text;
            var user = await requests.GetMyProfile(access_token);
            int teacher = user.id;


            try
            {
                await requests.AddSubject(access_token, name, group_number, teacher);
                MessageBox.Show("Предмет добавлен");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Предмет не добавлен");
            }
        }
    }
}
