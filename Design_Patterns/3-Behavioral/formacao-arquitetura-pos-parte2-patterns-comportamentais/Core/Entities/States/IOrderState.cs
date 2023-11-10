namespace AwesomeShopPatterns.API.Core.Entities.States
{
    public interface IOrderState
    {
        void Handle();
        void Add(Guid item);
        void SetContext(OrderStateContext context);
        OrderStateContext Context { get; }
        List<Guid> Items { get; }
    }
}
