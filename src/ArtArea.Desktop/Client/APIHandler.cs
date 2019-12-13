using ArtArea.Desktop.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArtArea.Desktop.Client
{
    public class APIHandler
    {
        private HttpClient _client;
        private string _token;
        
        public APIHandler()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5001/api/");
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

                return true;
            });
        }
    }
}
