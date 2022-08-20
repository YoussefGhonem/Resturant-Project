using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Manue;
using Resturant.Services.manue.Models;

namespace Resturant.Services.Manue
{
    public interface IManuesService
    {
        Task<IResponseDTO> CreateCategoryManu(CreateCatgoryDto crreateManueDto);
        List<CategoryDetailsDto> GetCategoriesManu();
        PaginationResult<SubCategoryDto> GetAllSubCategories(SubCategoryFilters filterDto);
    }
}
