using MediatR;
using MyMicroservice.Models;

namespace MyMicroservice.Queries
{
    public class  GetSaleListQuery : IRequest<List<Sale>>
    {
    }
}