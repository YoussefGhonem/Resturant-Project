using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Gallery;
using Resturant.DTO.Business.Jop;
using Resturant.DTO.Business.Press;
using Resturant.Services.Gallery;
using Resturant.Services.Jop;

namespace Resturant.Getway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JopController : BaseController
    {
        private readonly IJopService _services;

        public JopController(
           IJopService service,
           IResponseDTO response,
           IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _services = service;
        }
        [HttpGet]
        public PaginationResult<jopForReturnDto> GetAllJopRquest([FromQuery] BaseFilterDto filterDto)
        {
            return _services.GetAll(filterDto);
        }
        [HttpPost]
        public async Task<IResponseDTO> SubmitInJopForm([FromForm] CreateJopDto createJopDto)
        {     
            return await _services.SubmitInJopFormCreate(createJopDto);
        }
        [HttpDelete("{id}")]
        public async Task<IResponseDTO> DeletJopRequest(Guid id)
        {
            return await _services.DeleteSubmitedJop(id);
        }
    }
}
