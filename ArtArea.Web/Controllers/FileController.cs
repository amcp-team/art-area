using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        [HttpPost]
        [Route("{id}/comment")]
        public void PostComment(string id,[FromBody]CommentViewModel comment)
        {
            comment.date = DateTime.Now.ToString();
            DataStorage.Comments.Add(comment);
        }

        [HttpGet]
        [Route("{id}/comments")]
        public List<CommentViewModel> GetComments(string id)
        {
            return DataStorage.Comments
                .Where(x => x.fileId == id)
                .OrderByDescending(x => DateTime.Parse(x.date))
                .ToList();
        } 


        [HttpGet]
        [Route("{id}/thumbdata")]
        public FileViewModel GetThumbnail(string id)
            => DataStorage.UploadedFiles.First(x => x.Id == id);
    
        [HttpGet]
        [Route("{id}")]
        public IActionResult Download(string id)
        {
            // get stream from database
            var file = DataStorage.UploadedFiles
                .First(x => x.Id == id);

            var stream = new MemoryStream();
            using(var writer = new BinaryWriter(stream, Encoding.ASCII,leaveOpen: true))
            {
                writer.Write(Convert.FromBase64String(file.Base64));
                writer.Flush();
                stream.Position = 0;
            }

            return File(stream, file.FileType, file.Name);

        }
      
        [HttpPost("{issueId}")]
        public async Task<IActionResult> Upload(string issueId,[FromForm]FileFormViewModel fileData)
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
                    Name = fileData.MyFile.FileName,
                    IssueId = issueId
                });

            return Ok();
        }
    }
}