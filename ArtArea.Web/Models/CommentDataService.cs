using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ArtArea.Web.Models
{
    public class CommentDataService : ICommentDataService
    {
        public ApplicationDb db;
        public Task<Issue> AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetComment(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetComments()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetCommentsByFile(ObjectId FileId)
        {
            throw new NotImplementedException();
        }
    }
}
