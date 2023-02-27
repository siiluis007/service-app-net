using MyMicroservice.Commands;
using MyMicroservice.Models;
using MyMicroservice.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


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

        [HttpGet]
        public async Task<List<Customer>> GetCustomerListAsync()
        {
            return await mediator.Send(new GetCustomerListQuery());
        }

        [HttpGet("id")]
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await mediator.Send(new GetCustomerByIdQuery() { Id = id });
        }

        [HttpPost]
        public async Task<Customer> AddCustomerAsync(CustomerDto product)
        {
            return await mediator.Send(new CreateCustomerCommand(product));
        }

    }
}