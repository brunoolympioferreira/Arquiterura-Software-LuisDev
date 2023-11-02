using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeShopPatterns.API.Application.Models;
using AwesomeShopPatterns.API.Infrastructure.Integrations;
using AwesomeShopPatterns.API.Infrastructure.Payments;

namespace AwesomeShopPatterns.API.Infrastructure.Payments.Decorators
{
    public class PaymentServiceDecorator : IPaymentService
    {
        private IPaymentService _paymentService;
        private readonly ICoreCrmIntegrationService _crmService;

        public PaymentServiceDecorator(IPaymentService paymentService, ICoreCrmIntegrationService crmService)
        {
            _paymentService = paymentService;
            _crmService = crmService;
        }

        public object Process(OrderInputModel model)
        {
            var result = _paymentService.Process(model);

            _crmService.Sync(model);
            
            return result;
        }
    }
}