using AwesomeShopPatterns.API.Infrastructure.Notifications.Visitors;

namespace AwesomeShopPatterns.API.Infrastructure.Notifications
{
    public interface IMarketingMessage
    {
        void Accept(INotificationVisitor visitor);
        string From { get; }
        string To { get; }
        string Content { get; }
    }
}
