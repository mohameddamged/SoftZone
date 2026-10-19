using AutoMapper;
using SoftZone.DAL;

namespace SoftZone.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // City Mapping
            CreateMap<City, CityResponseDto>().ReverseMap();

            // Restaurant Mapping
            CreateMap<Restaurant, RestaurantResponseDto>().ReverseMap();

            // MenuItem Mapping
            CreateMap<MenuItem, MenuItemResponseDto>().ReverseMap();

            // Order Mapping
            CreateMap<CreateOrderRequestDto, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

            CreateMap<OrderItemRequestDto, OrderItem>();
        }
    }
}
