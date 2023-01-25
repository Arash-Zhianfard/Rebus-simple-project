using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;
using Rebus_simple_project.Models;

namespace Rebus_simple_project.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly ILogger<EmailController> _logger;
        private readonly IBus _bus;

        public EmailController(ILogger<EmailController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] EmailRequest emailRequest)
        {
            return null;
        }
    }
}