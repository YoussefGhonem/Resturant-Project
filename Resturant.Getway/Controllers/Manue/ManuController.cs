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

        [HttpGet("categories/{id}")]
        public async Task<ActionResult<CategoryManuDetailsDto>> GetCategoriesManuDetails(Guid id)
        {
            return Ok(await _iManueService.GetCategoriesManuDetails(id, ServerRootPath));
        }

        [HttpGet("sub-categories")]
        public ActionResult<PaginationResult<SubCategoryDto>> GetAllSubCategories([FromQuery] SubCategoryFilters filters)
        {
            return Ok(_iManueService.GetAllSubCategories(filters));
        }

        [HttpDelete("category/{id}")]
        public async Task<IResponseDTO> DeleteCategory(Guid id)
        {
            _response = await _iManueService.DeleteCategoryManu(id);
            return _response;
        }

        [HttpPut("category/{id}")]
        public async Task<IResponseDTO> UpdateCategory([FromRoute] Guid id, [FromForm] CreateAndUpdateManueDto UpdateManueDto)
        {
            _response = await _iManueService.UpdateCategoryManu(id, UpdateManueDto);
            return _response;
        }


        [HttpDelete("sub-category/{id}")]
        public async Task<IResponseDTO> DeleteSupCategory(Guid id)
        {
            _response = await _iManueService.DelelteSupCategorys(id);
            return _response;
        }

        [HttpPut("sub-category/{id}")]
        public async Task<IResponseDTO> UpdateSubCategory([FromRoute] Guid id, CreateAndUpdateSubcategory subCategoryDto)
        {
            _response = await _iManueService.UpdateSubCategories(id, subCategoryDto);

            return _response;
        }

    }
}
