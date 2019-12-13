using System.Runtime.Serialization;
using System.ComponentModel;
using System;
using System.IO;
using System.Threading.Tasks;
using ArtArea.Web.Data.Interface;
using MongoDB.Bson;

namespace ArtArea.Web.Data.Mock
{
    public class FileRepositoryMock : IFileRepository
    {
        public void DeleteFile(string fileId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFileAsync(string fileId)
        {
            throw new NotImplementedException();
        }

        public byte[] DownloadFileAsBytes(string fileId)
        {
            throw new System.NotImplementedException();
        }

        public Task<byte[]> DownloadFileAsBytesAsync(string fileId)
        {
            throw new System.NotImplementedException();
        }

        public Stream DownloadFileAsStream(string fileId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Stream> DownloadFileAsStreamAsync(string fileId)
        {
            throw new System.NotImplementedException();
        }

        public byte[] DownloadFileFromBytes(string fileId)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> DownloadFileFromBytesAsync(string fileId)
        {
            throw new NotImplementedException();
        }

        public Stream DownloadFileFromStream(string fileId)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> DownloadFileFromStreamAsync(string fileId)
        {
            throw new NotImplementedException();
        }

        public string UploadFileFromBytes(string fileName, byte[] file)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UploadFileFromBytesAscyn(string fileName, byte[] file)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UploadFileFromBytesAsync(string fileName, byte[] file)
        {
            throw new NotImplementedException();
        }

        public string UploadFileFromStream(string fileName, Stream file)
        {
            try
            {
                var folderPath = Path.Combine("Resources", "Files");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderPath);
                var fullPath = Path.Combine(pathToSave, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var id = ObjectId.GenerateNewId().ToString();

                ApplicationDbMock.Files.Add(new FileObjectMock
                {
                    Id = id,
                    Path = Path.Combine(folderPath, fileName)
                });

                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<string> UploadFileFromStreamAsync(string fileName, Stream file)
        {
            return Task.Run(async () =>
            {
                try
                {
                    var folderPath = Path.Combine("Resources", "Files");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderPath);
                    var fullPath = Path.Combine(pathToSave, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var id = ObjectId.GenerateNewId().ToString();

                    ApplicationDbMock.Files.Add(new FileObjectMock
                    {
                        Id = id,
                        Path = Path.Combine(folderPath, fileName)
                    });

                    return id;
                }
                catch (Exception e)
                {
                    throw e;
                }
            });
        }
    }
}