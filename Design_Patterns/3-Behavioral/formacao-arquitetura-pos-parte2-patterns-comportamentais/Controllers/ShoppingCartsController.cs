using AwesomeShopPatterns.API.Application.Models;
using formacao_arquitetura.Application.Mementos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace formacao_arquitetura.Controllers
{
    [ApiController]
    [Route("api/shopping-carts")]
    public class ShoppingCartsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Save(ShoppingCartInputModel model) {
            var originator = new ShoppingCartOriginator(model.CustomerId, model.Items);
            var shoppingCartCareTaker = new ShoppingCartCaretaker(originator);
            
            var productId1 = new Guid("d60d6a11-faff-419e-b119-4de58f913055");
            var productId2 = new Guid("d98329b7-87af-4bea-b6ac-3674f2bc0230");
            var productId3 = new Guid("fbb35828-d9ba-4fdf-b9a3-1aaff7a68e30");

            model.Items.Add(new OrderItemInputModel { ProductId = productId1, Quantity = 1 });
            
            // Fazer backup e atualizar
            shoppingCartCareTaker.Backup();
            shoppingCartCareTaker.Originator.UpdateCart(model.Items);

            model.Items.Add(new OrderItemInputModel { ProductId = productId2, Quantity = 2 });
            
            // Fazer backup e atualizar
            shoppingCartCareTaker.Backup();
            shoppingCartCareTaker.Originator.UpdateCart(model.Items);

            model.Items.Add(new OrderItemInputModel { ProductId = productId3, Quantity = 3 });
            
            // Fazer backup e atualizar
            shoppingCartCareTaker.Backup();
            shoppingCartCareTaker.Originator.UpdateCart(model.Items);

            shoppingCartCareTaker.Backup();
            
            shoppingCartCareTaker.PrintHistory();

            shoppingCartCareTaker.Undo();

            shoppingCartCareTaker.PrintHistory();
            
            return NoContent();
        }
    }

    public class ShoppingCartInputModel {
        public Guid CustomerId { get; set; }
        public List<OrderItemInputModel> Items { get; set; }
    }
}