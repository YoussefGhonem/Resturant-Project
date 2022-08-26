using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.SiteLocation;
using Resturant.Services.SiteLocation;

namespace Resturant.Getway.Controllers
{
    [Route("api/site-locations")]
    public class SiteLocationsController : BaseController
    {
        private readonly ISiteLocationService _services;

        public SiteLocationsController(
           ISiteLocationService service,
           IResponseDTO response,
           IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _services = service;
        }

        [HttpGet]
        public async Task<ActionResult<SiteLocationDetailsDto>>  GetDetails()
        {
            return Ok(await _services.GetDetails());
        }

        [HttpPut]
        public async Task<IResponseDTO> Update(UpdateSiteLocationDto options)
        {
            _response = await _services.Update(options);
            return _response;
        }

    }
}
