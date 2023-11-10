namespace AwesomeShopPatterns.API.Core.Entities.States
{
    internal class OrderOnWayToDeliverState : OrderStateBase, IOrderState
    {
        public OrderOnWayToDeliverState(List<Guid> items) : base(items)
        {
        }

        public void Add(Guid item)
        {
            throw new InvalidOperationException("Invalid operation.");
        }

        public void Handle()
        {
            Console.WriteLine("Order moving from On Way To Deliver to next state.");

            Context.SetCurrentState(new OrderCompletedState(Items));
        }
    }
}