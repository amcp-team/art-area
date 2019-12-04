using ArtArea.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtArea.Web.Data.Interface
{
    interface ITagRepository
    {
        //Asynchronous methods
        Task<IEnumerable<Tag>> ReadTagsAsync();
        Task<Tag> ReadTagAsync(string id);
        Task CreateTagAsync(Tag tag);
        Task UpdateTagAsync(Tag tag);
        Task DeleteTagAsync(string id);

        //Synchronous methods
        IEnumerable<Tag> ReadTags();
        Tag ReadTag(string id);
        void CreateTag(Tag tag);
        void UpdateTag(Tag tag);
        void DeleteTag(string id); 
    }
}
