using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.IO;
using System.Collections.Generic;
using MongoDB.Driver;

namespace ArtArea.Web.Models
{
    public class CommentDataService : ICommentDataService
    {
        public ApplicationDb db;

        public CommentDataService(ApplicationDb database) => db = database;
        public Task<Issue> AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }


        public CommentDataService(ApplicationDb database)
            => db = database;


        public async Task<Comment> GetComment(string id)
            => await db.Comments.Find(x => x.Id == new ObjectId(id)).FirstOrDefaultAsync();
        public async Task<IEnumerable<Comment>> GetComments()
            => await db.Comments.Find(x => true).ToListAsync();

        public async Task<IEnumerable<Comment>> GetCommentsByFile(ObjectId FileId)
            => await db.Comments.Find(x => x.FileId == FileId).ToListAsync();

        public async Task AddComment(Comment comment)
            => await db.Comments.InsertOneAsync(comment);
        
    }
}
