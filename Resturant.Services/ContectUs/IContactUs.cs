using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.ContactUs;
using Resturant.DTO.Business.Jop;

namespace Resturant.Services.ContectUs
{
    public interface IContactUs
    {
        Task<IResponseDTO> CreateContactUs(CreateContactUsDto dreateContactUsDto);
        Task<IResponseDTO> DeletContactUs(Guid Id);
        PaginationResult<ContactUsReturnDto> GetAllContactUs(BaseFilterDto filterDto);
    }
}
