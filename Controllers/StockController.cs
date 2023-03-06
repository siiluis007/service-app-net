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
    public class StocksController : ControllerBase
    {
        private readonly IMediator mediator;

        public StocksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<Stock> AddStockAsync(StockDto stock)
        {

            try
            {
                return await mediator.Send(new CreateStockCommand(stock));
            }
            catch (System.Exception)
            {

                throw new Exception("Err - Create Stock.");
            }
        }

        [HttpGet("id")]
        public async Task<Stock> GetStockByIdAsync(int id)
        {
            try
            {
                var result = await mediator.Send(new GetStockByIdQuery() { Id = id });
                if (result == null)
                {
                    throw new NotFoundException("Stock not found.");
                }
                return result;
            }
            catch (NotFoundException e)
            {
                throw e;
            }
            catch (System.Exception)
            {
                throw new Exception("Err Unknow - Get Stock by Id.");
            }

        }

        [HttpGet]
        public async Task<List<Stock>> GetListAsync()
        {

            try
            {
                var result = await mediator.Send(new GetStockListQuery());
                if (result.Count() == 0)
                {
                    throw new NotFoundException("Stocks not found.");
                }
                return result;
            }
            catch (NotFoundException e)
            {
                throw e;
            }
            catch (System.Exception)
            {
                throw new Exception("Err Unknow - Get Stocks.");
            }
        }

        [HttpGet("/stock-by-quantity/quantity")]
        public async Task<List<StockByQuantity>> GetByQuantityAsync(int quantity)
        {
            try
            {
                var result = await mediator.Send(new GetStockByQuantityQuery() { quantity = quantity });
                if (result.Count() == 0)
                {
                    throw new NotFoundException("Quantity Stocks not found.");
                }
                return result;
            }
            catch (NotFoundException e)
            {
                throw e;
            }
            catch (System.Exception)
            {
                throw new Exception("Err Unknow - Get Quantity Stocks.");
            }
        }

        [HttpPut]
        public async Task<int> UpdateStockAsync(StockUpdateDto stock)
        {

            try
            {
                return await mediator.Send(new UpdateStockCommand(stock));
            }
            catch (System.Exception)
            {

                throw new Exception("Err - Update Stock");
            }
        }

        [HttpDelete]
        public async Task<int> DeleteStockAsync(int id)
        {
            try
            {
                return await mediator.Send(new DeleteStockCommand() { Id = id });
            }
            catch (System.Exception)
            {
                throw new Exception("Err - Delete Stock.");
            }
        }



    }
}