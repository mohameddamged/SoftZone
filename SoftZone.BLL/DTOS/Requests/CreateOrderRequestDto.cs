namespace SoftZone.BLL
{
    public class CreateOrderRequestDto
    {
        public int RestaurantId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public List<OrderItemRequestDto> OrderItems { get; set; } = new List<OrderItemRequestDto>();
    }
}
