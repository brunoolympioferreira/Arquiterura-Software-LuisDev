using AwesomeShopPatterns.API.Application.Models;

namespace AwesomeShopPatterns.API.Infrastructure.Payments.Strategies
{
    public class CreditCardStrategy : IPaymentStrategy
    {
        public object Process(OrderInputModel model)
        {
            return "Transação aprovada.";
        }
    }
}
