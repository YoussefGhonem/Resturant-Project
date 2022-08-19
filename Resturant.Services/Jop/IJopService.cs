using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Gallery;
using Resturant.DTO.Business.Jop;
using Resturant.DTO.Business.PrivateDining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.Jop
{
    public interface IJopService
    {
        Task<IResponseDTO> SubmitInJopFormCreate(CreateJopDto createJopDto);
        Task<IResponseDTO> DeleteSubmitedJop(Guid Id);
        PaginationResult<jopForReturnDto> GetAll(BaseFilterDto filterDto);
    }
}
