using MediatR;
using MyMicroservice.Responses;

namespace MyMicroservice.Queries
{
    public class GetSaleByRangeWithCustomerQuery: IRequest<List<SaleByRangeWithCustomer>>
    {
        public int age { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
    }
}