 using System;
 using Microsoft.AspNetCore.Mvc;
 using System.Threading.Tasks;
 using System.Collections.Generic;
 using ArtArea.Web.Models;
using ArtArea.Web.ViewModels;
//get для issues
//post for new issue
namespace ArtArea.Web.Controllers
 {
     [Route("api/[controller]")]
     public class ProjectController:Controller
     {
         [HttpGet]
         public ProjectViewModel GetIssues()
         {
           if(DataStorage.Issues.Count == 0)
            DataStorage.Issues.AddRange(new Issue[]
            {
              new Issue{
                Name = "API Pirate",
                Description = "This is cool API Pirate",
                Id = "mockedIdLol",
              },
              new Issue{
                Name = "Art Area Logo",
                Description = "This is where we try to create logo for our service",
                Id = "someotherloldir",
              }
            });
           return new ProjectViewModel{ Issues = DataStorage.Issues};   
         }
        [HttpPost]
        public void PostIssues([FromBody]Issue issue)
        {
           DataStorage.Issues.Add(issue);
        }

    }



 }