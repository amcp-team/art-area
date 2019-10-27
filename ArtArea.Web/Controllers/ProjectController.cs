 using System;
 using Microsoft.AspNetCore.Mvc;
 using System.Threading.Tasks;
 using System.Collections.Generic;
 using ArtArea.Web.Models;
 //get для issues
 //post for new issue
 namespace ArtArea.Web.Controllers
 {
     [Route("api/[controller]")]
     public class ProjectController:Controller
     {
         [HttpGet]
         public List<Issue> GetIssues()
         {
           return  DataStorage.Issues;   
         }
        [HttpPost]
        public void PostIssues([FromBody]Issue issue)
        {
           DataStorage.Issues.Add(issue);
        }

    }



 }