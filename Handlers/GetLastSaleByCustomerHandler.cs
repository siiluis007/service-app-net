using MyMicroservice.Queries;
using MyMicroservice.Repositories;
using MediatR;
using MyMicroservice.Responses;

namespace MyMicroservice.Handlers
{
    public class GetLastSaleByCustomerHandler :  IRequestHandler<GetLastSaleByCustomerQuery, GetLastSaleByCustomerResponse>
    {
        private readonly ISaleRepository _saleRepository;

        public GetLastSaleByCustomerHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<GetLastSaleByCustomerResponse> Handle(GetLastSaleByCustomerQuery query, CancellationToken cancellationToken)
        {
            return await _saleRepository.GetLastSaleByCustomerAsync(query.id);
        }
    }
}
