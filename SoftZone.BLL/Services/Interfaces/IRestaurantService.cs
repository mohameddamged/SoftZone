using SoftZone.Common;

namespace SoftZone.BLL
{
    public interface IRestaurantService
    {
        //Task<PagedResult<RestaurantResponseDto>> GetRestaurantsByCityIdAsync(int cityId, PaginationParams paginationParams);
        Task<PagedResult<RestaurantResponseDto>> GetAllOrFilteredRestaurantsAsync(int? cityId, PaginationParams paginationParams);
        Task<RestaurantResponseDto?> GetRestaurantByIdAsync(int restaurantId);
        Task<PagedResult<MenuItemResponseDto>> GetRestaurantMenuAsync(int restaurantId, PaginationParams paginationParams);
    }
}
