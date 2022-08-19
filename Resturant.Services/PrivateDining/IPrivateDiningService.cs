using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.PrivateDining;

namespace Resturant.Services.PrivateDining
{
    public interface IPrivateDiningService
    {
        PaginationResult<PrivateDiningListDto> GetAll(BaseFilterDto filterDto);
        Task<IResponseDTO> Create(CreatePrivateDiningDto options);
    }
}
