using AwesomeShopPatterns.API.Application.Models;

namespace AwesomeShopPatterns.API.Infrastructure.Payments.Strategies
{
    public interface IPaymentStrategy
    {
        object Process(OrderInputModel model);
    }
}
