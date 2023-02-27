using MyMicroservice.Models;
using MediatR;

namespace MyMicroservice.Queries
{
    public class GetCustomerListQuery :  IRequest<List<Customer>>
    {
    }
}
