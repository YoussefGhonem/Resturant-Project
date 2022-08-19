using Resturant.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturant.DTO.Business.Manue;
using Resturant.Data.DbModels.BusinessSchema.manue;


namespace Resturant.Services.Manue
{
    public interface IManuesService
    {



        // Manue crud 
        Task<IResponseDTO> CreateManue(CreateAndUpdateManueDto crreateManueDto);
        Task<IResponseDTO> DeletManue(Guid Id);
        Task<IResponseDTO> UpdateManue(Guid Id, CreateAndUpdateManueDto updateManueDto);
        Task<IEnumerable<manuetoreturnDto>> GetallManue();
        Task<IEnumerable<manuetoreturnDto>> GetManuerByid(Guid id);
        // fininsh manue crud

        // Category manue crud
        Task<IResponseDTO> CreateCategoryManue(createandUpdateCatgoryDto createandupdateCatgoryDto);
        Task<IResponseDTO> Deletcatgory(Guid Id,Guid manueID);
        Task<IResponseDTO> UpdateCatgory(Guid Id, createandUpdateCatgoryDto updateManueDto);
        Task<IEnumerable<categoryforreturnDto>> GetAllCategory();
        Task<IEnumerable<categoryforreturnDto>> GetCategoryManuerByid(Guid manueid);
        // finish category

        //start supcstegory
        Task<IResponseDTO> CreateSubcategory(CreateAndUpdateSubcategory crreatecategoryDto);
        Task<IResponseDTO> DeletSubcategory(Guid Id,Guid categoryId);
        Task<IResponseDTO> UpdateSubcategory(Guid Id, CreateAndUpdateSubcategory updatecategoryDto);
        Task<IEnumerable<SubcategoryforreturnDto>> GetallSubcategory();
        Task<IEnumerable<SubcategoryforreturnDto>> GetSubCategoryByCategoryId(Guid CategoryId);

    }
}
