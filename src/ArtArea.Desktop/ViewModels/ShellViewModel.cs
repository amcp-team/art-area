using ArtArea.Desktop.EventModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtArea.Desktop.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LoginEventModel>, IHandle<ProjectsEventModel>
    {
        private IEventAggregator _events;
        private SimpleContainer _container;
        public ShellViewModel(SimpleContainer container, IEventAggregator events)
        {
            _container = container;
            _events = events;
            _events.Subscribe(this);

            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LoginEventModel message)
            => ActivateItem(_container.GetInstance<LoginViewModel>());

        public void Handle(ProjectsEventModel message)
            => ActivateItem(_container.GetInstance<ProjectsViewModel>());
    }
}
