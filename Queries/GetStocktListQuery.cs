using MyMicroservice.Models;
using MediatR;

namespace MyMicroservice.Queries
{
    public class GetStockListQuery :  IRequest<List<Stock>>
    {
    }
}
