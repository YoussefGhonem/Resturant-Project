using Microsoft.AspNetCore.Http;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Press;

namespace Resturant.Services.Press
{
    public interface IPressService
    {
        PaginationResult<PressDataListDto> GetAll(BaseFilterDto filterDto, string serverRootPath);
        Task<IResponseDTO> CreatePress(CreateUpdatePressDto options);
        Task<IResponseDTO> RemovePress(Guid id);
        Task<IResponseDTO> UpdatePress(Guid id, CreateUpdatePressDto options);
        Task<IResponseDTO> UpdateImagePress(Guid id, IFormFile image);
    }
}
