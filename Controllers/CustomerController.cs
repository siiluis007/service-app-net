using MyMicroservice.Commands;
using MyMicroservice.Models;
using MyMicroservice.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyMicroservice.Exceptions;

namespace MyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<Customer> AddCustomerAsync(CustomerDto customer)
        {
            try
            {
                return await mediator.Send(new CreateCustomerCommand(customer));
            }
            catch (System.Exception)
            {

                throw new Exception("Err - Create Customer.");
            }

        }

        [HttpGet("id")]
        public async Task<Customer>? GetCustomerByIdAsync(int id)
        {
            try
            {
                var result = await mediator.Send(new GetCustomerByIdQuery() { Id = id });
                if (result == null)
                {
                    throw new NotFoundException("Customer not found.");
                }
                return result;
            }
            catch (NotFoundException e)
            {
                throw e;
            }
            catch (System.Exception)
            {

                throw new Exception("Err Unknow - Get Customer by Id.");
            }
        }

        [HttpGet]
        public async Task<List<Customer>> GetCustomerListAsync()
        {
            try
            {
                var result = await mediator.Send(new GetCustomerListQuery());
                if (result.Count() == 0)
                {
                    throw new NotFoundException("Customers not found.");
                }
                return result;
            }
            catch (NotFoundException e)
            {
                throw e;
            }
            catch (System.Exception)
            {
                throw new Exception("Err Unknow - Get Customers.");
            }

        }

        [HttpPut]
        public async Task<int> UpdateCustomerAsync(CustomerUpdateDto customer)
        {
            try
            {
                return await mediator.Send(new UpdateCustomerCommand(customer));
            }
            catch (System.Exception)
            {

                throw new Exception("Err - Update Customer");
            }
        }

        [HttpDelete]
        public async Task<int> DeleteCustomerAsync(int id)
        {
            try
            {
                return await mediator.Send(new DeleteCustomerCommand() { Id = id });
            }
            catch (System.Exception)
            {
                throw new Exception("Err - Delete Customer");
            }

        }

    }
}