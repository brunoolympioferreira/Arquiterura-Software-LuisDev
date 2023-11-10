using AwesomeShopPatterns.API.Application.Models;

namespace AwesomeShopPatterns.API.Application.Queries
{
    public class GetProductByIdQueryHandler
    {
        public Task<ProductDetailsViewModel> Handle(GetProductByIdQuery query)
        {
            return Task.FromResult(new ProductDetailsViewModel());
        }
    }
}
