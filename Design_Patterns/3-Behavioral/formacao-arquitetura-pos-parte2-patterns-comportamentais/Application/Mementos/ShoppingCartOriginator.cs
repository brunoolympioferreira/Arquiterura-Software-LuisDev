using AwesomeShopPatterns.API.Application.Models;

namespace formacao_arquitetura.Application.Mementos
{
    public interface IShoppingCartOriginator
    {
        Guid CustomerId { get; }
        List<KeyValuePair<Guid, int>> Items { get; }

        void Restore(IShoppingCartMemento shoppingCartMemento);
        IShoppingCartMemento SaveSnapshot();
        void UpdateCart(List<OrderItemInputModel> items);
    }

    public class ShoppingCartOriginator : IShoppingCartOriginator
    {
        public ShoppingCartOriginator(Guid customerId, List<OrderItemInputModel> items)
        {
            CustomerId = customerId;
            Items = items.Select(i => new KeyValuePair<Guid, int>(i.ProductId, i.Quantity)).ToList();
        }

        public Guid CustomerId { get; private set; }
        public List<KeyValuePair<Guid, int>> Items {get; private set; }

        public void Restore(IShoppingCartMemento shoppingCartMemento)
        {
            var concreteMemento = shoppingCartMemento as ShoppingCartMemento;

            Items = concreteMemento.Items;
        }

        public IShoppingCartMemento SaveSnapshot()
            => new ShoppingCartMemento(CustomerId, Items);

        public void UpdateCart(List<OrderItemInputModel> items)
        {
            Items = items.Select(i => new KeyValuePair<Guid, int>(i.ProductId, i.Quantity)).ToList();
        }
    }
}