using AwesomeShopPatterns.API.Infrastructure.Notifications.Visitors;

namespace AwesomeShopPatterns.API.Infrastructure.Notifications
{
    public class NotificationService
    {
        public void Notify(List<IMarketingMessage> messages)
        {
            var visitor = new NotificationVisitor();

            foreach (var message in messages)
            {
                message.Accept(visitor);
            }
        }
    }
}
