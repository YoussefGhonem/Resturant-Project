using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Cover;
using Resturant.DTO.Business.Happining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.Happining
{
    public interface IHappining
    {
        Task<IResponseDTO> CreateHappining(CreateAndUpdateHappiningDto createAndUpdateHappiningDto);
        Task<IResponseDTO> DeleteHappining(Guid Id);
        PaginationResult<HappiningReturnDto> GetAllHappining(BaseFilterDto filterDto, string serverRootPath);
    }
}
