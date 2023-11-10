using AwesomeShopPatterns.API.Core.Enums;

namespace AwesomeShopPatterns.API.Infrastructure.Payments.Strategies
{
    public interface IPaymentStrategyFactory
    {
        IPaymentStrategy GetStrategy(PaymentMethod paymentMethod);
    }
}
