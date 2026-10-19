using SoftZone.Common;

namespace SoftZone.BLL
{
    public interface ICityService
    {
        Task<PagedResult<CityResponseDto>> GetAllCitiesAsync(PaginationParams paginationParams);
    }
}
