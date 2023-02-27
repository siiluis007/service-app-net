using MyMicroservice.Models;
using MyMicroservice.Queries;
using MyMicroservice.Repositories;
using MediatR;
using MyMicroservice.Responses;

namespace MyMicroservice.Handlers
{
    public class GetSaleByRangeWithCustomerHandler :  IRequestHandler<GetSaleByRangeWithCustomerQuery, List<SaleByRangeWithCustomer>>
    {
        private readonly ISaleRepository _saleRepository;

        public GetSaleByRangeWithCustomerHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<List<SaleByRangeWithCustomer>> Handle(GetSaleByRangeWithCustomerQuery query, CancellationToken cancellationToken)
        {
            return await _saleRepository.GetSaleByRangeWithCustomerAsync(query.dateFrom, query.dateTo, query.age);
        }
    }
}
