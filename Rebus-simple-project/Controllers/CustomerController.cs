using Microsoft.AspNetCore.Mvc;
using Rebus_simple_project.Models;
using System.Diagnostics;

namespace Rebus_simple_project.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> Add([FromBody]NewCustomer newCustomer)        
        {

            return null;
        }         
    }
}