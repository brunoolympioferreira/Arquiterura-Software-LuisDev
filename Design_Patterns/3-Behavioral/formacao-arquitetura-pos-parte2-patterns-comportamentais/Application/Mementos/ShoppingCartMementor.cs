namespace formacao_arquitetura.Application.Mementos
{
    public interface IShoppingCartMemento {
        Guid CustomerId { get; }
        List<KeyValuePair<Guid, int>> Items { get; }
        DateTime SavedAt { get; }
    }

    public class ShoppingCartMemento : IShoppingCartMemento
    {
        public ShoppingCartMemento(Guid customerId, List<KeyValuePair<Guid, int>> items)
        {
            CustomerId = customerId;
            Items = items;
            SavedAt = DateTime.Now;
        }

        public Guid CustomerId { get; private set; }
        public List<KeyValuePair<Guid, int>> Items { get; private set; }
        public DateTime SavedAt { get; private set; }
    }
}