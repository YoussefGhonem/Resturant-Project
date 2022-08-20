using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.DTO.Business.Cover;
using Resturant.DTO.Business.Gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.Cover
{
    public interface ICover
    {
        Task<IResponseDTO> UploadImageCover(CreateAndUpdateCoverDto createAndUpdateCoverDto);
        Task<IResponseDTO> DeleteImageCover(Guid Id);
        PaginationResult<CoverReturnDro> GetAllCover(BaseFilterDto filterDto, string serverRootPath);
    }
}
