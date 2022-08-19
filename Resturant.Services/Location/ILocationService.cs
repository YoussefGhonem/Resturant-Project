using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Location;

namespace Resturant.Services.Location
{
    public interface ILocationService
    {
        PaginationResult<LocationListDto> GetAll(BaseFilterDto filterDto);
        Task<IResponseDTO> Remove(Guid id);
        Task<IResponseDTO> Create(CreateUpdateLocationDto options);
        Task<IResponseDTO> Update(Guid id, CreateUpdateLocationDto options);
    }
}
