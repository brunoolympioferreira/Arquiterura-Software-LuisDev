using AwesomeShopPatterns.API.Application.Models;
using AwesomeShopPatterns.API.Infrastructure.Products;

namespace formacao_arquitetura.Application.ChainOfResponsibility
{
    public class ValidateStockHandler : OrderHandlerBase, IOrderHandler
    {
        private readonly IProductRepository _repository;
        public ValidateStockHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public override bool Handle(OrderInputModel model)
        {
            Console.WriteLine($"Invoking ValidateStockHandler.Handle");

            var itemsDictionary = model.Items.ToDictionary(d => d.ProductId, d => d.Quantity);
            var hasStock = _repository.HasStock(itemsDictionary);

            if (!hasStock)
                return false;

            return base.Handle(model);
        }
    }
}