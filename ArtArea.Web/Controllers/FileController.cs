using System;
using System.Collections.Generic;
using ArtArea.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtArea.Web.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        [HttpGet]
        [Route("{id}/comments")]
        public List<Comment> GetComments(string id)
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