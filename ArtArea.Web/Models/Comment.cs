using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        //public ObjectId AuthorId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string FileId { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }

    }
}
