using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Settings;
using Resturant.Services.Settings;

namespace Resturant.Getway.Controllers
{
    [Route("api/settings")]
    public class SettingsController : BaseController
    {
        private readonly ISettingsService _pressServicee;

        public SettingsController(
           ISettingsService pressServicee,
           IResponseDTO response,
           IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _pressServicee = pressServicee;
        }

        [HttpGet]
        public async Task<ActionResult<SettingsDetailsDto>> SettingsDetails()
        {
            return await _pressServicee.SettingsDetails(ServerRootPath);
        }

        [HttpPut("about-us-Settings")]
        public async Task<IResponseDTO> UpdateAboutUsSettings(UpdateSettingsDto options)
        {
            _response = await _pressServicee.UpdateAboutUsSettings(options);
            return _response;
        }
        [HttpPut("private-dining")]
        public async Task<IResponseDTO> UpdatePrivateDining([FromForm] UpdateSettingsDto options)
        {
            _response = await _pressServicee.UpdatePrivateDining(options);
            return _response;
        }



    }
}