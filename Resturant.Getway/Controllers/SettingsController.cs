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

        //UpLoad Cover
        [HttpPut("UploadCoverManue")]
        public async Task<IResponseDTO> UploadCoverManue([FromForm] ManuCoverDto options)
        {
            _response = await _pressServicee.UploadMenuCover(options);
            return _response;
        }
        [HttpPut("UploadAboutManue")]
        public async Task<IResponseDTO> UploadAboutManue([FromForm] AboutCoverDto options)
        {
            _response = await _pressServicee.UploadAboutCover(options);
            return _response;
        }
        [HttpPut("UploadPrivatDiningManue")]
        public async Task<IResponseDTO> UploadPrivatDiningManue([FromForm] PrivateDininCoverDto options)
        {
            _response = await _pressServicee.UploadPrivateDiningCover(options);
            return _response;
        }

        //Delete cover
        [HttpDelete("DeleteAboutCover")]
        public async Task<IResponseDTO> DeleteAboutCover()
        {
           _response = await _pressServicee.DeleteAboutCover();
            return _response;
        }
        [HttpDelete("DeleteManuCover")]
        public async Task<IResponseDTO> DeleteManuCover()
        {
            _response = await _pressServicee.DeleteMenuCover();
            return _response;
        }
        [HttpDelete("DeletePrivateDiningCover")]
        public async Task<IResponseDTO> DeletePrivateDiningCover()
        {
            _response = await _pressServicee.DeletePrivateDiningCover();
            return _response;

        }

        //Update Cover 
        [HttpPut("UpdateCoverManue")]
        public async Task<IResponseDTO> UpdateCoverManue([FromForm] ManuCoverDto options)
        {
            _response = await _pressServicee.updatMenuCover(options);
            return _response;
        }
        [HttpPut("UpdateAboutManue")]
        public async Task<IResponseDTO> UpdateAboutManue([FromForm] AboutCoverDto options)
        {
            _response = await _pressServicee.updatAboutCover(options);
            return _response;
        }
        [HttpPut("UpdatePrivatDiningManue")]
        public async Task<IResponseDTO> UpdatePrivatDiningManue([FromForm] PrivateDininCoverDto options)
        {
            _response = await _pressServicee.updatPrivateDiningCover(options);
            return _response;
        }



    }
}