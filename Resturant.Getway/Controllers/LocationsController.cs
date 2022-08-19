using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Location;
using Resturant.Services.Location;

namespace Resturant.Getway.Controllers
{
    [Route("api/locations")]

    public class LocationsController : BaseController
    {
        private readonly ILocationService _services;

        public LocationsController(
           ILocationService service,
           IResponseDTO response,
           IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _services = service;
        }

        [HttpGet]
        public PaginationResult<LocationListDto> GetAll([FromQuery] BaseFilterDto filterDto)
        {
            return _services.GetAll(filterDto);
        }

        [HttpPost]
        public async Task<IResponseDTO> Create(CreateUpdateLocationDto options)
        {
            _response = await _services.Create(options);
            return _response;
        }

        [HttpPut("{id}")]
        public async Task<IResponseDTO> Update([FromRoute] Guid id, [FromBody] CreateUpdateLocationDto options)
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
