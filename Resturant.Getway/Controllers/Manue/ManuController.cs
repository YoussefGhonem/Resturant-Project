using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Manue;
using Resturant.Services.manue.Models;
using Resturant.Services.Manue;
namespace Resturant.Getway.Controllers.Manue
{
    [Route("api/menu")]
    [ApiController]
    public class ManuController : BaseController
    {
        private readonly IManuesService _iManueService;

        public ManuController(IManuesService service, IResponseDTO response, IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _iManueService = service;
        }

        [HttpPost]
        public async Task<IResponseDTO> CreateCategoryManu([FromForm] CreateManuCategoryDto options)
        {
            _response = await _iManueService.CreateCategoryManu(options);
            return _response;
        }

        [HttpGet("categories")]
        public ActionResult<List<CategoryDetailsDto>> GetCategoriesManu()
        {
            return Ok(_iManueService.GetCategoriesManu(ServerRootPath));
        }

        [HttpGet("sub-categories")]
        public ActionResult<PaginationResult<SubCategoryDto>> GetAllSubCategories([FromQuery] SubCategoryFilters filters)
        {
            return Ok(_iManueService.GetAllSubCategories(filters));
        }

        [HttpDelete("category/{Id}")]
        public async Task<IResponseDTO> DeleteCategory(Guid Id)
        {
            _response = await _iManueService.DeleteCategoryManu(Id);
            return _response;
        }
        [HttpPut("category/{Id}")]
        public async Task<IResponseDTO> UpdateCategory([FromRoute] Guid Id, [FromForm] CreateAndUpdateManueDto UpdateManueDto)
        {
            _response = await _iManueService.UpdateCategoryManu(Id, UpdateManueDto);
            return _response;
        }


        [HttpDelete("sub-category/{Id}")]
        public async Task<IResponseDTO> DeleteSupCategory(Guid Id)
        {
            _response = await _iManueService.DelelteSupCategorys(Id);
            return _response;
        }
        [HttpPut("sub-category/{Id}")]
        public async Task<IResponseDTO> UpdateCategory([FromRoute] Guid Id, [FromForm] CreateAndUpdateSubcategory subCategoryDto)
        {
            _response = await _iManueService.UpdateSupCAtegors(Id, subCategoryDto);

            return _response;
        }

    }
}
