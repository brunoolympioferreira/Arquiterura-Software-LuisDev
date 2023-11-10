namespace AwesomeShopPatterns.API.Application.Observers
{
    public interface IDealsSubject
    {
        List<string> CurrentDeals { get; }
        void SetDeals(List<string> deals);
        void Attach(IDealsObserver observer);
        void Detach(IDealsObserver observer);
        void Notify();
    }
}
