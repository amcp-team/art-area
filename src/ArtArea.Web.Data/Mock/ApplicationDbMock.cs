using System;
using System.Collections.Generic;
using System.Linq;
using ArtArea.Models;
using ArtArea.Models.Privacy;

namespace ArtArea.Web.Data.Mock
{
    public static class ApplicationDbMock
    {
        public static List<User> Users { get; set; } = new List<User>(
            new[]
            {
                new User
                {
                    Username = "hypnospinner",
                    Name = "Ilya Katun",
                    Password = "hspassword123",
                    Email = "hypnospinner@gmail.com"
                },
                new User
                {
                    Username = "SixDevelop",
                    Name = "Sergey Nesterov",
                    Password = "snpassword123",
                    Email = "flamingo221100@gmail.com"
                }
            }.AsEnumerable()
        );

        public static List<Project> Projects { get; set; } = new List<Project>
        (
            new[]
            {
                new Project
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Art Area Design",
                    ProjectCollaborators = new List<UserAccess>(new []
                    {
                        new UserAccess
                        {
                            Username = "hypnospinner",
                            Role = AccessRole.Admin
                        },
                        new UserAccess
                        {
                            Username = "SixDevelop",
                            Role = AccessRole.Designer
                        }
                    }.AsEnumerable())
                }
            }.AsEnumerable()
        );

        public static List<Board> Boards { get; set; } = new List<Board>
        (
            new [] 
            {
                new Board
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User Page UI/UX",
                    ProjectId = Projects[0].Id,
                    BoardCollaborators = new List<UserAccess>
                    (
                        new []
                        {
                            new UserAccess
                            {
                                Username = "hypnospinner",
                                Role = AccessRole.Admin
                            },
                            new UserAccess
                            {
                                Username = "SixDevelop",
                                Role = AccessRole.Designer
                            }
                        }
                    )
                },
                new Board
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Project Page UX/UI",
                    ProjectId = Projects[0].Id,
                    BoardCollaborators = new List<UserAccess>
                    (
                        new []
                        {
                            new UserAccess
                            {
                                Username = "hypnospinner",
                                Role = AccessRole.Admin
                            },
                            new UserAccess
                            {
                                Username = "SixDevelop",
                                Role = AccessRole.Designer
                            }
                        }
                    )
                }
            }.AsEnumerable()
        );
    }
}