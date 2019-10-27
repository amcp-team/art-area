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
        
        // done & works
        [HttpGet("{id}")]
        public TaskViewModel GetTask(string id)
        {
            return DataStorage.Issues.Where(x => x.Id == id)
            .Select(x => new TaskViewModel {
                Name = x.Name,
                Description = x.Description,
                Id = x.Id,
                Slides = DataStorage.UploadedFiles
                .Where(x => x.IssueId == id)
                .Select(x => new FileViewModel
                {
                    Name = x.Name,
                    Id = x.Id,
                    Base64 = x.Base64,
                    FileType = x.FileType
                }).ToList()
            }).First();
        }

        // done & works
        [HttpGet]
        [Route("{id}/comments")]
        public List<CommentViewModel> GetComments(string id)
        {
            var comments = new List<CommentViewModel>(); 

            DataStorage.UploadedFiles
                .Where(x => x.IssueId == id)
                .ToList()
                .ForEach(x => comments.AddRange(DataStorage.Comments.Where(y => y.fileId == x.Id)));

            return comments;
        }
    }
}
