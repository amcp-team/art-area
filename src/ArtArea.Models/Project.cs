using ArtArea.Models.Privacy;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ArtArea.Models
{
    /*
        PROJECT:
            - Id : 
                combination of username & project's title user that hosts project can't have 
                several projects with the same name

            - Title : 
                project name, should correspond same rules as username in order not to break
                routing rules

            - IsPrivate : 
                defines whether project is visible only for collaborators (& admin) or to all
                users of Art Area service

            - Collaborators : 
                pairs of username & moderation access that defines what one can & can't do in
                the corresponding project

            - Tags : 
                list of tags defined gloablly in the project (there can't be 2 tags with the 
                same name)
            
            - Description : short description of the project, optional
    */
    public class Project
    {
        [BsonId]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string HostUsername { get; set; }
        public bool IsPrivate { get; set; }
        public IEnumerable<UserAccess> Collaborators { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
