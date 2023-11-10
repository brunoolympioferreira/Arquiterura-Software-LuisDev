using AwesomeShopPatterns.API.Application.Models;

namespace formacao_arquitetura.Application.ChainOfResponsibility
{
    public interface IOrderHandler
    {
        bool Handle(OrderInputModel model);
        IOrderHandler SetNext(IOrderHandler handler);
    }
}