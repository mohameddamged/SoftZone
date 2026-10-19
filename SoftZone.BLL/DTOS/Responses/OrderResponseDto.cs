namespace SoftZone.BLL
{
    public class OrderResponseDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Message { get; set; } = "Order placed successfully! It will arrive as soon as possible.";
    }
}
