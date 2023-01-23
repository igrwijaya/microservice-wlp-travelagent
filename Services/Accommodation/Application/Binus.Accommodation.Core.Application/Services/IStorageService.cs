using System.IO;
using System.Threading.Tasks;
using Binus.Accommodation.Core.Application.Services.Response;

namespace Binus.Accommodation.Core.Application.Services
{
    public interface IStorageService
    {
        #region Public Methods

        Task<UploadFileResponse> UploadAsync(string folderNameKey, string fileName, Stream file);

        string GetFileUrl(string fileName);

        Task DeleteUserImagesAsync(string folderNameKey, int accountId);

        #endregion
    }
}