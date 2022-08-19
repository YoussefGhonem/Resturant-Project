using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.PrivateDining;
using Resturant.Services.PrivateDining;

namespace Resturant.Getway.Controllers
{
    [Route("api/private-dining")]
    public class PrivateDiningController : BaseController
    {
        private readonly IPrivateDiningService _services;

        public PrivateDiningController(
           IPrivateDiningService service,
           IResponseDTO response,
           IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _services = service;
        }

        [HttpGet]
        public PaginationResult<PrivateDiningListDto> GetAll([FromQuery] BaseFilterDto filterDto)
        {
            return _services.GetAll(filterDto);
        }

        [HttpPost]
        public async Task<IResponseDTO> Create(CreatePrivateDiningDto options)
        {
            _response = await _services.Create(options);
            return _response;
        }


    }
}
