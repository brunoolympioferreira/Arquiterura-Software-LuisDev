using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeShopPatterns.API.Application.Models;

namespace AwesomeShopPatterns.API.Infrastructure.Payments
{
    public interface IPaymentService
    {
        object Process(OrderInputModel model);
    }
}