using ArtArea.Desktop.Client.Models;
using ArtArea.Desktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ArtArea.Desktop.Client
{
    public class APIHandler
    {
        private HttpClient _client;
        private string _token;
        private string _username;

        public APIHandler()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:27018/api/");
        }

        public Task<bool> Login(string username, string password)
        {
            return Task.Run(() =>
            {
                var json = JsonConvert.SerializeObject(new { username = username, password = password });
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var responseTask = _client.PostAsync("login", data);
                responseTask.Wait();
                var response = responseTask.Result;

                if (!response.IsSuccessStatusCode)
                    return false;

                var contentReadingTask = response.Content.ReadAsStringAsync();
                contentReadingTask.Wait();
                var tokenJson = contentReadingTask.Result;

                var token = JsonConvert.DeserializeObject<LoginResponse>(tokenJson);

                _token = token.Token;
                _username = username;

                return true;
            });
        }

        public IEnumerable<ProjectModel> GetUserProjects()
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");

            var responeTask = _client.GetAsync("projects/" + _username);
            responeTask.Wait();

            var response = responeTask.Result;

            if (response.IsSuccessStatusCode)
            {
                var readResultTask = response.Content.ReadAsAsync<IEnumerable<ProjectModel>>();
                readResultTask.Wait();

                var result = readResultTask.Result;

                return result;
            }

            return null;
        }
    }
}
