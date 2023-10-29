using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using static electronic_journal.Models;

namespace electronic_journal
{
    internal class Requests
    {
        private string base_url;
        public Requests(string url)
        {
            base_url = url;
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

        public async Task<string> LogoutUser(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Token {token}");
                string apiUrl = $"{base_url}/api/auth/token/logout/";

                HttpResponseMessage response = await client.PostAsync(apiUrl, null);

                if (response.IsSuccessStatusCode)
                {
                    return "Logout success";
                }

                throw new Exception("Not logout...");
            }
        }
        

        public async Task<string> AddSubject(string token, string name, string group_number, int teacher)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Token {token}");
                string apiUrl = $"{base_url}/api/subjects/";

                var requestData = new
                {
                    name = name,
                    group_number = group_number,
                    teacher = teacher
                };
                string jsonRequest = JsonConvert.SerializeObject(requestData);

                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return "Subject added";
                }

                throw new Exception("Not added...");
            }
        }

        public async Task<List<Subject>> GetSubjects(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Token {token}");
                string apiUrl = $"{base_url}/api/subjects/my/";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                    return JsonConvert.DeserializeObject<List<Subject>>(jsonResponse);
                }

                throw new Exception("...");
            }
        }

        public async Task<List<Student>> GetStudents(string token, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Token {token}");
                string apiUrl = $"{base_url}/api/students/by_subject/?id={id}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                    return JsonConvert.DeserializeObject<List<Student>>(jsonResponse);
                }
                throw new Exception("...");
            }
        }

        public async Task<List<Date>> GetDates(string token, int id)
        {
            using (HttpClient client = new HttpClient()) 
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Token {token}");
                string apiUrl = $"{base_url}/api/dates/by_subject/?id={id}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                    return JsonConvert.DeserializeObject<List<Date>>(jsonResponse);
                }

                throw new Exception("...");
            }
        }
        
        public async Task<List<Mark>> GetMarks(string token, int studentId, int dateId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Token {token}");
                string apiUrl = $"{base_url}/api/marks/by_student/?student_id={studentId}&date_id={dateId}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                    return JsonConvert.DeserializeObject<List<Mark>>(jsonResponse);
                }
                throw new Exception("...");
            }
        }
    }
}
