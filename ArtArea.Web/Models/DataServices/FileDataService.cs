using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models.DataServices
{
    public class FileDataService:IFileDataService
    {
        public ApplicationDb db;
        public FileDataService(ApplicationDb database) => db = database;

        public async Task AddFile(File file)
        {
            await db.Files.InsertOneAsync(file);
        }

        public async Task<File> GetFile(string id) => await db.Files.Find(x => x.Id == new ObjectId(id)).FirstOrDefaultAsync();

        public async Task<File> GetFileByIssue(string id) => await db.Files.Find(x => x.Id == new ObjectId(id)).FirstOrDefaultAsync();


        public async Task<IEnumerable<File>> GetFiles() => await db.Files.Find(x => true).ToListAsync();
    }
}
