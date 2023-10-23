using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace electronic_journal
{
    internal class Requests
    {
        private string base_url;
        public Requests(string url)
        {
            base_url = url;
        }

        public class User
        {
            public string email { get; set; }
            public int id { get; set; }
            public string username { get; set; }
        }

        public class Token
        {
            public string Auth_Token { get; set; }
        }

        public async Task<User> GetMyProfile(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Token {token}");
                string apiUrl = $"{base_url}/api/auth/users/me/";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    //byte[] tokenBytes = await response.Content.ReadAsByteArrayAsync();
                    //authToken = Encoding.UTF8.GetString(tokenBytes);

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<User>(jsonResponse);
                }

                throw new Exception("...");
            }
        }

        public async Task<string> AuthenticateUser(string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{base_url}/api/auth/token/login/";

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

                    return tokenResponse.Auth_Token;
                }

                throw new Exception("Not auth...");
            }
        }
    }
}
