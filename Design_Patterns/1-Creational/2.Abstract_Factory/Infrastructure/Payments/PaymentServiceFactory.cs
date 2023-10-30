using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeShopPatterns.API.Core.Enums;

namespace AwesomeShopPatterns.API.Infrastructure.Payments
{
    public class PaymentServiceFactory : IPaymentServiceFactory
    {
        private readonly CreditCardService _creditCardService;
        private readonly PaymentSlipService _paymentSlipService;

        public PaymentServiceFactory(
            CreditCardService creditCardService, 
            PaymentSlipService paymentSlipService
            )
        {
            _creditCardService = creditCardService;
            _paymentSlipService = paymentSlipService;
        }

        public IPaymentService GetService(PaymentMethod paymentMethod)
        {
            IPaymentService paymentService;

            switch (paymentMethod) {
                case PaymentMethod.CreditCard: 
                    paymentService = _creditCardService;
                    
                    break;
                case PaymentMethod.PaymentSlip:
                    paymentService = _paymentSlipService;

                    break;
                default:
                    throw new InvalidOperationException();
            }

            return paymentService;
        }
    }
}