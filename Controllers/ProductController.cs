using MyMicroservice.Commands;
using MyMicroservice.Models;
using MyMicroservice.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyMicroservice.Responses;
using MyMicroservice.Exceptions;

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

        [HttpPost]
        public async Task<Product> AddProductAsync(ProductDto product)
        {
            try
            {
                return await mediator.Send(new CreateProductCommand(product));
            }
            catch (System.Exception)
            {

                throw new Exception("Err - Create Product.");
            }
        }

        [HttpGet("id")]
        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                var result = await mediator.Send(new GetProductByIdQuery() { Id = id });
                if (result == null)
                {
                    throw new NotFoundException("Product not found.");
                }
                return result;
            }
            catch (NotFoundException e)
            {
                throw e;
            }
            catch (System.Exception)
            {

                throw new Exception("Err Unknow - Get Product by Id.");
            }

        }

        [HttpGet]
        public async Task<List<Product>> GetProductListAsync()
        {
            try
            {
                var result = await mediator.Send(new GetProductListQuery());
                if (result.Count() == 0)
                {
                    throw new NotFoundException("Products not found.");
                }
                return result;
            }
            catch (NotFoundException e)
            {
                throw e;
            }
            catch (System.Exception)
            {
                throw new Exception("Err Unknow - Get Products.");
            }
        }

        [HttpGet("/price-products")]
        public async Task<List<PriceProductResponse>> GetPriceProductListAsync()
        {
            try
            {
                var result = await mediator.Send(new GetPriceProductListQuery());

                if (result.Count() == 0)
                {
                    throw new NotFoundException("Price Products not found.");
                }
                return result;
            }
            catch (NotFoundException e)
            {
                throw e;
            }
            catch (System.Exception)
            {
                throw new Exception("Err Unknow - Get Price Products.");
            }
        }



        [HttpPut]
        public async Task<int> UpdateProductAsync(ProductUpdateDto product)
        {
            try
            {
                return await mediator.Send(new UpdateProductCommand(product));
            }
            catch (System.Exception)
            {

                throw new Exception("Err - Update Product");
            }
        }

        [HttpDelete]
        public async Task<int> DeleteProductAsync(int id)
        {
            try
            {
                return await mediator.Send(new DeleteProductCommand() { Id = id });
            }
            catch (System.Exception)
            {
                throw new Exception("Err - Delete Product.");
            }
        }
    }
}