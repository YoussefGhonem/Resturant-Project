using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.PrivateDiningImage;
using Resturant.Services.PrivateDiningImage;

namespace Resturant.Getway.Controllers
{
    [Route("api/private-dining-images")]

    public class PrivateDiningImagesControlller : BaseController
    {
        private readonly IPrivateDiningImageService _servicee;

        public PrivateDiningImagesControlller(
           IPrivateDiningImageService pressServicee,
           IResponseDTO response,
           IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _servicee = pressServicee;
        }

        [HttpGet]
        public PaginationResult<PrivateDiningImageListDto> GetAll([FromQuery] BaseFilterDto filterDto)
        {
            return _servicee.GetAll(filterDto, ServerRootPath);
        }

        [HttpPost]
        public async Task<IResponseDTO> Create([FromForm] CreatePrivateDiningImageDto options)
        {
            _response = await _servicee.Create(options);
            return _response;
        }

        [HttpDelete("{id}")]
        public async Task<IResponseDTO> Remove([FromRoute] Guid id)
        {
            _response = await _servicee.Remove(id);
            return _response;
        }

    }
}
