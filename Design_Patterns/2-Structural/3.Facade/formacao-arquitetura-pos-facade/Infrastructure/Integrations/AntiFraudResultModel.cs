namespace AwesomeShopPatterns.API.Infrastructure.Integrations
{
    public record AntiFraudResultModel {
        public bool CheckResult { get; set; }
        public string Comments { get; set; }
    }

}