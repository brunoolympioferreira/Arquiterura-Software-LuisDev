using AwesomeShopPatterns.API.Application.Queries;

namespace AwesomeShopPatterns.API.Application.Mediator
{
    public interface ICqrsMediator
    {
        Task<IMediatorResult> Handle(IQuery query);
        Task<IMediatorResult> Handle(ICommand command);
    }

    public class CqrsMediator : ICqrsMediator
    {
        public async Task<IMediatorResult> Handle(IQuery query)
        {
            IMediatorResult mediatorResult;

            if (query is null)
                mediatorResult = new MediatorResult(null, false);
            
            if (query is GetProductByIdQuery) {
                var handler = new GetProductByIdQueryHandler();

                var result = await handler.Handle(query as GetProductByIdQuery);

                mediatorResult = new MediatorResult(result, true);
            } else if (query is GetAllProductsQuery) {
                var handler = new GetAllProductsQueryHandler();

                var result = await handler.Handle(query as GetAllProductsQuery);

                mediatorResult = new MediatorResult(result, true);
            }
            else {
                mediatorResult = new MediatorResult(null, false);
            }

            return mediatorResult;
        }

        public Task<IMediatorResult> Handle(ICommand command)
        {
            throw new NotImplementedException();
        }
    }

    public interface IQuery { }
    public interface ICommand { }

    public interface IMediatorResult {
        object Data { get; }
        bool Success { get; }
    }

    public class MediatorResult : IMediatorResult {
        public MediatorResult(object data, bool success)
        {
            Data = data;
            Success = success;
        }

        public object Data { get; private set; }
        public bool Success { get; private set; }
    }
}
