using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models.DataServices
{
    public class IssueDataService : IIssueDataService
    {
        public ApplicationDb db;
        public IssueDataService(ApplicationDb database) => db = database;

        public async Task AddIssue(Issue issue)
            =>await db.Issues.InsertOneAsync(issue);
       

        public async Task DeleteIssue(string id) 
            => await db.Issues.DeleteOneAsync(id);

        public async Task<Issue> GetIssue(string id) 
            => await db.Issues.Find(x => x.Id == new ObjectId(id)).FirstOrDefaultAsync();

        public async Task<IEnumerable<Issue>> GetIssues() 
            => await db.Issues.Find(x => true).ToListAsync();

        public async Task<IEnumerable<Issue>> GetProjectIssues(ObjectId projectId) 
            => await db.Issues.Find(x => x.Id == projectId).ToListAsync();

        public async Task UpdateIssue(Issue issue) 
            => await db.Issues.ReplaceOneAsync(new BsonDocument("id", issue.Id), issue);
    }
}
