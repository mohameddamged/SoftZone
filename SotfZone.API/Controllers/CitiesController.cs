using Microsoft.AspNetCore.Mvc;
using SoftZone.BLL;
using SoftZone.Common;

namespace SotfZone.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }
        /// <summary>
        /// Gets all available cities with pagination support.
        /// </summary>
        /// <param name="paginationParams">Pagination parameters (PageNumber and PageSize).</param>
        /// <returns>Paged list of cities.</returns>
        [HttpGet]
        public async Task<ActionResult<GeneralResult<PagedResult<CityResponseDto>>>> GetAllCities([FromQuery] PaginationParams paginationParams)
        {
            var result = await _cityService.GetAllCitiesAsync(paginationParams);
            return Ok(GeneralResult<PagedResult<CityResponseDto>>.SuccessResult(result, "Cities retrieved successfully."));
        }
    }
}
