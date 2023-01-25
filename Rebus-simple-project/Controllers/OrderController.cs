using Common.Models;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using Rebus.Bus;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IBus _bus;

        public OrderController(ILogger<OrderController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderRequest newCustomer)
        {
            var newOrder = new Order();
            using (AppContext appContext = new())
            {
                appContext.Orders.Add(newOrder);
                appContext.SaveChanges();
            }

            await _bus.Send(new OnNewOrder() { OderId = newOrder.Id });

            return Ok();
        }
    }
}