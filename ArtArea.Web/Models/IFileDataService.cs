using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtArea.Web.Models
{
    interface IFileDataService
    {
        IEnumerable<File> GetFiles();
        public File GetFile(string id);
        public void AddFile(File file);
        //public void DeleteFile(string id);
        //public void UpdateFile(File file);



    }
}
