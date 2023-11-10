using AwesomeShopPatterns.API.Application.Models;

namespace AwesomeShopPatterns.API.Application.TemplateMethods
{
    public class WarehouseInternalService : WarehouseTemplateMethod
    {
        public WarehouseInternalService(OrderInputModel model) : base(model)
        {
        }

        public override void Notify()
        {
            Console.WriteLine("Publish message to messaging bus topic.");
        }

        public override void SeparateStockQuantities()
        {
            Console.WriteLine("Separating internal stock quantities.");
        }
    }
}
