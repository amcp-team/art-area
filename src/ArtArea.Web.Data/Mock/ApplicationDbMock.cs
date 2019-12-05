using System;
using System.Collections.Generic;
using System.Linq;
using ArtArea.Models;
using ArtArea.Models.Privacy;
using MongoDB.Bson;

namespace ArtArea.Web.Data.Mock
{
    public static class ApplicationDbMock
    {
        public static List<Message> Messages { get; set; } = new List<Message>(
            new[]
            {
                new Message {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Author = "hypnospinner",
                    MarkdownText = "Comment from hypnospinner",
                    PublicationDate = new DateTime(2020, 1,1)
                },
                new Message {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Author = "hypnospinner",
                    MarkdownText = "Comment from hypnospinner",
                    PublicationDate = new DateTime(2020, 1,1)
                },
                new Message {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Author = "hypnospinner",
                    MarkdownText = "Comment from hypnospinner",
                    PublicationDate = new DateTime(2020, 1,1)
                },
                new Message {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Author = "hypnospinner",
                    MarkdownText = "Comment from hypnospinner",
                    PublicationDate = new DateTime(2020, 1,1)
                },
                new Message {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Author = "SixDevelop",
                    MarkdownText = "Comment from SixDevelop",
                    PublicationDate = new DateTime(2020, 1,1)
                },
                new Message {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Author = "SixDevelop",
                    MarkdownText = "Comment from SixDevelop",
                    PublicationDate = new DateTime(2020, 1,1)
                },
                new Message {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Author = "SixDevelop",
                    MarkdownText = "Comment from SixDevelop",
                    PublicationDate = new DateTime(2020, 1,1)
                },
                new Message {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Author = "AndyS1mpson",
                    MarkdownText = "Comment from AndyS1mpson",
                    PublicationDate = new DateTime(2020, 1,1)
                },
                new Message {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Author = "AndyS1mpson",
                    MarkdownText = "Comment from AndyS1mpson",
                    PublicationDate = new DateTime(2020, 1,1)
                },
                new Message {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Author = "AndyS1mpson",
                    MarkdownText = "Comment from AndyS1mpson",
                    PublicationDate = new DateTime(2020, 1,1)
                },
            }.AsEnumerable()
        );
        public static List<Pin> Pins { get; set; } = new List<Pin>(
            new[] {
                new Pin{
                    Id = ObjectId.GenerateNewId().ToString(),
                    Message = new Message {
                        Id = ObjectId.GenerateNewId().ToString(),
                        Author = "hypnospinner",
                        MarkdownText = "Message from hypnospinner",
                        PublicationDate = new DateTime(2019, 12, 4)
                    },
                    FileId = ObjectId.GenerateNewId().ToString(),
                    Thumbnail = ObjectId.GenerateNewId().ToString(),
                    Messages = new List<string>(
                        new[] {
                            Messages[1].Id,
                            Messages[2].Id,
                        }
                    )
                },
                new Pin{
                    Id = ObjectId.GenerateNewId().ToString(),
                    Message = new Message {
                        Id = ObjectId.GenerateNewId().ToString(),
                        Author = "SixDevelop",
                        MarkdownText = "Message from SixDevelop",
                        PublicationDate = new DateTime(2019, 12, 5)
                    },
                    FileId = ObjectId.GenerateNewId().ToString(),
                    Thumbnail = ObjectId.GenerateNewId().ToString(),
                    Messages = new List<string>()

                },
                new Pin{
                    Id = ObjectId.GenerateNewId().ToString(),
                    Message = new Message {
                        Id = ObjectId.GenerateNewId().ToString(),
                        Author = "hypnospinner",
                        MarkdownText = "Message from hypnospinner 1",
                        PublicationDate = new DateTime(2019, 11, 28)
                    },
                    FileId = ObjectId.GenerateNewId().ToString(),
                    Thumbnail = ObjectId.GenerateNewId().ToString(),
                    Messages = new List<string>(
                        new[] {
                            Messages[5].Id,
                            Messages[3].Id,
                        }
                    )
                },
                new Pin{
                    Id = ObjectId.GenerateNewId().ToString(),
                    Message = new Message {
                        Id = ObjectId.GenerateNewId().ToString(),
                        Author = "hypnospinner",
                        MarkdownText = "Message from hypnospinner 2",
                        PublicationDate = new DateTime(2019, 12, 2)
                    },
                    FileId = ObjectId.GenerateNewId().ToString(),
                    Thumbnail = ObjectId.GenerateNewId().ToString(),
                    Messages = new List<string>(
                        new[] {
                            Messages[4].Id,
                            Messages[6].Id,
                        }
                    )
                },
                new Pin{
                    Id = ObjectId.GenerateNewId().ToString(),
                    Message = new Message {
                        Id = ObjectId.GenerateNewId().ToString(),
                        Author = "AndyS1mpson",
                        MarkdownText = "Message from AndyS1mpson",
                        PublicationDate = new DateTime(2019, 12, 3)
                    },
                    FileId = ObjectId.GenerateNewId().ToString(),
                    Thumbnail = ObjectId.GenerateNewId().ToString(),
                    Messages = new List<string>()
                },
                new Pin{
                    Id = ObjectId.GenerateNewId().ToString(),
                    Message = new Message {
                        Id = ObjectId.GenerateNewId().ToString(),
                        Author = "SixDevelop",
                        MarkdownText = "Message from SixDevelop",
                        PublicationDate = new DateTime(2019, 12, 1)
                    },
                    FileId = ObjectId.GenerateNewId().ToString(),
                    Thumbnail = ObjectId.GenerateNewId().ToString(),
                    Messages = new List<string>(
                        new []
                        {
                            Messages[7].Id,
                            Messages[9].Id,
                            Messages[8].Id
                        }
                    )
                }
            }.AsEnumerable()
        );
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
                    Pins = null
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
                    Pins = null
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
                    Pins = null
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
                        HostUsername = "AndyS1mspon",
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
                        Pins = null
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
                        Pins = null
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
                        Pins = null
                    },
                }.AsEnumerable()
            );

        }
    }
}