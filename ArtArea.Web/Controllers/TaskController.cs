using System;
using System.Collections.Generic;
using System.Linq;
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
         public TaskViewModel GetTask(
            //  string id
             )
        {
        //    return DataStorage.Tasks.First(x =>x.Id==id);
           
           
            return new TaskViewModel{
                Name = "API Pirate",
                Description = "This pirate we got from API",
                Slides = DataStorage.UploadedFiles
                    .Select(x => new FileViewModel
                    {
                        Name = x.Name,
                        Id = x.Id,
                        Base64 = x.Base64,
                        FileType = x.FileType
                    }).ToList()
                };
        }

        // mock
        [HttpGet]
        [Route("comments")]
        public List<CommentViewModel> GetComments()
        {
            return DataStorage.Comments.OrderByDescending(x=>x.date).ToList();

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
