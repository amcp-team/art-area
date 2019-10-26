using System;
using System.Collections.Generic;
using ArtArea.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtArea.Web.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private ITaskDataService taskDataService;
        private ICommentDataService commentDataService;
        public TaskController(ITaskDataService taskDataService,ICommentDataService commentDataService)
        {
          this.taskDataService=taskDataService;
          this.commentDataService=commentDataService;
        }
        // api/task/ -> return data realted to task
        [HttpGet]
         public Task GetTask()
        {
            throw new NotImplementedException();
        }

        // mock
        [HttpGet]
        [Route("comments")]
        public List<Comment> GetComments()
        {
            return new List<Comment>(new Comment[] {
                new Comment
                {
                    Text = "Comment 1",
                    PublicationDate = DateTime.Now,
                },
                new Comment
                {
                    Text = "Comment 2",
                    PublicationDate = DateTime.Now,
                },
                new Comment
                {
                    Text = "Comment 3",
                    PublicationDate = DateTime.Now,
                },
            });
        }
    }
}
