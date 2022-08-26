using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Happining;
using Resturant.Services.Happining;

namespace Resturant.Getway.Controllers
{
    [Route("api/happenings")]
    [ApiController]
    public class HappiningController : BaseController
    {
        private readonly IHappining _services;

        public HappiningController(IHappining service, IResponseDTO response, IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _services = service;
        }
        [HttpGet]
        public PaginationResult<HappiningReturnDto> GetAllHappining([FromQuery] BaseFilterDto filterDto)
        {
            return _services.GetAllHappining(filterDto, ServerRootPath);
        }

        [HttpPost]
        public async Task<IResponseDTO> CreateHappining([FromForm] CreateAndUpdateHappiningDto createAndUpdateHappiningDto)
        {
            return await _services.CreateHappining(createAndUpdateHappiningDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IResponseDTO> DeleteHappining([FromRoute] Guid Id)
        {
            return await _services.DeleteHappining(Id);
        }
    }
}
