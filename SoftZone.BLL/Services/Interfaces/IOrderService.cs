namespace SoftZone.BLL
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrderAsync(CreateOrderRequestDto request);
    }
}
