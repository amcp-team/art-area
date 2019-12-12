using ArtArea.Desktop.Helpers;
using ArtArea.Desktop.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ArtArea.Desktop
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        private bool _databaseConfigured = false;
        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
        }
        protected override void Configure()
        {
            _container = _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            typeof(App).Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.Contains("ViewModel"))
                .ToList()
                .ForEach(viewModelType =>
                    _container.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));
        }

        #region DI Simple Container Utils

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
            => _container.GetAllInstances(service);

        protected override object GetInstance(Type service, string key)
            => _container.GetInstance(service, key);

        protected override void BuildUp(object instance)
            => _container.BuildUp(instance);

        #endregion
    }
}
