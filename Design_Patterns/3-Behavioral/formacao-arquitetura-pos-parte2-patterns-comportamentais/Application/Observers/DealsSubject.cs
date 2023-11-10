namespace AwesomeShopPatterns.API.Application.Observers
{
    public class DealsSubject : IDealsSubject
    {
        private readonly List<IDealsObserver> _observers;
        public DealsSubject()
        {
            _observers = new List<IDealsObserver>();
            CurrentDeals = new List<string>();
        }

        public List<string> CurrentDeals { get; private set; }

        public void Attach(IDealsObserver observer)
        {
            if (!_observers.Any(o => o.Equals(observer)))
            {
                _observers.Add(observer);
            }
        }

        public void Detach(IDealsObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void SetDeals(List<string> deals)
        {
            CurrentDeals = deals;

            Notify();
        }
    }
}
