using Mapster;
using Microsoft.EntityFrameworkCore;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.DTO.Lookup.EventType;

namespace Resturant.Services.EventType
{
    public class EventTypeService : IEventTypeService
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;

        public EventTypeService(AppDbContext context, IResponseDTO response)
        {
            _context = context;
            _response = response;
        }
        public async Task<IResponseDTO> Create(CreateUpdateEventTypeDto options)
        {
            try
            {

                var eventType = new Data.DbModels.LookupSchema.EventType()
                {
                    Name = options.Name,
                    Description = options.Description,
                };

                await _context.EventTypes.AddAsync(eventType);
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

        public PaginationResult<EventTypeListDto> GetAll(BaseFilterDto filterDto)
        {
            var paginationResult = _context.EventTypes.AsNoTracking().Paginate(filterDto.PageSize, filterDto.PageNumber);

            var dataList = paginationResult.list.Adapt<List<EventTypeListDto>>();

            return new PaginationResult<EventTypeListDto>(dataList, paginationResult.total);
        }

        public async Task<List<LookupDto>> GetAsDropdwon()
        {
            var query = _context.EventTypes.AsNoTracking();

            return query.Adapt<List<LookupDto>>();
        }

        public async Task<IResponseDTO> Remove(Guid id)
        {
            try
            {
                var eventType = await _context.EventTypes.FindAsync(id);
                if (eventType == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }

                // Set Data
                eventType.IsDeleted = true;
                eventType.UpdatedOn = DateTime.Now;

                // save to the database
                _context.EventTypes.Attach(eventType);
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

        public async Task<IResponseDTO> Update(Guid id, CreateUpdateEventTypeDto options)
        {
            try
            {
                var eventType = await _context.EventTypes.FindAsync(id);
                if (eventType == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }

                // Set Data
                eventType.Name = options.Name;
                eventType.Description = options.Description;
                eventType.UpdatedOn = DateTime.Now;

                // save to the database
                _context.EventTypes.Attach(eventType);
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
