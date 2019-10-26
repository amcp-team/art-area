using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
    public class File
    {
        public ObjectId Id { get; set; }
        public ObjectId RealId { get; set;}
        public string Version { get; set; }
        public DateTime DateCreation { get; set; }
        public ObjectId IssueId { get; set; }
    }
}
