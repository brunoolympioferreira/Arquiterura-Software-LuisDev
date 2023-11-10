using AwesomeShopPatterns.API.Application.Models;

namespace AwesomeShopPatterns.API.Application.TemplateMethods
{
    public abstract class WarehouseTemplateMethod
    {
        private Dictionary<Guid, int> _orderItems;
        protected OrderInputModel _model;

        public WarehouseTemplateMethod(OrderInputModel model)
        {
            _orderItems = new Dictionary<Guid, int>();
        }

        public void ExtractOrderData()
        {
            foreach (var item in _model.Items)
            {
                _orderItems.Add(item.ProductId, item.Quantity);
            }
        }

        public abstract void SeparateStockQuantities();
        public abstract void Notify();
    }
}
