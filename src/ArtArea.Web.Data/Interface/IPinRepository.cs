using ArtArea.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtArea.Web.Data.Interface
{
    public interface IPinRepository
    {
        //Asynchronous methods
        Task<IEnumerable<Pin>> ReadPinsAsync();
        Task<Pin> ReadPinAsync(string id);
        Task CreatePinAsync(Pin pin);
        Task UpdatePinAsync(Pin pin);
        Task DeletePinAsync(string id);

        //Synchronous methods
        IEnumerable<Pin> ReadPins();
        Pin ReadPin(string id);
        void CreatePin(Pin pin);
        void UpdatePin(Pin pin);
        void DeletePin(string id);          
    }
}
