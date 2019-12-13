using ArtArea.Desktop.Client;
using ArtArea.Desktop.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ArtArea.Desktop.ViewModels
{
    public class ProjectsViewModel : Screen
    {
        private APIHandler _api;

        public ProjectsViewModel(APIHandler api)
        {
            _api = api;
            _selected = null;

            // TODO get project from api
            var projects = _api.GetUserProjects();

            _projects = new BindingList<ProjectModel>();

            projects
                .ToList()
                .ForEach(x => _projects.Add(x));
        }

        private BindingList<ProjectModel> _projects;
        private ProjectModel _selected;

        public BindingList<ProjectModel> Projects
        {
            get { return _projects; }
            set
            {
                _projects = value;
                NotifyOfPropertyChange(() => Projects);
            }
        }

        public ProjectModel Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                NotifyOfPropertyChange(() => Selected);
            }
        }

    }
}
