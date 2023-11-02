using AwesomeShopPatterns.API.Core.Enums;
using AwesomeShopPatterns.API.Infrastructure.Deliveries;
using AwesomeShopPatterns.API.Infrastructure.Payments;

namespace AwesomeShopPatterns.API.Infrastructure
{
    public interface IOrderAbstractFactory
    {
        IPaymentService GetPaymentService(PaymentMethod method);
        IDeliveryService GetDeliveryService();
    }
}