using Mapster;
using Microsoft.EntityFrameworkCore;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.DTO.Business.PrivateDining;

namespace Resturant.Services.PrivateDining
{
    public class PrivateDiningService : IPrivateDiningService
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;

        public PrivateDiningService(AppDbContext context, IResponseDTO response)
        {
            _context = context;
            _response = response;
        }
        public async Task<IResponseDTO> Create(CreatePrivateDiningDto options)
        {
            try
            {

                var privateDining = new Data.DbModels.BusinessSchema.PrivateDining()
                {
                    AdditionalInformation = options.AdditionalInformation,
                    Company = options.Company,
                    EndTime = options.EndTime,
                    Email = options.Email,
                    FirstName = options.FirstName,
                    LastName = options.LastName,
                    NumberOfPeople = options.NumberOfPeople,
                    PhoneNumber = options.PhoneNumber,
                    StartTime = options.StartTime,
                    EvenDate = options.EvenDate,
                };

                await _context.PrivateDining.AddAsync(privateDining);
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

        public PaginationResult<PrivateDiningListDto> GetAll(BaseFilterDto filterDto)
        {
            var paginationResult = _context.PrivateDining.AsNoTracking().Paginate(filterDto.PageSize, filterDto.PageNumber);

            var dataList = paginationResult.list.Adapt<List<PrivateDiningListDto>>();

            return new PaginationResult<PrivateDiningListDto>(dataList, paginationResult.total);
        }
    }
}
