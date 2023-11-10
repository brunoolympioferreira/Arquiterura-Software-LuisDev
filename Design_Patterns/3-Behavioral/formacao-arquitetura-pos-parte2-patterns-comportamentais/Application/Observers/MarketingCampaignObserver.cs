namespace AwesomeShopPatterns.API.Application.Observers
{
    public class MarketingCampaignObserver : IDealsObserver
    {
        public void Update(IDealsSubject subject)
        {
            Console.WriteLine("Sending an email to subscribed users.");
        }
    }
}
