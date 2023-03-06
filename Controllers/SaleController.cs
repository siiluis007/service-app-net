using MyMicroservice.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyMicroservice.Commands;
using MyMicroservice.Queries;
using MyMicroservice.Responses;
using MyMicroservice.Exceptions;

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

        [HttpPost]
        public async Task<Sale> AddSaleAsync(SaleDto sale)
        {
            try
            {
                return await mediator.Send(new CreateSaleCommand(sale));
            }
            catch (System.Exception)
            {

                throw new Exception("Err - Create Sale.");
            }
        }

        [HttpGet("id")]
        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            try
            {
                var result = await mediator.Send(new GetSaleByIdQuery() { Id = id });

                if (result == null)
                {
                    throw new NotFoundException("Sale not found.");
                }
                return result;
            }
            catch (NotFoundException e)
            {
                throw e;
            }
            catch (System.Exception)
            {
                throw new Exception("Err Unknow - Get Sale by Id.");
            }
        }

        [HttpGet]
        public async Task<List<Sale>> GetSaleListAsync()
        {
            try
            {
                var result = await mediator.Send(new GetSaleListQuery());
                if (result.Count() == 0)
                {
                    throw new NotFoundException("Sales  not found.");
                }
                return result;
            }
            catch (NotFoundException e)
            {
                throw e;
            }
            catch (System.Exception)
            {
                throw new Exception("Err Unknow - Get Sales.");
            }
        }





        [HttpPut]
        public async Task<int> UpdateSaleAsync(SaleUpdateDto sale)
        {

            try
            {
                return await mediator.Send(new UpdateSaleCommand(sale));
            }
            catch (System.Exception)
            {

                throw new Exception("Err - Update Sale");
            }
        }

        [HttpDelete]
        public async Task<int> DeleteSaleAsync(int id)
        {

            try
            {
                return await mediator.Send(new DeleteSaleCommand() { Id = id });
            }
            catch (System.Exception)
            {
                throw new Exception("Err - Delete Sale.");
            }
        }

        [HttpGet("/sales-customer-by-date")]
        public async Task<List<SaleByRangeWithCustomer>> GetSaleByRangeWithCustomer([FromQuery(Name = "start")] string start, [FromQuery(Name = "end")] string end, [FromQuery(Name = "age")] int age)
        {
            try
            {
                var result = await mediator.Send(new GetSaleByRangeWithCustomerQuery() { dateFrom = start, dateTo = end, age = age });
                if (result.Count() == 0)
                {
                    throw new NotFoundException("Sales By Range not found.");
                }
                return result;
            }
            catch (NotFoundException e)
            {
                throw e;
            }
            catch (System.Exception)
            {
                throw new Exception("Err Unknow - Get Sale By Range With Customer");
            }
        }

        [HttpGet("/amount-total-product")]
        public async Task<List<AmountTotalProduct>> GetAmountTotalProductCustomer([FromQuery(Name = "start")] string start, [FromQuery(Name = "end")] string end)
        {
            try
            {
                var result = await mediator.Send(new GetAmountTotalProductQuery() { dateFrom = start, dateTo = end });
                if (result.Count() == 0)
                {
                    throw new NotFoundException("Amount Total Product ot found.");
                }
                return result;
            }
            catch (NotFoundException e)
            {
                throw e;
            }
            catch (System.Exception)
            {
                throw new Exception("Err Unknow -  Get Amount Total Product");
            }
        }

        [HttpGet("/last-sale-by-customer/id")]
        public async Task<GetLastSaleByCustomerResponse> GetLastSaleByCustomer(int id)
        {
            try
            {
                var result = await mediator.Send(new GetLastSaleByCustomerQuery() { id = id });

                if (result == null)
                {
                    throw new NotFoundException("Last Sale By Customer  not found.");
                }
                return result;
            }
            catch (NotFoundException e)
            {
                throw e;
            }
            catch (System.Exception)
            {
                throw new Exception("Err Unknow - Get Last Sale By Customer ");
            }
        }
    }
}