using MyMicroservice.Models;
using MediatR;
using MyMicroservice.Responses;

namespace MyMicroservice.Queries
{
    public class GetPriceProductListQuery :  IRequest<List<PriceProductResponse>>
    {
    }
}
