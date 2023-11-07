using AwesomeShopPatterns.API.Core.Enums;
using AwesomeShopPatterns.API.Infrastructure.Deliveries;
using AwesomeShopPatterns.API.Infrastructure.Payments;

namespace AwesomeShopPatterns.API.Infrastructure
{
    public class NationalOrderAbstractFactory : IOrderAbstractFactory
    {
        private readonly NationalDeliveryService _nationalDeliveryService;
        private readonly IPaymentServiceFactory _paymentServiceFactory;

        public NationalOrderAbstractFactory(
            NationalDeliveryService nationalDeliveryService,
            IPaymentServiceFactory paymentServiceFactory)
        {
            _nationalDeliveryService = nationalDeliveryService;
            _paymentServiceFactory = paymentServiceFactory;
        }

        public IDeliveryService GetDeliveryService()
        {
            return _nationalDeliveryService;
        }

        public IPaymentService GetPaymentService(PaymentMethod method)
        {
            return _paymentServiceFactory.GetService(method);
        }
    }
}