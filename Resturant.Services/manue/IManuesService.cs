using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Manue;
using Resturant.Services.manue.Models;

namespace Resturant.Services.Manue
{
    public interface IManuesService
    {
        Task<IResponseDTO> CreateCategoryManu(CreateManuCategoryDto crreateManueDto);
        List<CategoryDetailsDto> GetCategoriesManu(string serverRootPath);
        PaginationResult<SubCategoryDto> GetAllSubCategories(SubCategoryFilters filterDto);
        Task<IResponseDTO> DeleteCategoryManu(Guid Id);
        Task<IResponseDTO> UpdateCategoryManu(Guid Id, UpdateManueCategoryDto UpdateManueDto);
        Task<IResponseDTO> DelelteSupCategorys(Guid Id);
        Task<IResponseDTO> UpdateSubCategories(Guid Id, CreateAndUpdateSubcategory subCategoryDto);
        Task<CategoryManuDetailsDto> GetCategoriesManuDetails(Guid categoryId, string serverRootPath);
    }
}
