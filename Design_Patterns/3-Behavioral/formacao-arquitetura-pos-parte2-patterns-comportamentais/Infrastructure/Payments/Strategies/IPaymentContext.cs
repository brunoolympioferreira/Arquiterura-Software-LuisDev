using AwesomeShopPatterns.API.Application.Models;

namespace AwesomeShopPatterns.API.Infrastructure.Payments.Strategies
{
    public interface IPaymentContext
    {
        object Process(OrderInputModel model);
        IPaymentContext SetStrategy(IPaymentStrategy strategy);
    }
}
