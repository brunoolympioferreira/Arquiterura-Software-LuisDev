using AwesomeShopPatterns.API.Application;
using AwesomeShopPatterns.API.Application.Models;
using AwesomeShopPatterns.API.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShopPatterns.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        [HttpGet("payment-methods-old/{paymentMethod}")]
        public IActionResult GetPaymentMethodDetailsOld(PaymentMethod? paymentMethod)
        {
            PaymentMethodViewModel model;

            if (paymentMethod == PaymentMethod.CreditCard)
                model = new PaymentMethodViewModel("Sobre o Cartão de Crédito.", 1, null);
            else if (paymentMethod == PaymentMethod.PaymentSlip)
                model = new PaymentMethodViewModel("Sobre o Boleto.", 10, 1000);
            else if (paymentMethod == PaymentMethod.PayPal)
                model = new PaymentMethodViewModel("Sobre o PayPal.", 16.5m, null);
            else
                return BadRequest("Não foi passada uma forma de pagamento válida.");

            return Ok(model);
        }

        [HttpGet("payment-methods/{paymentMethod}")]
        public IActionResult GetPaymentMethodDetails(PaymentMethod paymentMethod,
            [FromServices] PaymentMethodsFactory factory)
        {
            if (paymentMethod == PaymentMethod.Unknown)
                return BadRequest();

            var model = factory.GetPaymentMethod(paymentMethod);

            return Ok(model);
        }
    }
}
