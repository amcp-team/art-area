using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
    interface ITaskDataService
    {
        IEnumerable<Task> GetTasks();
        public Task GetTask(string id);
        public void AddTask(Task task);
        //public void DeleteTask(string id);
        //public void UpdateTask(Task task);
    }
}
