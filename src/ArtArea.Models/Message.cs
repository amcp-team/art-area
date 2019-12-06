using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtArea.Models
{
    /*
        MESSAGE:
            - Id : 
                stringed ObjectId. Unique identifies for any message posted
            
            - Author :
                username of one who published this message

            - MarkdownText : 
                stringed markdown representation of the text of the message for GitHub like view

            - PublicationDate :
                when this message was published 
    */
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Author { get; set; }
        public string MarkdownText { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime PublicationDate { get; set; }
    }
}