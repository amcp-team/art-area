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
                },
                new User
                {
                    Username ="AndyS1mpson",
                    Name = "Andrey Ageev",
                    Password = "aspassword123",
                    Email = "andysimpson@gmail.com"
                }
            }.AsEnumerable()
        );
        public static List<Project> Projects { get; set; } = new List<Project>
        (
            new[]
            {
                new Project
                {
                    Id = "hypnospinner.art-area-design",
                    Title = "Art Area Design",
                    Description = "UI/UX design for Art Area service for artists & designer",
                    IsPrivate = false,
                    HostUsername = "hypnospinner",
                    Collaborators = new List<UserAccess>(new []
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
                    }.AsEnumerable()),
                    Tags = new List<Tag>(new []
                    {
                        new Tag
                        {
                            Name = "important",
                            ColorHex = "#7bfc03",
                            Description = "For important task"
                        },
                        new Tag
                        {
                            Name = "urgent",
                            ColorHex = "#7bfc03",
                            Description = "Should be done as soon as possible"
                        }
                    }.AsEnumerable())
                },
                new Project
                {
                    Id = "AndyS1mpson.game",
                    Title = "Game",
                    Description = "Concept art & models for our brand-new computer game",
                    IsPrivate = true,
                    HostUsername = "AndyS1mpson",
                    Collaborators = new List<UserAccess>(new []
                    {
                        new UserAccess
                        {
                            Username = "AndyS1mpson",
                            Role = AccessRole.Admin
                        },
                        new UserAccess
                        {
                            Username = "SixDevelop",
                            Role = AccessRole.Designer
                        }
                    }.AsEnumerable()),
                    Tags = new List<Tag>(new []
                    {
                        new Tag
                        {
                            Name = "important",
                            ColorHex = "#7bfc03",
                            Description = "For important task"
                        }
                    }.AsEnumerable())
                }
            }.AsEnumerable()
        );
        public static List<Board> Boards { get; set; } = new List<Board>
        (
            new[]
            {
                new Board {
                    Id = Projects[0].Id + ".1",
                    Number = 1,
                    Title = "User Page UI",
                    ProjectId = Projects[0].Id,
                    Task = null,
                    Privacy = BoardPrivacy.Public,
                    Collaborators = new List<UserAccess>(new []
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
                    }.AsEnumerable()),
                    Description = "UI for individual user page",
                    PinGroups = null
                },
                new Board {
                    Id = Projects[0].Id + ".2",
                    Number = 2,
                    Title = "Project Page UI",
                    ProjectId = Projects[0].Id,
                    Task = null,
                    Privacy = BoardPrivacy.Public,
                    Collaborators = new List<UserAccess>(new []
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
                    }.AsEnumerable()),
                    Description = "UI for individual user page",
                    PinGroups = null
                },
                new Board {
                    Id = Projects[1].Id + ".1",
                    Number = 1,
                    Title = "Pirate Black Beard Consept",
                    ProjectId = Projects[1].Id,
                    Task = null,
                    Privacy = BoardPrivacy.Public,
                    Collaborators = new List<UserAccess>(new []
                    {
                        new UserAccess
                        {
                            Username = "AndyS1mpson",
                            Role = AccessRole.Admin
                        },
                        new UserAccess
                        {
                            Username = "SixDevelop",
                            Role = AccessRole.Designer
                        }
                    }.AsEnumerable()),
                    Description = "UI for individual user page",
                    PinGroups = null
                },
            }.AsEnumerable()
        );
        public static void Initialize()
        {
            Users = new List<User>(
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
                    },
                    new User
                    {
                        Username ="AndyS1mpson",
                        Name = "Andrey Ageev",
                        Password = "aspassword123",
                        Email = "andysimpson@gmail.com"
                    }
                }.AsEnumerable()
            );

            Projects = new List<Project>(
                new[]
                {
                    new Project
                    {
                        Id = "hypnospinner.art-area-design",
                        Title = "Art Area Design",
                        Description = "UI/UX design for Art Area service for artists & designer",
                        IsPrivate = false,
                        Collaborators = new List<UserAccess>(new []
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
                        }.AsEnumerable()),
                        Tags = new List<Tag>(new []
                        {
                            new Tag
                            {
                                Name = "important",
                                ColorHex = "#7bfc03",
                                Description = "For important task"
                            },
                            new Tag
                            {
                                Name = "urgent",
                                ColorHex = "#7bfc03",
                                Description = "Should be done as soon as possible"
                            }
                        }.AsEnumerable())
                    },
                    new Project
                    {
                        Id = "AndyS1mpson.game",
                        Title = "Game",
                        Description = "Concept art & models for our brand-new computer game",
                        IsPrivate = true,
                        Collaborators = new List<UserAccess>(new []
                        {
                            new UserAccess
                            {
                                Username = "AndyS1mpson",
                                Role = AccessRole.Admin
                            },
                            new UserAccess
                            {
                                Username = "SixDevelop",
                                Role = AccessRole.Designer
                            }
                        }.AsEnumerable()),
                        Tags = new List<Tag>(new []
                        {
                            new Tag
                            {
                                Name = "important",
                                ColorHex = "#7bfc03",
                                Description = "For important task"
                            }
                        }.AsEnumerable())
                    }
                }.AsEnumerable()
            );

            Boards = new List<Board>(
                new[]
                {
                    new Board {
                        Id = Projects[0].Id + ".1",
                        Number = 1,
                        Title = "User Page UI",
                        ProjectId = Projects[0].Id,
                        Task = null,
                        Privacy = BoardPrivacy.Public,
                        Collaborators = new List<UserAccess>(new []
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
                        }.AsEnumerable()),
                        Description = "UI for individual user page",
                        PinGroups = null
                    },
                    new Board {
                        Id = Projects[0].Id + ".2",
                        Number = 2,
                        Title = "Project Page UI",
                        ProjectId = Projects[0].Id,
                        Task = null,
                        Privacy = BoardPrivacy.Public,
                        Collaborators = new List<UserAccess>(new []
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
                        }.AsEnumerable()),
                        Description = "UI for individual user page",
                        PinGroups = null
                    },
                    new Board {
                        Id = Projects[1].Id + ".1",
                        Number = 1,
                        Title = "Pirate Black Beard Consept",
                        ProjectId = Projects[1].Id,
                        Task = null,
                        Privacy = BoardPrivacy.Public,
                        Collaborators = new List<UserAccess>(new []
                        {
                            new UserAccess
                            {
                                Username = "AndyS1mpson",
                                Role = AccessRole.Admin
                            },
                            new UserAccess
                            {
                                Username = "SixDevelop",
                                Role = AccessRole.Designer
                            }
                        }.AsEnumerable()),
                        Description = "UI for individual user page",
                        PinGroups = null
                    },
                }.AsEnumerable()
            );

        }
    }
}