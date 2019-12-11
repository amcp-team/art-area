using ArtArea.Web.Data.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace ArtArea.Web.Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        private IGridFSBucket _bucket;
        FileRepository(IGridFSBucket bucket)
            => _bucket = bucket;

        #region Synchronous
        public void DeleteFile(string fileId)
        {
            var id = new ObjectId(fileId);
            _bucket.Delete(id);
        }

        public byte[] DownloadFileFromBytes(string fileId)
        {
            var id = new ObjectId(fileId);
            return _bucket.DownloadAsBytes(id);
        }

        public Stream DownloadFileFromStream(string fileId)
        {
            var id=new ObjectId(fileId);
            Stream fs = new MemoryStream();
            _bucket.DownloadToStream(id, fs);
            return fs;
        }

        public string UploadFileFromBytes(string fileName, byte[] file)
        {
            return _bucket.UploadFromBytes(fileName, file).ToString();
        }

        public string UploadFileFromStream(string fileName, Stream file)
        {
            return _bucket.UploadFromStream(fileName, file).ToString();
        }
        #endregion

        #region Asynchronous
        public Task DeleteFileAsync(string id)
        {
            return Task.Run(() =>
            {
                var Id = new ObjectId(id);
                _bucket.DeleteAsync(Id);
            });
        }

        public Task<byte[]> DownloadFileFromBytesAsync(string fileId)
        {
            var id = new ObjectId(fileId);
            return Task<byte[]>.Run(async ()=> await _bucket.DownloadAsBytesAsync(id));
        }

        public Task<Stream> DownloadFileFromStreamAsync(string fileId)
        {
            
            Stream fs = new MemoryStream();
            var id = new ObjectId(fileId);
            return Task<Stream>.Run(async () => 
            {
                await _bucket.DownloadToStreamAsync(id, fs); return fs; 
            });
           
        }

        public Task<string> UploadFileFromBytesAsync(string fileName, byte[] file)
        {
            return Task.Run(async () => (await _bucket.UploadFromBytesAsync(fileName, file)).ToString());
        }

        public Task<string> UploadFileFromStreamAsync(string fileName, Stream file)
        {
            return Task.Run(async () => (await _bucket.UploadFromStreamAsync(fileName, file)).ToString());
        }
        #endregion
    }
}
