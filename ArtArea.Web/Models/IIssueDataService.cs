using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
    interface IIssueDataService
    {
        IEnumerable<Issue> GetTasks();
        public Issue GetTask(string id);
        public void AddTask(Issue task);
        //public void DeleteTask(string id);
        //public void UpdateTask(Task task);
    }
}
