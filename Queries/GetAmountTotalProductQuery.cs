using MediatR;
using MyMicroservice.Responses;

namespace MyMicroservice.Queries
{
    public class GetAmountTotalProductQuery: IRequest<List<AmountTotalProduct>>
    {
        public string? dateFrom { get; set; }
        public string? dateTo { get; set; }
    }
}