using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Gallery;
using Resturant.DTO.Business.PrivateDiningImage;
using Resturant.Services.EventType;
using Resturant.Services.Gallery;

namespace Resturant.Getway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : BaseController
    {
        private readonly IGalleryService _services;
        private readonly IResponseDTO _response;

        public GalleryController(
           IGalleryService service,
           IResponseDTO response,
           IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _services = service;
        }

        [HttpGet]
        public PaginationResult<GalleryReturnDto> GetAllGallertyWithPagination([FromQuery] BaseFilterDto filterDto)
        {
            return _services.GetAllWithPagination(filterDto, ServerRootPath);
        }

        [HttpPost]
        public async Task<IResponseDTO> UploadNewPhotoForGallary([FromForm] CreateAndUpdateGalleryDto createAndUpdateGalleryDto)
        {
            return await _services.UploadNewImage(createAndUpdateGalleryDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IResponseDTO> DeleteImage([FromRoute] Guid Id)
        {
            return await _services.DeleteImage(Id);
        }

    }
}
