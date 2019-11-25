using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtArea.Models
{
    public class User
    {
        // FIXME possibly we can use username as id (if we gaurantee that it's unique to MongoDB)
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}