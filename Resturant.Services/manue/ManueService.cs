using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.DTO.Business.Manue;
using Mapster;
using Microsoft.Extensions.Options;
using Resturant.Data.DbModels.BusinessSchema;
using Microsoft.EntityFrameworkCore;
using Resturant.Data.DbModels.BusinessSchema.manue;
using Nest;
using NPOI.SS.Formula.Functions;

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
        public async Task<IResponseDTO> CreateManue(CreateAndUpdateManueDto crreateManueDto)
        {
            try
            {
                var MANUE = new Data.DbModels.BusinessSchema.manue.Manue()
                {
                    Name = crreateManueDto.Name,
                };

                await _context.Manues.AddAsync(MANUE);
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
        public async Task<IResponseDTO> DeletManue(Guid Id)
        {
            try
            {
                var manue = await _context.Manues.FindAsync(Id);
                if (manue == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }
                // Set Data
                manue.IsDeleted = true;
                manue.UpdatedOn = DateTime.Now;
                // save to the database
                _context.Manues.Attach(manue);
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
        public async Task<IResponseDTO> UpdateManue(Guid Id, CreateAndUpdateManueDto updateManueDto)
        {
            try
            {
                var manue = await _context.Manues.FindAsync(Id);
                if (manue == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;
                }

                manue.Name = updateManueDto.Name;

                // save to the database
                _context.Manues.Attach(manue);
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
        public async Task<IEnumerable<manuetoreturnDto>> GetallManue()
        {
            var manue = await _context.Manues.Where(m => m.IsDeleted == false).Include(m => m.Categorys.Where(c=>c.IsDeleted == false))
                .ThenInclude(c => c.subCatogry.Where(s=>s.IsDeleted==false)).ToListAsync();
            var manuesreturn = manue.Adapt<IEnumerable<manuetoreturnDto>>();
            return manuesreturn;
        }
        public async Task<IEnumerable<manuetoreturnDto>> GetManuerByid(Guid id)
        {
            var manue = await _context.Manues.Where(m => m.IsDeleted == false && m.Id==id).Include(m => m.Categorys.Where(c => c.IsDeleted == false))
                .ThenInclude(c => c.subCatogry.Where(s => s.IsDeleted == false)).ToListAsync();
            var manuesreturn = manue.Adapt<IEnumerable<manuetoreturnDto>>();
            return manuesreturn;
        }


        public async Task<IResponseDTO> CreateCategoryManue(createandUpdateCatgoryDto createandupdateCatgoryDto)
        {
            try
            {
                var category = new Data.DbModels.BusinessSchema.manue.Category()
                {
                    Name = createandupdateCatgoryDto.Name,
                    manueId=createandupdateCatgoryDto.manueId
                };

                await _context.Categorys.AddAsync(category);
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
        public async Task<IResponseDTO> Deletcatgory(Guid Id, Guid manueID)
        {
            try
            {
                var category = await _context.Categorys.FindAsync(Id);
                if (category == null && category?.manueId != manueID)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }
                // Set Data
                category.IsDeleted = true;
                category.UpdatedOn = DateTime.Now;
                // save to the database
                _context.Categorys.Attach(category);
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
        public async Task<IResponseDTO> UpdateCatgory(Guid Id, createandUpdateCatgoryDto updateManueDto)
        {
            try
            {
                var category = await _context.Categorys.FindAsync(Id);
                if (category == null && category?.manueId != updateManueDto.manueId)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;
                }

                category.Name = updateManueDto.Name;
                category.manueId = updateManueDto.manueId;

                // save to the database
                _context.Categorys.Attach(category);
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
        public async Task<IEnumerable<categoryforreturnDto>> GetAllCategory()
        {
            var manue = await _context.Categorys.Where(m => m.IsDeleted == false).Include(m => m.subCatogry.Where(m=>m.IsDeleted==false)).ToListAsync();
            var manuetoReturn = manue.Adapt<IEnumerable<categoryforreturnDto>>();
            return manuetoReturn;
        }
        public async Task<IEnumerable<categoryforreturnDto>> GetCategoryManuerByid(Guid manueid)
        {
            var manue = await _context.Categorys.Where(m => m.IsDeleted == false && m.manueId == manueid).Include(m => m.subCatogry.Where(s=>s.IsDeleted== false)).ToListAsync();
            var manuetoReturn = manue.Adapt<IEnumerable<categoryforreturnDto>>();
            return manuetoReturn;
        }



        public async Task<IResponseDTO> CreateSubcategory(CreateAndUpdateSubcategory crreatecategoryDto)
        {
            try
            {
                var Subcategory = new Data.DbModels.BusinessSchema.manue.Subcategory()
                {
                    Name = crreatecategoryDto.Name,
                    price = crreatecategoryDto.price,
                    value = crreatecategoryDto.value,
                    categoryId = crreatecategoryDto.categoryId,
                    Description = crreatecategoryDto.Description

                };

                await _context.Subcategorys.AddAsync(Subcategory);
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
        public async Task<IResponseDTO> DeletSubcategory(Guid Id, Guid categoryId)
        {
            try
            {
                var subcategory = await _context.Subcategorys.FindAsync(Id);
                if (subcategory == null && subcategory?.categoryId != categoryId)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }
                // Set Data
                subcategory.IsDeleted = true;
                subcategory.UpdatedOn = DateTime.Now;
                // save to the database
                _context.Subcategorys.Attach(subcategory);
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
        public async Task<IResponseDTO> UpdateSubcategory(Guid Id, CreateAndUpdateSubcategory updatecategoryDto)
        {
            try
            {
                var subcategory = await _context.Subcategorys.FindAsync(Id);
                if (subcategory == null || subcategory?.categoryId != updatecategoryDto.categoryId)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;
                }

                subcategory.Name = updatecategoryDto.Name;
                subcategory.categoryId = updatecategoryDto.categoryId;
                subcategory.Description = updatecategoryDto.Description;
                subcategory.price = updatecategoryDto.price;
                subcategory.value = updatecategoryDto.value;

                // save to the database
                _context.Subcategorys.Attach(subcategory);
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
        public async Task<IEnumerable<SubcategoryforreturnDto>> GetallSubcategory()
        {
            var subcateory = await _context.Subcategorys.ToListAsync();
            var subcateorytoreturn = subcateory.Adapt<IEnumerable<SubcategoryforreturnDto>>();
            return subcateorytoreturn;
        }
        public async Task<IEnumerable<SubcategoryforreturnDto>> GetSubCategoryByCategoryId(Guid CategoryId)
        {
            var manue = await _context.Subcategorys.Where(m => m.IsDeleted == false && m.categoryId == CategoryId).ToListAsync();
            var manuetoReturn = manue.Adapt<IEnumerable<SubcategoryforreturnDto>>();
            return manuetoReturn;
        }
    }
}
