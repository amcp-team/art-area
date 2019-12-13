using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ArtArea.Desktop.Client;
using ArtArea.Desktop.EventModels;

namespace ArtArea.Desktop.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        private string _password;
        private APIHandler _client;
        private IEventAggregator _events;

        public LoginViewModel(APIHandler client, IEventAggregator events)
        {
            _client = client;
            _events = events;
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public bool CanLogin => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

        public async Task Login()
        {
            var success = await _client.Login(_username, _password);

            if(success)
            {
                // navigate to another view model
                _events.PublishOnUIThread(new ProjectsEventModel());
            }
        }
    }
}
