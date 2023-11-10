using AwesomeShopPatterns.API.Application.Models;

namespace AwesomeShopPatterns.API.Application.Queries
{
    public class GetAllProductsQueryHandler
    {
        public Task<ProductViewModel> Handle(GetAllProductsQuery query)
        {
            return Task.FromResult(new ProductViewModel());
        }
    }
}
