using AwesomeShopPatterns.API.Core.Entities;
using AwesomeShopPatterns.API.Infrastructure;
using AwesomeShopPatterns.API.Infrastructure.Proxies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AwesomeShopPatterns.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet("get-blocked-customers")]
        public IActionResult GetBlockedCustomers([FromServices] CustomerRepositoryProxy proxy)
        {
            var blockedCustomers = proxy.GetBlockedCustomers();

            if (blockedCustomers == null)
                return Unauthorized();

            return Ok(blockedCustomers);
        }
    }
}
