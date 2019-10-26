using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
    interface ICommentDataService
    {
        Task<IEnumerable<Comment>> GetComments();
        Task<IEnumerable<Comment>> GetCommentsByFile(ObjectId FileId);
        Task<Comment> GetComment(string id);
        Task<Issue> AddComment(Comment comment);
        //Task DeleteComment(string id);
        //Task UpdateComment(Comment comment);
    }
}
