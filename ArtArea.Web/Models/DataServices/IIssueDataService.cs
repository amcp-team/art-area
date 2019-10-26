using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models.DataServices
{
    interface IIssueDataService
    {
        Task<IEnumerable<Issue>> GetIssues();
        Task<Issue> GetIssue(string id);
        Task AddIssue(Issue issue);
        //Task DeleteIssue(string id);
        //Task UpdateIssue(Issue issue);
    }
}
