using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtArea.Web.Data.Mock
{
    public class PinRepositoryMock : IPinRepository
    {
        #region Synchronous

        public void CreatePin(Pin pin)
        {
            var pinToCreate = ApplicationDbMock.Pins
                .SingleOrDefault(x => x.Id == pin.Id);
            if (pinToCreate == null)
                ApplicationDbMock.Pins.Add(pin);
            else throw new Exception("Pin already exists");
        }

        public void DeletePin(string id)
        {
            var pinToDelete = ApplicationDbMock.Pins
                .SingleOrDefault(x => x.Id == id);
            if (pinToDelete != null)
                ApplicationDbMock.Pins.Remove(pinToDelete);
            else throw new Exception("Can't delete pin - one doesn't exist");
        }

        public IEnumerable<Pin> ReadPins()
        {
            return ApplicationDbMock.Pins;
        }

        public Pin ReadPin(string id)
        {
            return ApplicationDbMock.Pins
                .SingleOrDefault(x => x.Id == id);
        }

        public void UpdatePin(Pin pin)
        {
            var pinToUpdate = ApplicationDbMock.Pins
                .SingleOrDefault(x => x.Id == pin.Id);
            if (pinToUpdate != null)
                pinToUpdate = pin;
            else throw new Exception("Can't update pin - no such board exist");
        }
        #endregion

        #region Asynchronous

        public Task CreatePinAsync(Pin pin)
        {
            var pinToCreate = ApplicationDbMock.Pins
                .SingleOrDefault(x => x.Id == pin.Id);
            if (pinToCreate == null)
                return Task.Run(() => ApplicationDbMock.Pins.Add(pin));
            else throw new Exception("Pin already exists");
        }

        public Task DeletePinAsync(string id)
        {
            var pinToDelete = ApplicationDbMock.Pins
                .SingleOrDefault(x => x.Id == id);
            if (pinToDelete != null)
                return Task.Run(() 
                    => ApplicationDbMock.Pins.Remove(pinToDelete));
            else throw new Exception("Can't delete pin - one doesn't exist");
        }

        public Task<Pin> ReadPinAsync(string id)
        {
            return Task.Run(() 
                => ApplicationDbMock.Pins.SingleOrDefault(x => x.Id == id));
        }        

        public Task<IEnumerable<Pin>> ReadPinsAsync()
        {
            return Task.Run(() 
                => ApplicationDbMock.Pins.AsEnumerable());
        }
       
        public Task UpdatePinAsync(Pin pin)
        {
            return Task.Run(() =>
            {
                var pinToUpdate = ApplicationDbMock.Pins
                    .SingleOrDefault(x => x.Id == pin.Id);

                if (pinToUpdate != null)
                    pinToUpdate = pin;
                else throw new Exception("Can't update pin - no such board exist");
            });
        }
        #endregion
    }
}
