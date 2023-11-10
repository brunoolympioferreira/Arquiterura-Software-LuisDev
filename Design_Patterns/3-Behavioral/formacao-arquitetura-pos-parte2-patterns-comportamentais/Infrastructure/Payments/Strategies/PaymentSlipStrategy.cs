using AwesomeShopPatterns.API.Application.Models;

namespace AwesomeShopPatterns.API.Infrastructure.Payments.Strategies
{
    public class PaymentSlipStrategy : IPaymentStrategy
    {
        public object Process(OrderInputModel model)
        {
            return "Dados do Boleto: xyz";
        }
    }
}
