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
    public class StocksController : ControllerBase
    {
        private readonly IMediator mediator;

        public StocksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Stock>> GetListAsync()
        {
            return await mediator.Send(new GetStockListQuery());
        }

        [HttpGet("/stock-by-quantity/quantity")]
        public async Task<List<StockByQuantity>> GetByQuantityAsync(int quantity)
        {

            return await mediator.Send(new GetStockByQuantityQuery() { quantity = quantity });
        }

        [HttpPost]
        public async Task<Stock> AddStockAsync(StockDto stock)
        {

            return await mediator.Send(new CreateStockCommand(stock));
        }

    }
}