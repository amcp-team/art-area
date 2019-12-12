using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using Microsoft.AspNetCore.Http;

namespace ArtArea.Web.Services
{
    public class PinService
    {
        private IPinRepository _pinRepository;
        private IFileRepository _fileRepository;
        public PinService(IPinRepository pinRepository, IFileRepository fileRepository)
        {
            _pinRepository = pinRepository;
            _fileRepository = fileRepository;
        }

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

        public Task CreatePinAsync(Pin pin)
            => _pinRepository.CreatePinAsync(pin);

        public string UploadFile(IFormFile file)
        {
            using (var fileStream = new MemoryStream())
            {
                file.CopyTo(fileStream);
                fileStream.Position = 0;

                return _fileRepository.UploadFileFromStream(file.FileName, fileStream);
            }
        }

        public bool PinMessageExists(string id)
            => _pinRepository.ReadPin(id).Message != null;

        public bool PinMessagesExist(string id)
            => _pinRepository.ReadPin(id).Messages != null;

      /*  public Task<IEnumerable> GetPinMessages(string id)
        {
            if (PinExist(id))
            {
                if (PinMessagesExist(id) && PinMessageExists(id))
                {
                    


                }
                else throw new Exception("Pin has no messages");

            }
            else throw new Exception("No pin with this id");
        }*/
    }
}
