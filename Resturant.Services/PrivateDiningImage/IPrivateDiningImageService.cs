using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.PrivateDiningImage;

namespace Resturant.Services.PrivateDiningImage
{
    public interface IPrivateDiningImageService
    {
        PaginationResult<PrivateDiningImageListDto> GetAll(BaseFilterDto filterDto, string serverRootPath);
        Task<IResponseDTO> Create(CreatePrivateDiningImageDto options);
        Task<IResponseDTO> Remove(Guid id);
    }
}
