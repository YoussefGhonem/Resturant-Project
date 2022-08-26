using Resturant.Core.Interfaces;
using Resturant.DTO.Business.SiteLocation;

namespace Resturant.Services.SiteLocation
{
    public interface ISiteLocationService
    {

        Task<IResponseDTO> Update(UpdateSiteLocationDto options);
        Task<SiteLocationDetailsDto> GetDetails();

    }
}
