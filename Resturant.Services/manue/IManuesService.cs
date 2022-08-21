﻿using Resturant.Core.Common;
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
        Task<IResponseDTO> UpdateCategoryManu(Guid Id, CreateManuCategoryDto UpdateManueDto);
        Task<IResponseDTO> DelelteSupCategorys(Guid Id);
        Task<IResponseDTO> UpdateSupCAtegors(Guid Id, SubCategoryDto subCategoryDto);
    }
}
