using Resturant.Core.Interfaces;
using Resturant.DTO.Business.WhyUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.WhyUs
{
    public interface IWhyUs
    {
        Task<IResponseDTO> CreateWhyUs(List<CreateAndUpdateWhyUsDto> options);
        Task<IResponseDTO> UpdateWhyUs(CreateAndUpdateWhyUsDto options, Guid Id);
        Task<IResponseDTO> DeleteWhyUs(Guid Id);
        Task<IEnumerable<ReturnWhyUsDto>> GetAllWhyUs();
    }
}
