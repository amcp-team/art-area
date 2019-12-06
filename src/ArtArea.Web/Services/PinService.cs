using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Services
{
    public class PinService
    {
        private IPinRepository _pinRepository;
        public PinService(IPinRepository pinRepository)
            => _pinRepository = pinRepository;

        public bool PinExist(string pinId)
            => _pinRepository.ReadPin(pinId) != null;

        public Task<Pin> GetPinAsync(string pinId)
        {
            if (PinExist(pinId))
            {
                return _pinRepository.ReadPinAsync(pinId);
            }
            else throw new Exception("No pin with this id");


        }
    }
}
