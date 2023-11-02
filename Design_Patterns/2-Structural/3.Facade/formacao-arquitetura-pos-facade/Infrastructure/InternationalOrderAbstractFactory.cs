using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeShopPatterns.API.Core.Enums;
using AwesomeShopPatterns.API.Infrastructure.Deliveries;
using AwesomeShopPatterns.API.Infrastructure.Payments;

namespace AwesomeShopPatterns.API.Infrastructure
{
    public class InternationalOrderAbstractFactory : IOrderAbstractFactory
    {
        public readonly IPaymentService _paymentService;
        public readonly IDeliveryService _deliveryService;
        public InternationalOrderAbstractFactory(
            CreditCardService creditCardService,
            InternationalDeliveryService internationalDeliveryService)
        {
            _paymentService = creditCardService;
            _deliveryService = internationalDeliveryService;
        }

        public IDeliveryService GetDeliveryService()
        {
            return _deliveryService;
        }

        public IPaymentService GetPaymentService(PaymentMethod method)
        {
            return _paymentService;
        }
    }
}