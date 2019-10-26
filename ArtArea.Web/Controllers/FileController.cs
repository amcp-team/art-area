using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ArtArea.Web.Models;
using ArtArea.Web.Models.DataServices;
using ArtArea.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ArtArea.Web.Controllers
{
   [Route("api/[controller]")]
    public class FileController : ControllerBase
    { 
        // private IFileDataService fileDataService;
        private ICommentDataService commentDataService;//???
        public FileController(ICommentDataService commentDataService)
        {
            this.commentDataService=commentDataService;
        //     this.fileDataService=fileDataService;
        }

        [HttpPost]
        [Route("{id}/comment")]
        public void PostComment(string id,[FromBody]CommentViewModel comment)
        {
            var rawComment = new Comment
            {
                Name = comment.name,
                Text = comment.text,
                FileId = id,
                PublicationDate = DateTime.Now
            };

            commentDataService.AddComment(rawComment);

            // comment.date = DateTime.Now.ToString();
            // DataStorage.Comments.Add(comment);
        }
    
        [HttpGet]
        [Route("{id}/comments")]
        public List<CommentViewModel> GetComments(string id)
        {
            //return DataStorage.Comments
            //    .Where(x => x.fileId == id)
            //    .OrderByDescending(x => DateTime.Parse(x.date))
            //    .ToList();
             var res = commentDataService.GetFileComments(id).Result;

            return res.Select(x => new CommentViewModel
            {
                fileId = x.Id,
                name = x.Name,
                text = x.Text,
                date = x.PublicationDate.ToString()
            })
                .OrderByDescending(x => DateTime.Parse(x.date))
                .ToList();


            // new List<Comment>(new [] {
            //     new Comment
            //     {
            //         Text = "Comment 1",
            //         PublicationDate = DateTime.Now,
            //     },
            //     new Comment
            //     {
            //         Text = "Comment 2",
            //         PublicationDate = DateTime.Now,
            //     },
            //     new Comment
            //     {
            //         Text = "Comment 3",
            //         PublicationDate = DateTime.Now,
            //     },
            // });
        }

        [HttpGet]
        [Route("{id}/thumbdata")]
        public FileViewModel GetThumbnail(string id)
            => DataStorage.UploadedFiles.First(x => x.Id == id);
    
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Download(string id)
        {
            // get stream from database
            var stream = new MemoryStream();
            using(var writer = new StreamWriter(stream, leaveOpen: true))
            {
                await writer.WriteLineAsync("Hrello!");
                await writer.FlushAsync();
                stream.Position = 0;
            }
            return File(stream, "text/plain", "trash.txt");
        }
     
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm]FileFormViewModel fileData)
        {
            var fileLength = (int)fileData.MyFile.Length;
            if(fileLength == 0)return Ok();
    
            var stream = new MemoryStream(fileLength);
            await fileData.MyFile.CopyToAsync(stream);
            stream.Position=0;
    
            var newBytes = new byte[fileLength];
            using(var reader = new StreamReader(stream))
            {
                stream.Read(newBytes, 0, fileLength);
            }
            DataStorage.UploadedFiles.Add(new FileViewModel{
                    Base64 = Convert.ToBase64String(newBytes),
                    Id = Guid.NewGuid().ToString(),
                    FileType = fileData.MyFile.ContentType,
                    Name = fileData.MyFile.Name
                });
    
            return Ok();
        }
    }
}