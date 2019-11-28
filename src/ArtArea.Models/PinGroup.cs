using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtArea.Models
{
    /*
        PINGROUP :
            - Id : 
                string representation of ObjectId, which is MongoDb generated id

            - Name : 
                source file name including format (ex: consept.psd)

            - Pins :
                list of stringed 
    */
    public class PinGroup
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Pins { get; set; }
    }
}