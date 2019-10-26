using System;
using System.Collections.Generic;
using System.Linq;
using ArtArea.Web.Controller;
using ArtArea.Web.Models;
using ArtArea.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ArtArea.Web.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
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
                Slides = DataStorage.UploadedFiles
                    .Select(x => new FileData
                    {
                        Name = "some name",
                        Base64 = Convert.ToBase64String(x)
                    }).ToList()
                };
        }

        // mock
        [HttpGet]
        [Route("comments")]
        public List<CommentViewModel> GetComments()
        {
            return DataStorage.Comments
                .Select(x => new CommentViewModel{
                    Text = x.Text,
                    Date = x.PublicationDate.ToString("d"),
                    Name = x.Name
                }).ToList();
                
            // return new List<CommentViewModel>(new CommentViewModel[] {
            //     new CommentViewModel
            //     {
            //         Text = "Comment 3",
            //         Date = DateTime.Now.ToString("d"),
            //         Name = "Andrew"
            //     },
            //     new CommentViewModel
            //     {
            //         Text = "Comment 3",
            //         Date = DateTime.Now.ToString("d"),
            //         Name = "Ilya"
            //     },
            //     new CommentViewModel
            //     {
            //         Text = "Comment 3",
            //         Date = DateTime.Now.ToString("d"),
            //         Name = "Ilya"
            //     },
            // });
        }
    }
}
