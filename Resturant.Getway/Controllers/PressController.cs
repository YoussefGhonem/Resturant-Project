using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Press;
using Resturant.Services.Press;

namespace Resturant.Getway.Controllers
{
    [Route("api/press")]
    public class PressController : BaseController
    {
        private readonly IPressService _pressServicee;

        public PressController(
           IPressService pressServicee,
           IResponseDTO response,
           IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _pressServicee = pressServicee;
        }

        [HttpGet]
        public PaginationResult<PressDataListDto> GetAll([FromQuery] BaseFilterDto filterDto)
        {
            return _pressServicee.GetAll(filterDto, ServerRootPath);
        }

        [HttpPost]
        public async Task<IResponseDTO> CreatePress([FromForm] CreateUpdatePressDto options)
        {
            _response = await _pressServicee.CreatePress(options);
            return _response;
        }

        [HttpPut("{id}")]
        public async Task<IResponseDTO> UpdatePress([FromRoute] Guid id, [FromBody] CreateUpdatePressDto options)
        {
            _response = await _pressServicee.UpdatePress(id, options);
            return _response;
        }

        [HttpDelete("{id}")]
        public async Task<IResponseDTO> RemovePress([FromRoute] Guid id)
        {
            _response = await _pressServicee.RemovePress(id);
            return _response;
        }


    }
}