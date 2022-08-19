using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.DTO.Business.Location;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Resturant.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;

        public LocationService(AppDbContext context, IResponseDTO response)
        {
            _context = context;
            _response = response;
        }

        public async Task<IResponseDTO> Create(CreateUpdateLocationDto options)
        {
            try
            {
                var mapping = options.Adapt<Data.DbModels.BusinessSchema.Location>();

                await _context.Locations.AddAsync(mapping);
                await _context.SaveChangesAsync();

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

        public PaginationResult<LocationListDto> GetAll(BaseFilterDto filterDto)
        {
            var paginationResult = _context.Locations.Include(x=>x.Meals).ThenInclude(x=>x.Appointments).AsNoTracking().Paginate(filterDto.PageSize, filterDto.PageNumber);

            var dataList = paginationResult.list.Adapt<List<LocationListDto>>();

            return new PaginationResult<LocationListDto>(dataList, paginationResult.total);
        }
        public async Task<IResponseDTO> Remove(Guid id)
        {
            try
            {
                var query = await _context.Locations.FindAsync(id);
                if (query == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }

                // Set Data
                query.IsDeleted = true;
                query.UpdatedOn = DateTime.Now;

                // save to the database
                _context.Locations.Attach(query);
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

        public async Task<IResponseDTO> Update(Guid id, CreateUpdateLocationDto options)
        {
            try
            {
                var eventType = await _context.Locations.FindAsync(id);
                if (eventType == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }

                // Set Data
                var mapping = options.Adapt<Data.DbModels.BusinessSchema.Location>();

                // save to the database
                _context.Locations.Attach(mapping);
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
