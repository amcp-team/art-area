using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models.DataServices
{
    public interface IFileDataService
    {
        Task<IEnumerable<File>> GetFiles();
        Task<File> GetFile(string id);
        Task<File> GetFileByIssue(string id);
        Task AddFile(File file);
        Task DeleteFile(string id);
        Task UpdateFile(File file);



    }
}
