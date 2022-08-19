using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Lookup.EventType;
using Resturant.Services.EventType;

namespace Resturant.Getway.Controllers
{
    [Route("api/event-types")]
    public class EventTypesController : BaseController
    {
        private readonly IEventTypeService _services;

        public EventTypesController(
           IEventTypeService service,
           IResponseDTO response,
           IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _services = service;
        }

        [HttpGet]
        public PaginationResult<EventTypeListDto> GetAll([FromQuery] BaseFilterDto filterDto)
        {
            return _services.GetAll(filterDto);
        }
        [HttpGet("dropdwon")]
        public async Task<ActionResult<List<LookupDto>>> GetDropdwon()
        {
            return Ok(await _services.GetAsDropdwon());
        }

        [HttpPost]
        public async Task<IResponseDTO> Create(CreateUpdateEventTypeDto options)
        {
            _response = await _services.Create(options);
            return _response;
        }

        [HttpPut("{id}")]
        public async Task<IResponseDTO> Update([FromRoute] Guid id, [FromBody] CreateUpdateEventTypeDto options)
        {
            _response = await _services.Update(id, options);
            return _response;
        }

        [HttpDelete("{id}")]
        public async Task<IResponseDTO> Remove([FromRoute] Guid id)
        {
            _response = await _services.Remove(id);
            return _response;
        }

    }
}
