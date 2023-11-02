using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeShopPatterns.API.Infrastructure.Payments.Models;
using AwesomeShopPatterns.API.Application.Models;

namespace AwesomeShopPatterns.API.Infrastructure.Payments
{
    public interface IExternalPaymentSlipService
    {
        ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model);
    }

    public class ExternalPaymentSlipService : IExternalPaymentSlipService
    {
        public ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model)
        {
            throw new NotImplementedException();
        }
    }

    public class ExternalPaymentSlipServiceDecorator : IExternalPaymentSlipService
    {
        private readonly IExternalPaymentSlipService _externalPaymentSlipService;
        public ExternalPaymentSlipServiceDecorator(ExternalPaymentSlipService externalPaymentSlipService)
        {
            _externalPaymentSlipService = externalPaymentSlipService;
        }

        public ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model)
        {
            Console.WriteLine("Extendendo IExternalPaymentSlipService");

            return _externalPaymentSlipService.GeneratePaymentSlip(model);
        }
    }
}