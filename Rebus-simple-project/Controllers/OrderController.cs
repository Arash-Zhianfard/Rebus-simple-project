using Common.Models;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using Rebus.Bus;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IBus _bus;

        public OrderController(ILogger<OrderController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] OrderRequest newCustomer)
        {
            var newOrder = new Order();
            using (AppContext appContext = new())
            {
                appContext.Orders.Add(newOrder);
                appContext.SaveChanges();
            }

            await _bus.Send(new OrderCreated() { OrderId = newOrder.Id });

            return Ok();
        }
    }
}