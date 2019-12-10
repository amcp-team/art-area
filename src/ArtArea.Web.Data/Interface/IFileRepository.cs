using System.IO;
using System.Threading.Tasks;

namespace ArtArea.Web.Data.Interface
{
    public interface IFileRepository
    {
        #region Synchronous

        string UploadFileFromBytes(string fileName, byte[] file);
        string UploadFileFromStream(string fileName, Stream file);
        byte[] DownloadFileAsBytes(string fileId);
        Stream DownloadFileAsStream(string fileId);

        #endregion

        #region Asyncronous

        Task<string> UploadFileFromBytesAscyn(string fileName, byte[] file);
        Task<string> UploadFileFromStreamAsync(string fileName, Stream file);
        Task<byte[]> DownloadFileAsBytesAsync(string fileId);
        Task<Stream> DownloadFileAsStreamAsync(string fileId);

        #endregion
    }
}