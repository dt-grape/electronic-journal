using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace electronic_journal
{
    internal class Requests
    {
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
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
