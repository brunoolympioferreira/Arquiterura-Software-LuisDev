using AwesomeShopPatterns.API.Application.Models;
using AwesomeShopPatterns.API.Core.Entities;
using formacao_arquitetura.Infrastructure.Payments.Models;

namespace AwesomeShopPatterns.API.Infrastructure.Payments
{
    public interface IPaymentFraudCheckService
    {
        bool IsFraud(OrderInputModel model);
        bool IsFraudV2(decimal totalAmount, Guid customerId, string customerName, string document);
        bool IsFraudV2UsingCommand(FraudCheckModel command);
    }

    public class PaymentFraudCheckService : IPaymentFraudCheckService
    {
        public bool IsFraud(OrderInputModel model)
        {
            return false;
        }

        public bool IsFraudV2(decimal totalAmount, Guid customerId, string customerName, string document) {
            return false;
        }

        public bool IsFraudV2UsingCommand(FraudCheckModel command)
        {
            return false;
        }
    }
}
