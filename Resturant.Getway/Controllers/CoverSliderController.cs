using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Cover;
using Resturant.DTO.Business.Gallery;
using Resturant.Services.ContectUs;
using Resturant.Services.Cover;

namespace Resturant.Getway.Controllers
{
    [Route("api/cover-slider")]
    [ApiController]
    public class CoverSliderController : BaseController
    {
        private readonly ICover _services;

        public CoverSliderController(ICover service, IResponseDTO response, IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _services = service;
        }
        [HttpGet]
        public PaginationResult<CoverReturnDro> GetAllCover([FromQuery] BaseFilterDto filterDto)
        {
            return _services.GetAllCover(filterDto, ServerRootPath);
        }

        [HttpPost]
        public async Task<IResponseDTO> UploadNewPhotoForCover([FromForm] CreateAndUpdateCoverDto createAndUpdateCoverDto)
        {
            return await _services.UploadImageCover(createAndUpdateCoverDto);
        }

        [HttpDelete("{id}")]
        public async Task<IResponseDTO> DeleteImageCover([FromRoute] Guid id)
        {
            return await _services.DeleteImageCover(id);
        }

    }
}
