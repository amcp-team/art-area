using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using ArtArea.Models.Privacy;

namespace ArtArea.Models
{
    /*
        BOARD:
            - Id : 
                combination of project id & number. New board gets n + 1 after the last added board

            - Title : 
                displayed title of the board

            - Number : 
                unique number for board
            
            - Task : 
                Message object that stores when board was created & what problem it should solve

            - Collaborators : 
                list of username & their moderation level

            - Privacy : 
                type of privacy used for this board. It can be: 
                * public for everyone : any user can see it
                * public for project collaborators : only projec collabs can see it
                * public for board collaborators : only board collabs can see it
            
            - Description : 
                short description of this board which is always shown

            - SourceFileName :
                name of the source file used for version control in this board

            - Pins :
                list of string ObjectIds of pins that are created for this board 

            - ProjectId : 
                id of the project that is a storage for this board 

    */

    public class Board
    {
        [BsonId]
        public string Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string ProjectId { get; set; }
        public Message Task { get; set; }
        public string SourceFileName { get; set; }
        public BoardPrivacy Privacy { get; set; }
        public List<UserAccess> Collaborators { get; set; }
        public string Description { get; set; }
        public List<string> Pins { get; set; }
    }
}
