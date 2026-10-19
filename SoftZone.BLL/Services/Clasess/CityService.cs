using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftZone.Common;
using SoftZone.DAL;

namespace SoftZone.BLL
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResult<CityResponseDto>> GetAllCitiesAsync(PaginationParams paginationParams)
        {
            var query = _unitOfWork.Cities.GetQueryable();

            int totalCount = await query.CountAsync();

            var items = await query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            var mappedItems = _mapper.Map<IEnumerable<CityResponseDto>>(items);

            return new PagedResult<CityResponseDto>
            {
                Items = mappedItems,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalCount = totalCount
            };
        }
    }
}
