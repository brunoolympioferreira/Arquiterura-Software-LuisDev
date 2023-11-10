using AwesomeShopPatterns.API.Core.Entities;
using AwesomeShopPatterns.API.Infrastructure;
using AwesomeShopPatterns.API.Infrastructure.Proxies;
using formacao_arquitetura.Application.Models;
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

        [HttpGet("report-notify-blocked-customers")]
        public IActionResult NotifyBlockedCustomerEmail([FromServices] ICustomerRepository repository) {
            var blockedCustomers = repository.GetBlockedCustomers();

            var query = new CustomersToNotifyQueryModel(blockedCustomers, "LuisDev");
            
            foreach (var customer in query) {
                Console.WriteLine($"Customer: {customer.Key}, Email: {customer.Value}");
            }

            Console.WriteLine($"Utilizando acesso direto: {query["Fulano 1"]}");
            
            return Ok();
        }
    }
}
