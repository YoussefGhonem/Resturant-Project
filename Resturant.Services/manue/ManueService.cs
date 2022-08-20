using Mapster;
using Microsoft.EntityFrameworkCore;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.Data.DbModels.BusinessSchema.manue;
using Resturant.DTO.Business.Manue;
using Resturant.Getway.Controllers.Manue;
using Resturant.Services.manue.Models;

namespace Resturant.Services.Manue
{
    public class ManueService : IManuesService
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;

        public ManueService(AppDbContext context, IResponseDTO response)
        {
            _context = context;
            _response = response;
        }

        public async Task<IResponseDTO> CreateCategoryManu(CreateCatgoryDto options)
        {
            try
            {
                var mapping = options.Adapt<Manu>();
                await _context.Manus.AddAsync(mapping);
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

        public List<CategoryDetailsDto> GetCategoriesManu()
        {
            var query = _context.Categorys.AsNoTracking();
            return query.Adapt<List<CategoryDetailsDto>>();
        }

        public PaginationResult<SubCategoryDto> GetAllSubCategories(SubCategoryFilters filterDto)
        {
            var paginationResult = _context.Categorys
                .Where(x => x.Id == filterDto.CategoryId)
                .Include(x => x.SubCatogries)
                .AsNoTracking()
                .Paginate(filterDto.PageSize, filterDto.PageNumber);

            var dataList = paginationResult.list.SelectMany(x => x.SubCatogries!).Adapt<List<SubCategoryDto>>();

            return new PaginationResult<SubCategoryDto>(dataList, paginationResult.total);
        }


        // TODO : Delete for category 
        // TODO : Update for category 
        // TODO : Delete for Sub category 
        // TODO : update for Sub category 

    }
}
