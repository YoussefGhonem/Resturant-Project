using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.Data.DbModels.BusinessSchema;
using Resturant.DTO.Business.Press;
using Resturant.DTO.Business.SiteLocation;
using Resturant.Services.UploadFiles;

namespace Resturant.Services.SiteLocation
{
    public class SiteLocationService : ISiteLocationService
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;

        public SiteLocationService(AppDbContext context, IResponseDTO response)
        {
            _context = context;
            _response = response;
        }

        public async Task<SiteLocationDetailsDto> GetDetails()
        {
            var query = await _context.SiteLocations.FirstOrDefaultAsync();
            return query.Adapt<SiteLocationDetailsDto>();
        }

        public async Task<IResponseDTO> Update(UpdateSiteLocationDto options)
        {
            try
            {
                var query = await _context.SiteLocations.FirstOrDefaultAsync();
                if (query == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }

                // Set Data
                query.Adress = options.Adress;
                query.WorkDays = options.WorkDays;
                query.GoogleMapLink = options.GoogleMapLink;
                query.UpdatedOn = DateTime.Now;

                // save to the database
                _context.SiteLocations.Attach(query);
                await _context.SaveChangesAsync();
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
    }
}
