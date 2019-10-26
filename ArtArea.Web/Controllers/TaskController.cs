using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ArtArea.Web 
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        // api/task/ -> return data realted to task
        [HttpGet]
        public Task GetTask()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("comments")]
        public List<Comments> GetComments()
        {
            throw new NotImplementedException();
        }
    }
}
