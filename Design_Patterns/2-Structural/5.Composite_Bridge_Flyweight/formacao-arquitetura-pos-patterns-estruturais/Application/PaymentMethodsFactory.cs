using AwesomeShopPatterns.API.Application.Models;
using AwesomeShopPatterns.API.Core.Enums;

namespace AwesomeShopPatterns.API.Application
{
    // Flyweight Factory
    public class PaymentMethodsFactory
    {
        private Dictionary<PaymentMethod, PaymentMethodViewModel> _dictionary;

        public PaymentMethodsFactory()
        {
            _dictionary = new Dictionary<PaymentMethod, PaymentMethodViewModel>
            {
                { PaymentMethod.CreditCard, new PaymentMethodViewModel("Sobre o Cartão de Crédito.", 1, null) },
                { PaymentMethod.PaymentSlip, new PaymentMethodViewModel("Sobre o Boleto.", 10, 1000) },
                { PaymentMethod.PayPal, new PaymentMethodViewModel("Sobre o PayPal.", 16.5m, null) }
            };
        }

        public PaymentMethodViewModel GetPaymentMethod(PaymentMethod paymentMethod)
        {
            return _dictionary[paymentMethod];
        }
    }
}
