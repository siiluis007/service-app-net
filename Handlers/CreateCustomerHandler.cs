using MyMicroservice.Commands;
using MyMicroservice.Models;
using MyMicroservice.Repositories;
using MediatR;
using System.Numerics;

namespace MyMicroservice.Handlers
{
    public class CreateCustomerHandler: IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {

            var stock = new Customer()
            {
                Document = command.Document,
                Name = command.Name,
                LastName = command.LastName,
                CreatedTimestamp = DateTime.Now
            };

            return await _customerRepository.AddAsync(stock);
        }
    }
}
