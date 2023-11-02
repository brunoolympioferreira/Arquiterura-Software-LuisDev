namespace AwesomeShopPatterns.API.Infrastructure.Integrations
{
    public class AntiFraudModel {
        public AntiFraudModel(string document, decimal totalAmount)
        {
            Document = document;
            TotalAmount = totalAmount;
        }

        public string Document { get; set; }
        public decimal TotalAmount { get; set; }
    }

}