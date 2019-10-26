using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtArea.Web 
{
    public class TaskController : Controller
    {
        [HttpGet]
        public IActionResult GetTaskComments()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult GetTaskComments(File file)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public IActionResult GetFileComments()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult GetFileComments(File file)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Upload()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Download()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Task()
        {
            throw new NotImplementedException();
        }

    }






}
