using AwesomeShopPatterns.API.Application.Models;

namespace AwesomeShopPatterns.API.Infrastructure.Deliveries
{
    public class WarehouseExternalService
    {
        protected Dictionary<Guid, int> _orderItems;

        public WarehouseExternalService()
        {
            _orderItems = new Dictionary<Guid, int>();
        }

        public void ExtractOrderData(OrderInputModel model)
        {
            foreach (var item in model.Items)
            {
                _orderItems.Add(item.ProductId, item.Quantity);
            }
        }

        public void SeparateStockQuantities(OrderInputModel model)
        {
            Console.WriteLine("Separating external stock quantities.");
        }

        public void Notify()
        {
            Console.WriteLine("Notifying other components through REST API.");
        }
    }
}
