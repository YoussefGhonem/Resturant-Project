using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Manue;
using Resturant.Services.EventType;
using Resturant.Services.Manue;
namespace Resturant.Getway.Controllers.Manue
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManueController : BaseController
    {
        private readonly IManuesService _iManueService;

        public ManueController(IManuesService service,IResponseDTO response,IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _iManueService = service;
        }
        [HttpPost]
        public async Task<IResponseDTO> CreateManue([FromBody] CreateAndUpdateManueDto createAndUpdateManueDto)
        {
            _response = await _iManueService.CreateManue(createAndUpdateManueDto);
            return _response;
        }

        [HttpPut("{id}")]
        public async Task<IResponseDTO> UpdateManue([FromBody] CreateAndUpdateManueDto createAndUpdateManueDto, [FromRoute] Guid id)
        {
            _response = await _iManueService.UpdateManue(id,createAndUpdateManueDto);

            return _response;
        }
        [HttpDelete("{id}")]
         public async Task<IResponseDTO> DeleteManue([FromRoute] Guid id)
        {
            _response = await _iManueService.DeletManue(id);
            return _response;
        }
        [HttpGet]
        public async Task<IEnumerable<manuetoreturnDto>> GetAllManue()
        {
            var AllManue= await _iManueService.GetallManue();
            return AllManue;
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<manuetoreturnDto>> GetManueById([FromRoute] Guid id)
        {
            var Manue = await _iManueService.GetManuerByid(id);
            return Manue;
        }

    }
}
