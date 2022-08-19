using Microsoft.AspNetCore.Http;
using Resturant.Core.Interfaces;

namespace Resturant.Services.UploadFiles
{
    public interface IUploadFilesService
    {
        Task<IResponseDTO> UploadFile(string path, IFormFile file, bool deleteOldFiles = false);
        Task<IResponseDTO> UploadFiles(string path, List<IFormFile> files, bool deleteOldFiles = false);
        Task<IResponseDTO> DeleteFile(string path);
    }
}
