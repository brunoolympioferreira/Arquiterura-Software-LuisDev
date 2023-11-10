namespace AwesomeShopPatterns.API.Core.Entities.States
{
    public abstract class OrderStateBase
    {
        public OrderStateBase(List<Guid> items)
        {
            Items = items;
        }

        public List<Guid> Items { get; set; }

        public OrderStateContext Context { get; protected set; }

        public void SetContext(OrderStateContext context)
        {
            Context = context;
        }
    }
}
