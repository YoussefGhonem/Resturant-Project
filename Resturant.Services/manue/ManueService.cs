using Mapster;
using Microsoft.EntityFrameworkCore;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.Data.DbModels.BusinessSchema.manue;
using Resturant.DTO.Business.Manue;
using Resturant.Services.manue.Models;
using Resturant.Services.UploadFiles;

namespace Resturant.Services.Manue
{
    public class ManueService : IManuesService
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;
        private readonly IUploadFilesService _uploadFilesService;

        public ManueService(AppDbContext context, IResponseDTO response, IUploadFilesService uploadFilesService)
        {
            _context = context;
            _response = response;
            _uploadFilesService = uploadFilesService;
        }

        public async Task<IResponseDTO> CreateCategoryManu(CreateManuCategoryDto options)
        {
            try
            {
                Random rnd = new Random();
                var path = $"\\Uploads\\Manu\\Manu_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
                var attachmentPath = $"{path}\\{options.File?.FileName}";

                var mapping = options.SubCatogries.Adapt<Subcategory>();
                mapping.CreatedOn = DateTime.Now;

                var manuCategory = new ManuCategory()
                {
                    Name = options.Name,
                    Description = options.Description,
                    WorkDayes = options.WorkDayes,
                    CategoryFileUrl = attachmentPath,
                    CategoryFileName = options.File?.FileName
                };
                manuCategory.SubCatogries.Add(mapping);


                await _context.ManuCategories.AddAsync(manuCategory);
                await _uploadFilesService.UploadFile(path, options.File);
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
        public async Task<CategoryManuDetailsDto> GetCategoriesManuDetails(Guid categoryId, string serverRootPath)
        {
            var query = await _context.ManuCategories.FirstOrDefaultAsync(x => x.Id == categoryId);

            if (query.CategoryFileUrl != null)
            {
                if (query.CategoryFileUrl.StartsWith("\\"))
                {
                    if (!string.IsNullOrEmpty(query.CategoryFileUrl))
                    {

                        query.CategoryFileUrl = serverRootPath + query.CategoryFileUrl.Replace('\\', '/');
                    }
                }
            }

            var result = query.Adapt<CategoryManuDetailsDto>();
            return result;


        }

        public PaginationResult<SubCategoryDto> GetAllSubCategories(SubCategoryFilters filterDto)
        {
            if (filterDto.CategoryId == null)
            {
                var paginationResult = _context.ManuCategories.AsNoTracking().Where(x => !x.IsDeleted)
                    .Include(x => x.SubCatogries!.Where(x => x.IsDeleted == false)).ThenInclude(x => x.MealNames.Where(x => !x.IsDeleted))
                    .Paginate(filterDto.PageSize, filterDto.PageNumber);

                var dataList = paginationResult.list.SelectMany(x => x.SubCatogries!).Adapt<List<SubCategoryDto>>();

                return new PaginationResult<SubCategoryDto>(dataList, paginationResult.total);
            }
            else
            {
                var paginationResult = _context.ManuCategories.AsNoTracking()
                    .Where(x => x.Id == filterDto.CategoryId && !x.IsDeleted)
                    .Include(x => x.SubCatogries!.Where(x => !x.IsDeleted)).ThenInclude(x => x.MealNames.Where(x => !x.IsDeleted))
                    .Paginate(filterDto.PageSize, filterDto.PageNumber);

                var dataList = paginationResult.list.SelectMany(x => x.SubCatogries!).Adapt<List<SubCategoryDto>>();

                return new PaginationResult<SubCategoryDto>(dataList, paginationResult.total);
            }
        }

        // TODO : Delete for category 
        public async Task<IResponseDTO> DeleteCategoryManu(Guid Id)
        {
            try
            {
                var category = await _context.ManuCategories.Where(m => m.Id == Id && !m.IsDeleted).Include(m => m.SubCatogries!.Where(s => s.IsDeleted)).ToListAsync();
                if (category == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }
                // Set Data
                foreach (var maincategory in category)
                {
                    foreach (var sup in maincategory.SubCatogries!)
                    {
                        foreach (var mealNAmes in sup.MealNames!)
                        {
                            if (mealNAmes.IsDeleted == false)
                            {
                                mealNAmes.IsDeleted = true;
                                mealNAmes.UpdatedOn = DateTime.Now;
                                //_context.MealNames.Attach(mealNAmes);
                            }
                        }
                        sup.IsDeleted = true;
                        sup.UpdatedOn = DateTime.Now;
                        //_context.SubCatogries.Attach(sup);
                    }
                    maincategory.IsDeleted = true;
                    maincategory.UpdatedOn = DateTime.Now;
                    _context.ManuCategories.Attach(maincategory);
                }
                // save to the database
                await _context.SaveChangesAsync();
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
        // TODO : Update for category 
        public async Task<IResponseDTO> UpdateCategoryManu(Guid Id, CreateAndUpdateManueDto UpdateManueDto)
        {
            try
            {
                var OneCategory = await _context.ManuCategories.FindAsync(Id);
                if (OneCategory == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }
                OneCategory.Name = UpdateManueDto.Name;
                OneCategory.Description = UpdateManueDto.Description;
                OneCategory.WorkDayes = UpdateManueDto.WorkDayes;
                OneCategory.UpdatedOn = DateTime.Now;

                if (UpdateManueDto.File != null)
                {
                    Random rnd = new Random();
                    var path = $"\\Uploads\\Manu\\Manu_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
                    var attachmentPath = $"{path}\\{UpdateManueDto.File?.FileName}";
                    OneCategory.CategoryFileUrl = attachmentPath;
                    OneCategory.CategoryFileName = UpdateManueDto.File?.FileName;
                }

                _context.ManuCategories.Attach(OneCategory);
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


        // TODO : Delete for Sub category 
        public async Task<IResponseDTO> DelelteSupCategorys(Guid Id)
        {
            try
            {
                var supcategory = await _context.SubCatogries.Where(m => m.Id == Id && !m.IsDeleted).Include(m => m.MealNames!.Where(m => m.IsDeleted == false)).ToListAsync();
                if (supcategory == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }
                // Set Data
                foreach (var sup in supcategory)
                {
                    foreach (var mealNAmes in sup.MealNames!)
                    {
                        if (mealNAmes.IsDeleted == false)
                        {
                            mealNAmes.IsDeleted = true;
                            mealNAmes.UpdatedOn = DateTime.Now;
                            //_context.MealNames.Attach(mealNAmes);
                        }
                    }
                    //_context.SubCatogries.Attach(sup);
                    sup.IsDeleted = true;
                    sup.UpdatedOn = DateTime.Now;
                    _context.SubCatogries.Attach(sup);
                }
                // save to the database
                await _context.SaveChangesAsync();
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
        // TODO : update for Sub category 
        public async Task<IResponseDTO> UpdateSubCategories(Guid Id, CreateAndUpdateSubcategory subCategoryDto)
        {
            try
            {
                var OneCategory = await _context.ManuCategories
                                                .Include(x => x.SubCatogries)
                                                .ThenInclude(x => x.MealNames)
                                                .FirstOrDefaultAsync(x => x.Id == Id);
                if (OneCategory == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }
                var mapping = subCategoryDto.SubCatogries.Adapt<Subcategory>();
                mapping.CreatedOn = DateTime.Now;

                OneCategory.SubCatogries.Add(mapping);

                OneCategory.UpdatedOn = DateTime.Now;
                _context.ManuCategories.Update(OneCategory);
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
    }
}
