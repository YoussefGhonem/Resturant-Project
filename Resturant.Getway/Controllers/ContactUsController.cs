using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.ContactUs;
using Resturant.DTO.Business.Jop;
using Resturant.Services.ContectUs;
using Resturant.Services.Jop;

namespace Resturant.Getway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : BaseController
    {
        private readonly IContactUs _services;

        public ContactUsController(IContactUs service,IResponseDTO response,IHttpContextAccessor httpContextAccessor) : base(response, httpContextAccessor)
        {
            _services = service;
        }
        [HttpGet]
        public PaginationResult<ContactUsReturnDto> GetAllContactUsSend([FromQuery] BaseFilterDto filterDto)
        {
            return _services.GetAllContactUs(filterDto);
        }
        [HttpPost]
        public async Task<IResponseDTO> SubmitInConatactUsForm([FromBody] CreateContactUsDto createContactUsDto)
        {
            return await _services.CreateContactUs(createContactUsDto);
        }
        [HttpDelete("{id}")]
        public async Task<IResponseDTO> DeletContactUsRequest(Guid id)
        {
            return await _services.DeletContactUs(id);
        }

    }
}
