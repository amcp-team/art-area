using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
    public class Task
    {
        public ObjectId Id { get; set; }
        public List<ObjectId> Files { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        //public ObjectId CreatorId { get; set; }
        //public List<ObjectId> Assignees { get; set; }

    }
}
