using AwesomeShopPatterns.API.Core.Enums;
using System.Reflection;

namespace AwesomeShopPatterns.API.Infrastructure.Payments.Strategies
{
    public class PaymentStrategyFactory : IPaymentStrategyFactory
    {
        public IPaymentStrategy GetStrategy(PaymentMethod paymentMethod)
        {
            IPaymentStrategy strategy;

            if (paymentMethod == PaymentMethod.PaymentSlip)
            {
                strategy = new PaymentSlipStrategy();
            }
            else
            {
                strategy = new CreditCardStrategy();
            }

            return strategy;
        }
    }
}
