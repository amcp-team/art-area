using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
    public class Comment
    {
        public ObjectId Id { get; set; }
        //public ObjectId AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }

    }
}
