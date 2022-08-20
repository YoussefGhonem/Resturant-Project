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
        public async Task<IResponseDTO> CreateCategoryManu([FromBody] CreateCatgoryDto options)
        {
            _response = await _iManueService.CreateCategoryManu(options);
            return _response;
        }

        [HttpGet]
        public ActionResult<List<CategoryDetailsDto>> GetCategoriesManu()
        {
            return Ok(_iManueService.GetCategoriesManu());
        }

        [HttpGet("sub-categories")]
        public ActionResult<PaginationResult<SubCategoryDto>> GetAllSubCategories([FromQuery] SubCategoryFilters filters)
        {
            return Ok(_iManueService.GetAllSubCategories(filters));
        }

    }
}
