using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeShopPatterns.API.Core.Enums;
using AwesomeShopPatterns.API.Infrastructure.Integrations;
using AwesomeShopPatterns.API.Infrastructure.Payments.Decorators;

namespace AwesomeShopPatterns.API.Infrastructure.Payments
{
    public class PaymentServiceFactory : IPaymentServiceFactory
    {
        private readonly CreditCardService _creditCardService;
        private readonly PaymentSlipService _paymentSlipService;
        private readonly ICoreCrmIntegrationService _crmService;

        public PaymentServiceFactory(
            CreditCardService creditCardService, 
            PaymentSlipService paymentSlipService,
            ICoreCrmIntegrationService crmService
            )
        {
            _creditCardService = creditCardService;
            _paymentSlipService = paymentSlipService;
            _crmService = crmService;
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

            return new PaymentServiceDecorator(paymentService, _crmService);
        }
    }
}