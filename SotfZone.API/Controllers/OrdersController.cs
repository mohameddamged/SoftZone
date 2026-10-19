using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftZone.BLL;
using SoftZone.Common;

namespace SotfZone.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Creates a new order (Checkout) and calculates total price.
        /// </summary>
        /// <param name="request">Order checkout details.</param>
        /// <returns>Created order summary.</returns>
        [HttpPost("checkout")]
        public async Task<ActionResult<GeneralResult<OrderResponseDto>>> Checkout([FromBody] CreateOrderRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GeneralResult.FailResult("Invalid order data provided."));
            }

            try
            {
                var result = await _orderService.CreateOrderAsync(request);
                return Ok(GeneralResult<OrderResponseDto>.SuccessResult(result, "Order placed successfully!"));
            }
            catch (Exception ex)
            {
                return BadRequest(GeneralResult.FailResult(ex.Message));
            }
        }
    }
}
