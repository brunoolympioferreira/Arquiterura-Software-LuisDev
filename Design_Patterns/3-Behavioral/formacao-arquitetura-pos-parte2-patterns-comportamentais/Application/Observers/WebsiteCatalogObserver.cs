namespace AwesomeShopPatterns.API.Application.Observers
{
    public class WebsiteCatalogObserver : IDealsObserver
    {
        public void Update(IDealsSubject subject)
        {
            Console.WriteLine("Updating website catalog design.");
        }
    }
}
