using MyMicroservice.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyMicroservice.Commands;
using MyMicroservice.Queries;
using MyMicroservice.Responses;

namespace MyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IMediator mediator;

        public SalesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Sale>> GetSaleListAsync()
        {
            return await mediator.Send(new GetSaleListQuery());
        }

        [HttpGet("id")]
        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await mediator.Send(new GetSaleByIdQuery() { Id = id });
        }

        [HttpPost]
        public async Task<Sale> AddSaleAsync(SaleDto sale)
        {

            return await mediator.Send(new CreateSaleCommand(sale));
        }

        [HttpPut]
        public async Task<int> UpdateSaleAsync(SaleUpdateDto sale)
        {
            return await mediator.Send(new UpdateSaleCommand(sale));
        }

        [HttpDelete]
        public async Task<int> DeleteSaleAsync(int id)
        {
            return await mediator.Send(new DeleteSaleCommand() { Id = id });
        }

        [HttpGet("/sales-customer-by-date")]
        public async Task<List<SaleByRangeWithCustomer>> GetSaleByRangeWithCustomer([FromQuery(Name = "start")] string start, [FromQuery(Name = "end")] string end, [FromQuery(Name = "age")] int age)
        {
            try
            {
                return await mediator.Send(new GetSaleByRangeWithCustomerQuery() { dateFrom = start, dateTo = end, age = age });
            }
            catch (System.Exception)
            {

                throw new Exception("Err Query - Get Sale By Range With Customer");
            }
        }

        [HttpGet("/amount-total-product")]
        public async Task<List<AmountTotalProduct>> GetAmountTotalProductCustomer([FromQuery(Name = "start")] string start, [FromQuery(Name = "end")] string end)
        {
            try
            {
                return await mediator.Send(new GetAmountTotalProductQuery() { dateFrom = start, dateTo = end });
            }
            catch (System.Exception)
            {

                throw new Exception("Err Query - Get Amount Total Product ");
            }

        }

        [HttpGet("/last-sale-by-customer/id")]
        public async Task<GetLastSaleByCustomerResponse> GetLastSaleByCustomer(int id)
        {
            try
            {
                return await mediator.Send(new GetLastSaleByCustomerQuery() { id = id });
            }
            catch (Exception e)
            {
                throw new Exception("Err Query - Get Last Sale By Customer ");
            }
        }
    }
}