using Resturant.Core.Interfaces;
using Resturant.DTO.Business.AboutAndCommuniry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.AboutAndCommunity
{
    public interface IAboutAndComunity
    {

        // All Intefaces Method with About 
        //Task<IResponseDTO> CreateAbout(CreateAndUpdateAboutDto createAboutDto);
        //Task<IResponseDTO> UpdateAbout(Guid Id,CreateAndUpdateAboutDto createAboutDto);
        //Task<IResponseDTO> DeleteAbout(Guid Id);
        //Task<IEnumerable<ReturnAboutDto>> GetAllAbout();
        //Task<IEnumerable<ReturnAboutDto>> GetMainAbout();
        //Task<IResponseDTO> SetMainAbout(Guid Id);
        // finish About implemntion

        // All Method For Teams for About isMain
        Task<IResponseDTO> CreateTeamMember(CreateAndUpdateTeams createAndUpdateTeams);
        Task<IResponseDTO> UpdateTeamMember(Guid TeamId, CreateAndUpdateTeams createAndUpdateTeams);
        Task<IResponseDTO> DeleteTeamMember(Guid TeamId);
        Task<IEnumerable<ReturnTeamForAboutDto>> GetAllTeamMembersForOneAbout();

        //Finish Team Impemntation

        // Community InterFace Method
        Task<IResponseDTO> CreateCommuntiy(CreateAndUpdateCommunity createAndUpdateCommunity);
        Task<IResponseDTO> UpdateCommuntiy(Guid CommunityId, CreateAndUpdateCommunity createAndUpdateCommunity);
        Task<IResponseDTO> DeleteCommuntiy(Guid CommunityId);
        Task<IEnumerable<ReturnCommunityDto>> GetMainCommunity();

    }
}
