using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtArea.Models
{
    /*
        TODO defines rules for user password & user name 
             restrict some symbols that mey interfer with
             route in adress bar & make it not working

        USER:
            - Username : 
                each user has a unniques username that we can user as PK
                
            - Password : 
                password of the user

            - Name : 
                name of the user which we should show (ex: Ilya Katun)

            - Email : 
                user email (possibly hiddent by some privacy settings of the user) 
    */
    public class User
    {
        [BsonId]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AvatarId { get; set; }
    }
}
