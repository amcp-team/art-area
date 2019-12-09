using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ArtArea.Web.Data.Interface
{
    interface IFileRepository
    {
        #region Synchronous
        string UploadFileFromBytes(string fileName, byte[] file);
        string UploadFileFromStream(string fileName,Stream file);
        byte[] DownloadFileFromBytes(string fileId);
        Stream DownloadFileFromStream(string fileId);
        void DeleteFile(string fileId);
        #endregion


        #region Asynchronous
        Task<string> UploadFileFromBytesAsync(string fileName, byte[] file);
        Task<string> UploadFileFromStreamAsync(string fileName,Stream file);
        Task<byte[]> DownloadFileFromBytesAsync(string fileId);
        Task<Stream> DownloadFileFromStreamAsync(string fileId);
        Task DeleteFileAsync(string fileId);
        #endregion
    }
}
