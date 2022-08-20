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

        public async Task<IResponseDTO> CreateCategoryManu(CreateManuCategoryDto options)
        {
            try
            {
                Random rnd = new Random();
                var path = $"\\Uploads\\Manu\\Manu_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
                var attachmentPath = $"{path}\\{options.File?.FileName}";

                var mapping = options.Adapt<ManuCategory>();

                if (options.File != null)
                {
                    mapping.CategoryFileUrl = attachmentPath;
                    mapping.CategoryFileName = options.File?.FileName;
                }

                await _context.ManuCategories.AddAsync(mapping);
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

        public List<CategoryDetailsDto> GetCategoriesManu(string serverRootPath)
        {
            var query = _context.ManuCategories.AsNoTracking();
            foreach (var item in query)
            {
                if (item.CategoryFileUrl != null)
                {
                    if (item.CategoryFileUrl.StartsWith("\\"))
                    {
                        if (!string.IsNullOrEmpty(item.CategoryFileUrl))
                        {

                            item.CategoryFileUrl = serverRootPath + item.CategoryFileUrl.Replace('\\', '/');
                        }
                    }
                }
            }
            return query.Adapt<List<CategoryDetailsDto>>();
        }

        public PaginationResult<SubCategoryDto> GetAllSubCategories(SubCategoryFilters filterDto)
        {
            if (filterDto.CategoryId is null)
            {
                var paginationResult = _context.ManuCategories.Where(x => !x.IsDeleted)
                    .Include(x => x.SubCatogries!.Where(x => !x.IsDeleted))
                    .AsNoTracking()
                    .Paginate(filterDto.PageSize, filterDto.PageNumber);

                var dataList = paginationResult.list.SelectMany(x => x.SubCatogries!).Adapt<List<SubCategoryDto>>();

                return new PaginationResult<SubCategoryDto>(dataList, paginationResult.total);
            }
            else
            {
                var paginationResult = _context.ManuCategories
                    .Where(x => x.Id == filterDto.CategoryId && !x.IsDeleted)
                    .Include(x => x.SubCatogries!.Where(x => !x.IsDeleted))
                    .AsNoTracking()
                    .Paginate(filterDto.PageSize, filterDto.PageNumber);

                var dataList = paginationResult.list.SelectMany(x => x.SubCatogries!).Adapt<List<SubCategoryDto>>();

                return new PaginationResult<SubCategoryDto>(dataList, paginationResult.total);
            }
        }

        // TODO : Delete for category 
        // TODO : Update for category 
        // TODO : Delete for Sub category 
        // TODO : update for Sub category 

    }
}
