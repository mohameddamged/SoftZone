using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftZone.Common;
using SoftZone.DAL;

namespace SoftZone.BLL
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RestaurantService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public async Task<PagedResult<RestaurantResponseDto>> GetRestaurantsByCityIdAsync(int cityId, PaginationParams paginationParams)
        //{
        //    var query = _unitOfWork.Restaurants.GetQueryable().Where(r => r.CityId == cityId);

        //    int totalCount = await query.CountAsync();

        //    var items = await query
        //        .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
        //        .Take(paginationParams.PageSize)
        //        .ToListAsync();

        //    var mappedItems = _mapper.Map<IEnumerable<RestaurantResponseDto>>(items);

        //    return new PagedResult<RestaurantResponseDto>
        //    {
        //        Items = mappedItems,
        //        PageNumber = paginationParams.PageNumber,
        //        PageSize = paginationParams.PageSize,
        //        TotalCount = totalCount
        //    };
        //}

        public async Task<PagedResult<RestaurantResponseDto>> GetAllOrFilteredRestaurantsAsync(int? cityId, PaginationParams paginationParams)
        {
            var query = _unitOfWork.Restaurants.GetQueryable();

            if (cityId.HasValue && cityId.Value > 0)
            {
                query = query.Where(r => r.CityId == cityId.Value);
            }

            int totalCount = await query.CountAsync();

            var items = await query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            var mappedItems = _mapper.Map<IEnumerable<RestaurantResponseDto>>(items);

            return new PagedResult<RestaurantResponseDto>
            {
                Items = mappedItems,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalCount = totalCount
            };
        }
        public async Task<RestaurantResponseDto?> GetRestaurantByIdAsync(int restaurantId)
        {
            var restaurant = await _unitOfWork.Restaurants.GetByIdAsync(restaurantId);
            if (restaurant == null) return null;
            return _mapper.Map<RestaurantResponseDto>(restaurant);
        }

        public async Task<PagedResult<MenuItemResponseDto>> GetRestaurantMenuAsync(int restaurantId, PaginationParams paginationParams)
        {
            var query = _unitOfWork.MenuItems.GetQueryable().Where(m => m.RestaurantId == restaurantId);

            int totalCount = await query.CountAsync();

            var items = await query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            var mappedItems = _mapper.Map<IEnumerable<MenuItemResponseDto>>(items);

            return new PagedResult<MenuItemResponseDto>
            {
                Items = mappedItems,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalCount = totalCount
            };
        }
    }
}
