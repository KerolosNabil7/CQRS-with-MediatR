using CQRS_with_MediatR.Features.Products.Commands.Create;
using CQRS_with_MediatR.Features.Products.Commands.Delete;
using CQRS_with_MediatR.Features.Products.Dtos;
using CQRS_with_MediatR.Features.Products.Queries.Get;
using CQRS_with_MediatR.Features.Products.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_with_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //ISender interface from MediatR to send the commands/queries to its registered handlers.
        private readonly ISender mediatr;
        public ProductController(ISender sender)
        {
            mediatr = sender;
        }
        [HttpGet("ListProductsAsync")]
        public async Task<IActionResult> ListProductsAsync()
        {
            var products = await mediatr.Send(new ListProductsQuery());
            return Ok(products);
        }
        [HttpGet("GetProductAsync")]
        public async Task<IActionResult> GetProductAsync(Guid id)
        {
            var product = await mediatr.Send(new GetProductQuery(id));
            if (product == null)
            {
                return BadRequest($"There is no Product with Id = {id}");
            }
            return Ok(product);
        }

        [HttpPost("CreateProductAsync")]
        public async Task<IActionResult> CreateProductAsync(CreateProductCommand command)
        {
            var productId = await mediatr.Send(command);
            if (productId == Guid.Empty)
                return BadRequest();
            return Ok(productId);
        }

        [HttpDelete("DeleteProductAsync")]
        public async Task<IActionResult> DeleteProductAsync(Guid Id)
        {
            await mediatr.Send(new DeleteProductCommand(Id));
            return NoContent();
        }
    }
}
