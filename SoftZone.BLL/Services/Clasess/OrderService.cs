using AutoMapper;
using SoftZone.DAL;

namespace SoftZone.BLL
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderResponseDto> CreateOrderAsync(CreateOrderRequestDto request)
        {
            // Start Transaction for safety
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                decimal totalAmount = 0;
                var orderItemsList = new List<OrderItem>();

                // Validate and calculate prices for each item
                foreach (var itemDto in request.OrderItems)
                {
                    var menuItem = await _unitOfWork.MenuItems.GetByIdAsync(itemDto.MenuItemId);
                    if (menuItem == null)
                    {
                        throw new Exception($"Menu item with ID {itemDto.MenuItemId} was not found.");
                    }

                    decimal itemTotal = menuItem.Price * itemDto.Quantity;
                    totalAmount += itemTotal;

                    orderItemsList.Add(new OrderItem
                    {
                        MenuItemId = menuItem.Id,
                        Quantity = itemDto.Quantity,
                        UnitPrice = menuItem.Price,
                        TotalPrice = itemTotal
                    });
                }

                // Map and Create Order Entity
                var order = new Order
                {
                    RestaurantId = request.RestaurantId,
                    CustomerName = request.CustomerName,
                    CustomerPhone = request.CustomerPhone,
                    CustomerEmail = request.CustomerEmail,
                    CustomerAddress = request.CustomerAddress,
                    TotalAmount = totalAmount,
                    OrderDate = DateTime.UtcNow,
                    OrderItems = orderItemsList
                };

                await _unitOfWork.Orders.AddAsync(order);
                await _unitOfWork.SaveChangesAsync();

                // Commit Transaction
                await _unitOfWork.CommitTransactionAsync();

                return new OrderResponseDto
                {
                    OrderId = order.Id,
                    OrderDate = order.OrderDate,
                    CustomerName = order.CustomerName,
                    TotalAmount = order.TotalAmount,
                    Message = "Order placed successfully! It will arrive as soon as possible."
                };
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
