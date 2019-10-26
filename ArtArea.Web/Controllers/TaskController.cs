using System;
using System.Collections.Generic;
using ArtArea.Web.Models;
using ArtArea.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ArtArea.Web.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        // private ITaskDataService taskDataService;
        // private ICommentDataService commentDataService;
        // public TaskController(ITaskDataService taskDataService,ICommentDataService commentDataService)
        // {
        //   this.taskDataService=taskDataService;
        //   this.commentDataService=commentDataService;
        // }
        // api/task/ -> return data realted to task
        [HttpGet]
         public TaskViewModel GetTask()
        {
            return new TaskViewModel{
                Name = "API Pirate",
                Description = "This pirate we got from API",
                Slides = new List<FileData>(new FileData[]
                {
                    new FileData{
                        Base64 = "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",
                    FileType = "image/png",
                    Name = "cat"
            }})};
        }

        // mock
        [HttpGet]
        [Route("comments")]
        public List<CommentViewModel> GetComments()
        {
            return new List<CommentViewModel>(new CommentViewModel[] {
                new CommentViewModel
                {
                    Text = "Comment 3",
                    Date = DateTime.Now.ToString("d"),
                    Name = "Andrew"
                },
                new CommentViewModel
                {
                    Text = "Comment 3",
                    Date = DateTime.Now.ToString("d"),
                    Name = "Ilya"
                },
                new CommentViewModel
                {
                    Text = "Comment 3",
                    Date = DateTime.Now.ToString("d"),
                    Name = "Ilya"
                },
            });
        }
    }
}
