using MyMicroservice.Models;
using MediatR;

namespace MyMicroservice.Queries
{
    public class GetProductListQuery :  IRequest<List<Product>>
    {
    }
}
