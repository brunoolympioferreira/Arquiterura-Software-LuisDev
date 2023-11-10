namespace AwesomeShopPatterns.API.Core.Entities.States
{
    public class OrderPreparingState : OrderStateBase, IOrderState
    {
        public OrderPreparingState(List<Guid> items) : base(items)
        {
        }

        public void Add(Guid item)
        {
            Items.Add(item);

            Console.WriteLine("Order updated.");
        }

        public void Handle()
        {
            Console.WriteLine("Order moving from Preparing to next state.");

            Context.SetCurrentState(new OrderOnWayToDeliverState(Items));
        }
    }
}
