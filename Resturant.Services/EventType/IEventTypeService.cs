using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Lookup.EventType;

namespace Resturant.Services.EventType
{
    public interface IEventTypeService
    {

        PaginationResult<EventTypeListDto> GetAll(BaseFilterDto filterDto);
        Task<List<LookupDto>> GetAsDropdwon();
        Task<IResponseDTO> Remove(Guid id);
        Task<IResponseDTO> Create(CreateUpdateEventTypeDto options);
        Task<IResponseDTO> Update(Guid id, CreateUpdateEventTypeDto options);
    }
}
