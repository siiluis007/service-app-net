using MyMicroservice.Models;
using MyMicroservice.Queries;
using MyMicroservice.Repositories;
using MediatR;
using System.Numerics;

namespace MyMicroservice.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdHandler(ICustomerRepository studentRepository)
        {
            _customerRepository = studentRepository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetByIdAsync(query.Id);
        }
    }
}
