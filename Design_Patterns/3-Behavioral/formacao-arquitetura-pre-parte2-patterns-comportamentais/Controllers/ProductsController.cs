using AwesomeShopPatterns.API.Application;
using AwesomeShopPatterns.API.Application.Mediator;
using AwesomeShopPatterns.API.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShopPatterns.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ICqrsMediator _mediator;
        public ProductsController(ICqrsMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
            var handler = new GetAllProductsQueryHandler();

            var result = await handler.Handle(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery(id);
            var handler = new GetProductByIdQueryHandler();

            var result = await handler.Handle(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("with-mediator")]
        public async Task<IActionResult> GetAllWithMediator()
        {
            var query = new GetAllProductsQuery();

            var result = await _mediator.Handle(query);

            return Ok(result);
        }

        [HttpGet("{id}/with-mediator")]
        public async Task<IActionResult> GetByIdWithMediator(Guid id)
        {
            var query = new GetProductByIdQuery(id);

            var result = await _mediator.Handle(query);

            return Ok(result);
        }
    }
}
