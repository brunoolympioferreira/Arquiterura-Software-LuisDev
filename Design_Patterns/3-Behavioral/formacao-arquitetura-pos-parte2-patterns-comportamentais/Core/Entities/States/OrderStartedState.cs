namespace AwesomeShopPatterns.API.Core.Entities.States
{
    public class OrderStartedState : OrderStateBase, IOrderState
    {
        public OrderStartedState(List<Guid> items) : base(items)
        {

        }

        public void Add(Guid item)
        {
            Items.Add(item);

            Console.WriteLine("Order updated.");
        }

        public void Handle()
        {
            Console.WriteLine("Order moving from Started to next state.");

            Context.SetCurrentState(new OrderPreparingState(Items));
        }
    }
}
