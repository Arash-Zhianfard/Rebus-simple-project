using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using Rebus.Bus;
using System.Diagnostics;

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


            await _bus.Send(newCustomer);
            return Ok();
        }
    }
}