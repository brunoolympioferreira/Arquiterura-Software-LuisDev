namespace AwesomeShopPatterns.API.Infrastructure.Notifications
{
    public interface IMarketingMessage
    {
        string From { get; }
        string To { get; }
        string Content { get; }
    }
}
