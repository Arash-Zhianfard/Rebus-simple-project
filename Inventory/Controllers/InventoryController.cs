using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;
using System.Diagnostics;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IBus _bus;

        public InventoryController(ILogger<InventoryController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] InventoryUpdateRequst newCustomer)
        {
            return null;
        }
    }
}