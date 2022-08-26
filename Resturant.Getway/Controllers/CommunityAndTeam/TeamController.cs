using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.AboutAndCommuniry;
using Resturant.Services.AboutAndCommunity;

namespace Resturant.Getway.Controllers.CommunityAndAbout
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : BaseController
    {
        private readonly IAboutAndComunity _services;
        public TeamController(
          IAboutAndComunity service,
          IResponseDTO response,
          IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _services = service;
        }

        [HttpGet]
        public PaginationResult<ReturnTeamForAboutDto> GetAllTeamMamber([FromQuery] BaseFilterDto filterDto)
        {
            var AllTeamMember = _services.GetAllTeamMembersForOneAbout(filterDto, ServerRootPath);
            return AllTeamMember;
        }

        [HttpPost]
        public async Task<IResponseDTO> CreateTeamMember([FromForm] CreateAndUpdateTeams createAndUpdateTeams)
        {
            _response = await _services.CreateTeamMember(createAndUpdateTeams);
            return _response;
        }

        [HttpPut("{id}")]
        public async Task<IResponseDTO> UpdateTeamMember([FromRoute] Guid id, [FromForm] CreateAndUpdateTeams createAndUpdateTeams)
        {
            _response = await _services.UpdateTeamMember(id, createAndUpdateTeams);
            return _response;
        }
        [HttpDelete("{id}")]
        public async Task<IResponseDTO> DeleteTeamMember([FromRoute] Guid id)
        {
            _response = await _services.DeleteTeamMember(id);
            return _response;
        }



    }
}
