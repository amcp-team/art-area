using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
    public class FileDataService:IFileDataService
    {
        public ApplicationDb db;

        public Task<Issue> AddFile(File file)
        {
            throw new NotImplementedException();
        }

        public Task<File> GetFile(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<File>> GetFiles()
        {
            throw new NotImplementedException();
        }
    }
}
