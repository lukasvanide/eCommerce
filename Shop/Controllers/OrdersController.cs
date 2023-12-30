using Microsoft.AspNetCore.Mvc;
using Shop.Aplication.Services.OrderService;
using Shop.Aplication.Services.ProductCartService;

namespace Shop.Controllers
{
    [Route("api/OrderItems")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> CheckoutOrders(int userId)
        {

            await _orderService.Checkout(userId);

            return Ok();

        }

        [HttpGet("orders/{userId}")]
        public async Task<IActionResult> GetOrders(int userId)
        {
            var orders = await _orderService.GetOrdersByUserId(userId);

            return Ok(orders);



        }
    }
}
