using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftZone.BLL;
using SoftZone.Common;

namespace SotfZone.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        /// <summary>
        /// Gets all restaurants or filters them by optional city id with pagination support.
        /// </summary>
        /// <param name="cityId">Optional City Id.</param>
        /// <param name="paginationParams">Pagination parameters (PageNumber and PageSize).</param>
        /// <returns>Paged list of restaurants.</returns>
        [HttpGet]
        public async Task<ActionResult<GeneralResult<PagedResult<RestaurantResponseDto>>>> GetRestaurants([FromQuery] int? cityId, [FromQuery] PaginationParams paginationParams)
        {
            var result = await _restaurantService.GetAllOrFilteredRestaurantsAsync(cityId, paginationParams);
            return Ok(GeneralResult<PagedResult<RestaurantResponseDto>>.SuccessResult(result, "Restaurants retrieved successfully."));
        }

        /// <summary>
        /// Gets restaurant details by its id.
        /// </summary>
        /// <param name="id">Restaurant Id.</param>
        /// <returns>Restaurant details.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralResult<RestaurantResponseDto>>> GetRestaurantById(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound(GeneralResult.NotFoundResult("Restaurant not found."));
            }
            return Ok(GeneralResult<RestaurantResponseDto>.SuccessResult(restaurant, "Restaurant retrieved successfully."));
        }

        /// <summary>
        /// Gets menu items for a specific restaurant with pagination support.
        /// </summary>
        /// <param name="restaurantId">Restaurant Id.</param>
        /// <param name="paginationParams">Pagination parameters (PageNumber and PageSize).</param>
        /// <returns>Paged list of menu items.</returns>
        [HttpGet("{restaurantId}/menu")]
        public async Task<ActionResult<GeneralResult<PagedResult<MenuItemResponseDto>>>> GetRestaurantMenu(int restaurantId, [FromQuery] PaginationParams paginationParams)
        {
            var result = await _restaurantService.GetRestaurantMenuAsync(restaurantId, paginationParams);
            return Ok(GeneralResult<PagedResult<MenuItemResponseDto>>.SuccessResult(result, "Menu items retrieved successfully."));
        }
    }
}
