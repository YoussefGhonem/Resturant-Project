using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Gallery;

namespace Resturant.Services.Gallery
{
    public interface IGalleryService
    {

        Task<IResponseDTO> UploadNewImage(CreateAndUpdateGalleryDto createAndUpdateGallery);
        Task<IResponseDTO> DeleteImage(Guid Id);
        Task<IEnumerable<GalleryReturnDto>> GetAllImagesForGallary();
        PaginationResult<GalleryReturnDto> GetAllWithPagination(BaseFilterDto filterDto, string serverRootPath);
    }
}
