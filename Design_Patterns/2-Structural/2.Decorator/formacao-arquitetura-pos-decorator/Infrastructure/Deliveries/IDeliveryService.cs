using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeShopPatterns.API.Application.Models;

namespace AwesomeShopPatterns.API.Infrastructure.Deliveries
{
    public interface IDeliveryService
    {
        void Deliver(OrderInputModel model);
    }
}