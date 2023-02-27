using MediatR;
using MyMicroservice.Responses;

namespace MyMicroservice.Queries
{
    public class GetLastSaleByCustomerQuery : IRequest<GetLastSaleByCustomerResponse>
    {
        public int id { get; set; }
    }
}