using MyMicroservice.Models;
using MyMicroservice.Queries;
using MyMicroservice.Repositories;
using MediatR;
using System.Numerics;

namespace MyMicroservice.Handlers
{
    public class GetCustomerListHandler :  IRequestHandler<GetCustomerListQuery, List<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerListHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> Handle(GetCustomerListQuery query, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetListAsync();
        }
    }
}
