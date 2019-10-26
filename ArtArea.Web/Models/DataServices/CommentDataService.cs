using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.IO;
using MongoDB.Driver;

namespace ArtArea.Web.Models.DataServices
{
    public class CommentDataService : ICommentDataService
    {
        public ApplicationDb db;
        public CommentDataService(ApplicationDb database) => db = database;


        public async Task<Comment> GetComment(string id)
            => await db.Comments.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<IEnumerable<Comment>> GetComments()
            => await db.Comments.Find(x => true).ToListAsync();

        public async Task<IEnumerable<Comment>> GetFileComments(string FileId)
            => await db.Comments.Find(x => x.FileId == FileId).ToListAsync();

        public async Task AddComment(Comment comment)
            => await db.Comments.InsertOneAsync(comment);

        public async Task DeleteComment(string id) 
            => await db.Comments.DeleteOneAsync(x => x.Id == id);

        public async Task UpdateComment(Comment comment) 
            => await db.Comments.ReplaceOneAsync(new BsonDocument("id", comment.Id), comment);
    }
}
