using Microsoft.AspNetCore.Mvc;
using Rebus_simple_project.Models;
using System.Diagnostics;

namespace Rebus_simple_project.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> Add([FromBody]NewOrder newCustomer)        
        {
            return null;
        }         
    }
}