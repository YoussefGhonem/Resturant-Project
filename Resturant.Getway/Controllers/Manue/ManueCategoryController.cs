using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Manue;
using Resturant.Services.Manue;

namespace Resturant.Getway.Controllers.Manue
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManueCategoryController : BaseController
    {
        private readonly IManuesService _iManueService;
        public ManueCategoryController(IManuesService service,IResponseDTO response,IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _iManueService = service;
        }

        [HttpPost]
        public async Task<IResponseDTO> CreateCategoryManue([FromBody] createandUpdateCatgoryDto createandUpdateCatgoryDto)
        {
            _response = await _iManueService.CreateCategoryManue(createandUpdateCatgoryDto);
            return _response;
        }

        [HttpPut("{id}")]
        public async Task<IResponseDTO> UpdateCategoryManue([FromBody] createandUpdateCatgoryDto createandUpdateCatgoryDto, [FromRoute] Guid id)
        {
            _response = await _iManueService.UpdateCatgory(id, createandUpdateCatgoryDto);
            return _response;
        }
        [HttpDelete("{id}/{Manuid}")]
        public async Task<IResponseDTO> DeleteCategoryManue([FromRoute] Guid id, [FromRoute] Guid Manuid)
        {
            _response = await _iManueService.Deletcatgory(id, Manuid);
            return _response;
        }
        [HttpGet]
        public async Task<IEnumerable<categoryforreturnDto>> GetAllCategoryManue()
        {
            var AllManue = await _iManueService.GetAllCategory();
            return AllManue;
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<categoryforreturnDto>> GetManueById([FromRoute] Guid id)
        {
            var Manue = await _iManueService.GetCategoryManuerByid(id);
            return Manue;
        }

    }
}
