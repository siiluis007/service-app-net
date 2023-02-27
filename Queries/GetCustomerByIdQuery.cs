using MyMicroservice.Models;
using MediatR;

namespace MyMicroservice.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; set; }
    }
}
