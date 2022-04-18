using MediatR;
using MediatRPattern.Entities;
using Microsoft.AspNetCore.Mvc;
using static MediatRPattern.Commands.AddSingleProductCommand;
using static MediatRPattern.Notifications.ProductNotification;
using static MediatRPattern.Queries.GetValueQuery;
using static MediatRPattern.Queries.GetValuesQuery;

namespace MediatRPattern.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);

        }
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            {
                var productToReturn = await _mediator.Send(new AddProductCommand(product));

                await _mediator.Publish(new ProductAddedNotification(productToReturn));

                return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
            }
        }
    }
}
