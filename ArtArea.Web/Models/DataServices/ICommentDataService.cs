using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models.DataServices
{
    public interface ICommentDataService
    {
        Task<IEnumerable<Comment>> GetComments();
        Task<IEnumerable<Comment>> GetFileComments(string FileId);
        Task<Comment> GetComment(string id);
        Task AddComment(Comment comment);
        Task DeleteComment(string id);
        Task UpdateComment(Comment comment);
    }
}
