using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AwesomeShopPatterns.API.Application.Models;
using AwesomeShopPatterns.API.Core.Enums;
using AwesomeShopPatterns.API.Infrastructure;
using AwesomeShopPatterns.API.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShopPatterns.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(
            OrderInputModel model
            ) {
            var customerData = model.Customer.ReturnDataAsString();

            var customerCopy = model.Customer.Clone();
            var customerCopyData = (customerCopy as CustomerInputModel).ReturnDataAsString();

            return Ok(new { customerData, customerCopyData });
        }
    }
}