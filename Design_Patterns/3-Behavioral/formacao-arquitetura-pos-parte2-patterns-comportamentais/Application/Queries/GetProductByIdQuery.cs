using AwesomeShopPatterns.API.Application.Mediator;

namespace AwesomeShopPatterns.API.Application.Queries
{
    public class GetProductByIdQuery : IQuery
    {
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
