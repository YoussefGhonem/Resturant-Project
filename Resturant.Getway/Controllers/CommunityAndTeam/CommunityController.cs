using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.AboutAndCommuniry;
using Resturant.Services.AboutAndCommunity;

namespace Resturant.Getway.Controllers.CommunityAndAbout
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : BaseController
    {
        private readonly IAboutAndComunity _services;
        public CommunityController(
          IAboutAndComunity service,
          IResponseDTO response,
          IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _services = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ReturnCommunityDto>> GetAllCommunity()
        {
            var AllCommunity = await _services.GetMainCommunity();
            return AllCommunity;
        }

        [HttpPost]
        public async Task<IResponseDTO> CreateCommuinty([FromForm] CreateAndUpdateCommunity createAndUpdateCommunity)
        {
            _response = await _services.CreateCommuntiy(createAndUpdateCommunity);
            return _response;
        }

        [HttpPut("{id}")]
        public async Task<IResponseDTO> UpdateCommuinty([FromRoute]     Guid id, [FromForm] CreateAndUpdateCommunity createAndUpdateCommunity)
        {
            _response = await _services.UpdateCommuntiy(id, createAndUpdateCommunity);
            return _response;
        }
        [HttpDelete("{id}")]
        public async Task<IResponseDTO> DeleteCommuinty([FromRoute] Guid id)
        {
            _response = await _services.DeleteCommuntiy(id);
            return _response;
        }
    }
}
