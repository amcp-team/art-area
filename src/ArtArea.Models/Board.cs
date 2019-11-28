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

            - PinGroups : 
                list of attached groups of pins associated with the same file (see (*) for better
                explanation). Just list of stringed ObjectId objects

            - ProjectId : 
                id of the project that is a storage for this board 

    */

    /*  (*)
         
            When we develop some visaul art we have physical source files (concrete files of any 
            format that - .psd, .fbx, .ai, etc.) which are stored on the PC of artist inside 
            project folder binded to remote project on server db. When artist pushes a source file
            (as new PIN) we want it to be a part of some file history, so we need to have some 
            abstract entity that unites all pins binded to one source file history so:

            Designer PC:
                project-folder
                |--- board-folder-1
                     |--- source-file-consept.psd   => has a pin group associated with all pins 
                                                       of this one concrete file

                                                       User creates a snapshot of it - some state
                                                       of it at some point of time that is 
                                                       encapsulated into Pin & pushes to remote
                     |--- source-file-model.fbx
                     |--- ...
                |--- board-folder-2
                |--- ...

            Remote (JSON style):
                project: {
                    boards: [
                        board-1 : {
                            source-files | pin-groups: {
                                Pins: [
                                    pin-1 : { some pin data there },
                                    pin-2 : { some pin data there },
                                    ...
                                ],
                                Name: source-file-consept.psd

                            },
                            title: board-title,
                            ...
                        },
                        board-2 : {
                            -//-
                        }
                    ]
                }

                So when user pushes a pin remote binds it to the corresponding pin group of some
                source file
    */
    public class Board
    {
        [BsonId]
        public string Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string ProjectId { get; set; }
        public Message Task { get; set; }
        public BoardPrivacy Privacy { get; set; }
        public IEnumerable<UserAccess> Collaborators { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> PinGroups { get; set; }
    }
}
