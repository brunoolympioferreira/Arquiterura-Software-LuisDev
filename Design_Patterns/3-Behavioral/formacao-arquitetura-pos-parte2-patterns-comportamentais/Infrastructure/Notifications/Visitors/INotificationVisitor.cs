namespace AwesomeShopPatterns.API.Infrastructure.Notifications.Visitors
{
    public interface INotificationVisitor
    {
        void Visit(SmsMessage message);
        void Visit(EmailMessage message);
    }
}
