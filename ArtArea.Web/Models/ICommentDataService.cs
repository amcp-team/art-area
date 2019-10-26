using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
   public interface ICommentDataService
    {
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetCommentsByFile(ObjectId FileId);
        public Comment GetComment(string id);
        public void AddComment(Comment comment);
        //public void DeleteComment(string id);
        //public void UpdateComment(Comment comment);
    }
}
