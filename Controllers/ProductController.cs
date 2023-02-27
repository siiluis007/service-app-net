using MyMicroservice.Commands;
using MyMicroservice.Models;
using MyMicroservice.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyMicroservice.Responses;

namespace MyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Product>> GetProductListAsync()
        {
            return await mediator.Send(new GetProductListQuery());
        }
        
        [HttpGet("/price-products")]
        public async Task<List<PriceProductResponse>> GetPriceProductListAsync()
        {
            return await mediator.Send(new GetPriceProductListQuery());
        }

        [HttpGet("id")]
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await mediator.Send(new GetProductByIdQuery() { Id = id });
        }


        [HttpPost]
        public async Task<Product> AddProductAsync(ProductDto product)
        {

            return await mediator.Send(new CreateProductCommand(product));
        }
            
        [HttpPut]
        public async Task<int> UpdateProductAsync(ProductUpdateDto product)
        {
            return await mediator.Send(new UpdateProductCommand(product));
        }

        [HttpDelete]
        public async Task<int> DeleteProductAsync(int id)
        {
            return await mediator.Send(new DeleteProductCommand() { Id = id });
        }
    }
}