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
        public FileDataService(ApplicationDb database) => db = database;

        public async Task AddFile(File file)
        {
            await db.Files.InsertOne(file);
        }

        public Task<File> GetFile(string id)
        {
            throw new NotImplementedException();
        }

        public Task<File> GetFileByIssue(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<File>> GetFiles()
        {
            throw new NotImplementedException();
        }
    }
}
