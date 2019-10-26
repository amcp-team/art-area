using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
    interface IFileDataService
    {
        Task<IEnumerable<File>> GetFiles();
        Task<File> GetFile(string id);
        Task<Issue> AddFile(File file);
        //Task DeleteFile(string id);
        // Task UpdateFile(File file);



    }
}
