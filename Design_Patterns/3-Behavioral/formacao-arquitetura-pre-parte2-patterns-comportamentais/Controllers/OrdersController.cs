using AwesomeShopPatterns.API.Application.Configurations;
using AwesomeShopPatterns.API.Application.Models;
using AwesomeShopPatterns.API.Infrastructure;
using AwesomeShopPatterns.API.Infrastructure.Payments;
using AwesomeShopPatterns.API.Infrastructure.Products;
using formacao_arquitetura.Application.ChainOfResponsibility;
using formacao_arquitetura.Infrastructure.Payments.Models;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShopPatterns.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        [HttpPost("singleton")]
        public IActionResult PostSingleton(
            OrderInputModel model
            ) {
            return Ok(BusinessHours.GetInstance());
        }

        [HttpPost("not-using-chain")]
        public IActionResult Post(
            OrderInputModel model,
            [FromServices] IProductRepository productRepository,
            [FromServices] IPaymentFraudCheckService fraudCheckService,
            [FromServices] ICustomerRepository customerRepository)
        {
            var itemsDictionary = model.Items.ToDictionary(d => d.ProductId, d => d.Quantity);
            var hasStock = productRepository.HasStock(itemsDictionary);
            
            if (!hasStock)
                return BadRequest();

            var customer = customerRepository.GetCustomerById(model.Customer.Id);
            var customerAllowedToBuy = customer.IsAllowedToBuy();

            if (!customerAllowedToBuy)
                return BadRequest();

            var isFraud = fraudCheckService.IsFraud(model);

            if (isFraud)
                return BadRequest();

            return NoContent();
        }

        [HttpPost("using-chain")]
        public IActionResult PostWithChain(
            OrderInputModel model,
            [FromServices] IProductRepository productRepository,
            [FromServices] IPaymentFraudCheckService fraudCheckService,
            [FromServices] ICustomerRepository customerRepository)
        {
            var validateCustomerHandler = new ValidateCustomerHandler(customerRepository);
            var validateStockHandler = new ValidateStockHandler(productRepository);
            var checkForFraudHandler = new CheckForFraudHandler(fraudCheckService);

            validateCustomerHandler
                .SetNext(validateStockHandler)
                .SetNext(checkForFraudHandler);
            
            bool success = validateCustomerHandler.Handle(model);
            
            if (!success)
                return BadRequest();
                
            return NoContent();
        }

        [HttpPost("payment-using-strategy")]
        public IActionResult ProcessPaymentWithStrategy(OrderInputModel model)
        {
            return Ok();
        }


        [HttpPost("not-using-command")]
        public IActionResult NotPostUsingCommand(
            OrderInputModel model,
            [FromServices] IPaymentFraudCheckService fraudCheckService)
        {
            var total = model.Items.Sum(i => i.Price * i.Quantity);

            var isFraud = fraudCheckService.IsFraudV2(total, model.Customer.Id, model.Customer.FullName, model.Customer.Document);
            
            if (isFraud)
                return BadRequest();

            var message = new {
                total,
                customerId = model.Customer.Id,
                fullName = model.Customer.FullName,
                document = model.Customer.Document 
            };

            // Chamar um serviço de mensageria para enviar esse objeto como JSON
            // Guardar um log desse objeto

            return NoContent();
        }

        [HttpPost("using-command")]
        public IActionResult PostUsingCommand(
            OrderInputModel model,
            [FromServices] IPaymentFraudCheckService fraudCheckService)
        {
            var total = model.Items.Sum(i => i.Price * i.Quantity);
            var command = new FraudCheckModel(total, model.Customer.Id, model.Customer.FullName, model.Customer.Document);

            var isFraud = fraudCheckService.IsFraudV2UsingCommand(command);

            if (isFraud)
                return BadRequest();
                
            // Chamar um serviço de mensageria para enviar esse objeto como JSON
            // Guardar um log desse objeto

            return NoContent();
        }

        public IActionResult OrderState(OrderInputModel model)
        {
            return NoContent();
        }

    }
}