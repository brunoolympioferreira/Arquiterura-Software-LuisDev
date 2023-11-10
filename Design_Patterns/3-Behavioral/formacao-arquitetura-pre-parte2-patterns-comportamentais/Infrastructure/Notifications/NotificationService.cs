namespace AwesomeShopPatterns.API.Infrastructure.Notifications
{
    public class NotificationService
    {
        public void Notify(List<IMarketingMessage> messages)
        {
            foreach (var message in messages)
            {
                if (message is SmsMessage)
                {
                    Console.WriteLine("Sms Message!");
                } else if (message is EmailMessage)
                {
                    Console.WriteLine("Email Message!");
                }
            }
        }
    }
}
