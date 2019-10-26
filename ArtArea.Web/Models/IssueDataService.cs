using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
    public class IssueDataService : IIssueDataService
    {
        public ApplicationDb db;
        public Task AddIssue(Issue issue)
        {
            throw new NotImplementedException();
        }

        public Task<Issue> GetIssue(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Issue>> GetIssues()
        {
            throw new NotImplementedException();
        }
    }
}
