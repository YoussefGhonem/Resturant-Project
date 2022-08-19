using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nest;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.Data.DbModels.BusinessSchema.About;
using Resturant.Data.DbModels.BusinessSchema.manue;
using Resturant.DTO.Business.AboutAndCommuniry;
using Resturant.Services.UploadFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.AboutAndCommunity
{
    public class AboutAndCommunityService : IAboutAndComunity
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;
        private readonly IUploadFilesService _uploadFilesService;

        public AboutAndCommunityService(AppDbContext context, IResponseDTO response, IUploadFilesService uploadFilesService)
        {
            _context = context;
            _response = response;
            _uploadFilesService = uploadFilesService;
        }
        //public async Task<IResponseDTO> CreateAbout(CreateAndUpdateAboutDto createAboutDto)
        //{
        //    try
        //    {
        //        var About = new Data.DbModels.BusinessSchema.About.AboutUs()
        //        {
        //            Name = createAboutDto.Name,
        //            DecriptionAbout = createAboutDto.DecriptionAbout
        //        };

        //        await _context.AboutUss.AddAsync(About);
        //        await _context.SaveChangesAsync();
        //        _response.IsPassed = true;
        //        return _response;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.Data = null;
        //        _response.IsPassed = false;
        //        _response.Errors.Add($"Error: {ex.Message}");
        //    }

        //    if (_response.Errors.Count > 0)
        //    {
        //        _response.Errors = _response.Errors.Distinct().ToList();
        //        _response.IsPassed = false;
        //        _response.Data = null;
        //        return _response;
        //    }
        //    return _response;
        //}
        //public async Task<IResponseDTO> DeleteAbout(Guid Id)
        //{
        //    try
        //    {
        //        var About = await _context.AboutUss.FindAsync(Id);
        //        if (About == null)
        //        {
        //            _response.IsPassed = false;
        //            _response.Message = "Invalid object Id";
        //            return _response;
                    
        //        }
        //        About.IsDeleted = true;
        //        About.UpdatedOn = DateTime.Now;
        //        // save to the database
        //        _context.AboutUss.Attach(About);
        //        await _context.SaveChangesAsync();

        //    }
        //    catch (Exception ex)
        //    {
        //        _response.Data = null;
        //        _response.IsPassed = false;
        //        _response.Errors.Add($"Error: {ex.Message}");
        //    }
        //    if (_response.Errors.Count > 0)
        //    {
        //        _response.Errors = _response.Errors.Distinct().ToList();
        //        _response.IsPassed = false;
        //        _response.Data = null;
        //        return _response;
        //    }
        //    return _response;
        //}
        //public async Task<IEnumerable<ReturnAboutDto>> GetAllAbout()
        //{
        //    var AllAbout = await _context.AboutUss.Where(A => A.IsDeleted == false).Include(A=>A.Teams.Where(T=>T.IsDeleted== false)).ToListAsync();
        //    var AboutToReturn = AllAbout.Adapt<IEnumerable<ReturnAboutDto>>();
        //    return AboutToReturn;

        //}
        //public async Task<IEnumerable<ReturnAboutDto>> GetMainAbout()
        //{
        //    var AllAbout = await _context.AboutUss.Where(A => A.IsMain == true && A.IsDeleted== false).Include(A=>A.Teams.Where(T=>T.IsDeleted== false)).ToListAsync();
        //    var AboutToReturn = AllAbout.Adapt<IEnumerable<ReturnAboutDto>>();
        //    return AboutToReturn;
        //}
        //public async Task<IResponseDTO> UpdateAbout(Guid Id,CreateAndUpdateAboutDto createAboutDto)
        //{
        //    try
        //    {
        //        var About = await _context.AboutUss.FindAsync(Id);
        //        if (About == null)
        //        {
        //            _response.IsPassed = false;
        //            _response.Message = "Invalid object Id";
        //            return _response;
        //        }

        //        About.Name = createAboutDto.Name;
        //        About.DecriptionAbout = createAboutDto.DecriptionAbout;

        //        // save to the database
        //        _context.AboutUss.Attach(About);
        //        await _context.SaveChangesAsync();

        //    }
        //    catch (Exception ex)
        //    {
        //        _response.Data = null;
        //        _response.IsPassed = false;
        //        _response.Errors.Add($"Error: {ex.Message}");
        //    }
        //    if (_response.Errors.Count > 0)
        //    {
        //        _response.Errors = _response.Errors.Distinct().ToList();
        //        _response.IsPassed = false;
        //        _response.Data = null;
        //        return _response;
        //    }
        //    return _response;
        //}
        //public  async Task<IResponseDTO> SetMainAbout(Guid Id)
        //{
        //    try
        //    {
        //        var MainAbout = await _context.AboutUss.Where(A => A.IsMain == true).ToListAsync();
        //        var MainAboutNeedToSet = await _context.AboutUss.FindAsync(Id);
        //        if (MainAbout == null && MainAboutNeedToSet == null)
        //        {
        //            _response.IsPassed = false;
        //            _response.Message = "Invalid object Id";
        //            return _response;                  
        //        }
        //        foreach (var A in MainAbout)
        //        {
        //            A.IsMain = false;
        //            _context.AboutUss.Attach(A);
        //        }
        //        MainAboutNeedToSet.IsMain = true;
        //        _context.AboutUss.Attach(MainAboutNeedToSet);
        //        await _context.SaveChangesAsync();

        //    }
        //    catch (Exception ex)
        //    {
        //        _response.Data = null;
        //        _response.IsPassed = false;
        //        _response.Errors.Add($"Error: {ex.Message}");
        //    }
        //    if (_response.Errors.Count > 0)
        //    {
        //        _response.Errors = _response.Errors.Distinct().ToList();
        //        _response.IsPassed = false;
        //        _response.Data = null;
        //        return _response;
        //    }
        //    return _response;
        //}


        // Team Started impemtation
        public async Task<IResponseDTO> CreateTeamMember(CreateAndUpdateTeams createAndUpdateTeams)
        {
            try
            {
                foreach (var image in createAndUpdateTeams.Images)
                {
                    Random rnd = new Random();
                    var path = $"\\Uploads\\Team\\Team{DateTime.Now}_{rnd.Next(9000)}";
                    var attachmentPath = $"{path}\\{image?.FileName}";

                    var obj = new Data.DbModels.BusinessSchema.About.Team()
                    {
                        Name = createAndUpdateTeams?.Name,
                        ImageUrl= attachmentPath,
                        JopTitle= createAndUpdateTeams?.JopTitle,
                        Description=createAndUpdateTeams?.Description
                    };

                    await _context.Teams.AddAsync(obj);
                    await _context.SaveChangesAsync();
                    await _uploadFilesService.UploadFile(path, image);
                }

                _response.IsPassed = true;
                return _response;
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Errors.Add($"Error: {ex.Message}");
            }

            if (_response.Errors.Count > 0)
            {
                _response.Errors = _response.Errors.Distinct().ToList();
                _response.IsPassed = false;
                _response.Data = null;
                return _response;
            }
            return _response;
        }
        public async Task<IResponseDTO> UpdateTeamMember(Guid TeamId, CreateAndUpdateTeams createAndUpdateTeams)
        {
            try
            {
                var OneMemberTeam = await _context.Teams.FindAsync(TeamId);
                if (OneMemberTeam == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;
                }
                foreach (var image in createAndUpdateTeams?.Images)
                {
                    Random rnd = new Random();
                    var path = $"\\Uploads\\Team\\Team{DateTime.Now}_{rnd.Next(9000)}";
                    var attachmentPath = $"{path}\\{image?.FileName}";


                    OneMemberTeam.Name = createAndUpdateTeams?.Name;
                    OneMemberTeam.ImageUrl = attachmentPath;
                    OneMemberTeam.JopTitle = createAndUpdateTeams?.JopTitle;
                    OneMemberTeam.Description = createAndUpdateTeams?.Description;

                    _context.Teams.Attach(OneMemberTeam);
                    await _context.SaveChangesAsync();
                    await _uploadFilesService.UploadFile(path, image);
                }

                _response.IsPassed = true;
                return _response;
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Errors.Add($"Error: {ex.Message}");
            }

            if (_response.Errors.Count > 0)
            {
                _response.Errors = _response.Errors.Distinct().ToList();
                _response.IsPassed = false;
                _response.Data = null;
                return _response;
            }
            return _response;
        }
        public async Task<IResponseDTO> DeleteTeamMember(Guid TeamId)
        {
            try
            {
                var DeleteMember = await _context.Teams.FindAsync(TeamId);
                if (DeleteMember == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;
                }
                DeleteMember.IsDeleted = true;
                DeleteMember.UpdatedOn = DateTime.Now;
                // save to the database
                _context.Teams.Attach(DeleteMember);
                await _context.SaveChangesAsync();
                await _uploadFilesService.DeleteFile(DeleteMember?.ImageUrl);
                _response.IsPassed = true;
                
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Errors.Add($"Error: {ex.Message}");
            }
            if (_response.Errors.Count > 0)
            {
                _response.Errors = _response.Errors.Distinct().ToList();
                _response.IsPassed = false;
                _response.Data = null;
                return _response;
            }
            return _response;
        }
        public async Task<IEnumerable<ReturnTeamForAboutDto>> GetAllTeamMembersForOneAbout()
        {
           var TeamsMember = await _context.Teams.Where(T=>T.IsDeleted == false).ToListAsync();
           var TeamsForReturn = TeamsMember.Adapt<IEnumerable<ReturnTeamForAboutDto>>();
           return TeamsForReturn;
        }


        // Community Implemtaions
        public async Task<IResponseDTO> CreateCommuntiy(CreateAndUpdateCommunity createAndUpdateCommunity)
        {
            try
            {
                foreach (var image in createAndUpdateCommunity.Images)
                {
                    Random rnd = new Random();
                    var path = $"\\Uploads\\Communtiy\\Communtiy{DateTime.Now}_{rnd.Next(9000)}";
                    var attachmentPath = $"{path}\\{image?.FileName}";

                    var obj = new Data.DbModels.BusinessSchema.About.Community()
                    {
                        name = createAndUpdateCommunity?.name,
                        ImageUrl = attachmentPath,
                        Desciption = createAndUpdateCommunity?.Desciption
                    };

                    await _context.Communitys.AddAsync(obj);
                    await _context.SaveChangesAsync();
                    await _uploadFilesService.UploadFile(path, image);
                }

                _response.IsPassed = true;
                return _response;
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Errors.Add($"Error: {ex.Message}");
            }

            if (_response.Errors.Count > 0)
            {
                _response.Errors = _response.Errors.Distinct().ToList();
                _response.IsPassed = false;
                _response.Data = null;
                return _response;
            }
            return _response;
        }
        public async Task<IResponseDTO> UpdateCommuntiy(Guid CommunityId, CreateAndUpdateCommunity createAndUpdateCommunity)
        {
            try
            {
                var OnlyOneCommunity = await _context.Communitys.FindAsync(CommunityId);
                if (OnlyOneCommunity == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;
                }
                foreach (var image in createAndUpdateCommunity.Images)
                {
                    Random rnd = new Random();
                    var path = $"\\Uploads\\Team\\Team{DateTime.Now}_{rnd.Next(9000)}";
                    var attachmentPath = $"{path}\\{image?.FileName}";

                    OnlyOneCommunity.name = createAndUpdateCommunity?.name;
                    OnlyOneCommunity.ImageUrl = attachmentPath;
                    OnlyOneCommunity.Desciption = createAndUpdateCommunity?.Desciption;
                    

                     _context.Communitys.Attach(OnlyOneCommunity);
                    await _context.SaveChangesAsync();
                    await _uploadFilesService.UploadFile(path, image);
                }

                _response.IsPassed = true;
                return _response;
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Errors.Add($"Error: {ex.Message}");
            }

            if (_response.Errors.Count > 0)
            {
                _response.Errors = _response.Errors.Distinct().ToList();
                _response.IsPassed = false;
                _response.Data = null;
                return _response;
            }
            return _response;
        }
        public async Task<IResponseDTO> DeleteCommuntiy(Guid CommunityId)
        {
            try
            {
                var Community = await _context.Communitys.FindAsync(CommunityId);
                if (Community == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;

                }
                Community.IsDeleted = true;
                Community.UpdatedOn = DateTime.Now;
                // save to the database
                _context.Communitys.Attach(Community);
                await _context.SaveChangesAsync();
                await _uploadFilesService.DeleteFile(Community?.ImageUrl);
                _response.IsPassed = true;
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Errors.Add($"Error: {ex.Message}");
            }
            if (_response.Errors.Count > 0)
            {
                _response.Errors = _response.Errors.Distinct().ToList();
                _response.IsPassed = false;
                _response.Data = null;
                return _response;
            }
            return _response;
        }
        public async Task<IEnumerable<ReturnCommunityDto>> GetMainCommunity()
        {
            var AllAbout = await _context.Communitys.Where(A=>A.IsDeleted == false).ToListAsync();
            var AboutToReturn = AllAbout.Adapt<IEnumerable<ReturnCommunityDto>>();
            return AboutToReturn;
        }
    }
}
