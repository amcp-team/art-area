using ArtArea.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtArea.Web.Data.Interface
{
    interface IPinGroupRepository
    {
        Task<IEnumerable<PinGroup>> ReadPinGroupsAsync();
        Task<PinGroup> ReadPinGroupAsync(string id);
        Task CreatePinGroupAsync(PinGroup pinGroup);
        Task UpdatePinGroupAsync(PinGroup pinGroup);
        Task DeletePinGroupAsync(string id);

        IEnumerable<PinGroup> ReadPinGroup();
        PinGroup ReadPinGroup(string id);
        void CreatePinGroup(PinGroup pinGroup);
        void UpdatePinGroup(PinGroup pinGroup);
        void DeletePinGroup(string id);
    }
}
