using Microsoft.AspNetCore.Mvc;
using PaymentService.Models;
using Rebus.Bus;
using System.Diagnostics;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    public class PayamentController : Controller
    {
        private readonly ILogger<PayamentController> _logger;
        private readonly IBus _bus;

        public PayamentController(ILogger<PayamentController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] PaymentRequst newCustomer)
        {
            return null;
        }
    }
}