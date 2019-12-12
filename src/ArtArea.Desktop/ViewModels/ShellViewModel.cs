using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtArea.Desktop.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private LoginViewModel _loginViewModel;

        public ShellViewModel(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
            ActivateItem(_loginViewModel);
        }
    }
}
