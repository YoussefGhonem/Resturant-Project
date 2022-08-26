using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.ContactUs;
using Resturant.DTO.Business.WhyUs;
using Resturant.Services.ContectUs;
using Resturant.Services.WhyUs;
using System.Collections;

namespace Resturant.Getway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhyUsController : BaseController
    {
        private readonly IWhyUs _services;

        public WhyUsController(IWhyUs service, IResponseDTO response, IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _services = service;
        }
        [HttpGet]
        public async Task<IEnumerable<ReturnWhyUsDto>> GetAllContactUsSend()
        {
            return await _services.GetAllWhyUs();
        }
        
        [HttpPost]
        public async Task<IResponseDTO> CreateWhyUs([FromBody] List<CreateAndUpdateWhyUsDto> createAndUpdateWhyUsDto)
        {
            return await _services.CreateWhyUs(createAndUpdateWhyUsDto);
        }
        [HttpDelete("{id}")]
        public async Task<IResponseDTO> DeletWhyUsQuestions([FromRoute]Guid id)
        {
            return await _services.DeleteWhyUs(id);
        }
        [HttpPut("{id}")]
        public async Task<IResponseDTO> CreateWhyUs([FromBody] CreateAndUpdateWhyUsDto createAndUpdateWhyUsDto,[FromRoute]Guid id)
        {
            return await _services.UpdateWhyUs(createAndUpdateWhyUsDto, id);
        }
    }
}
