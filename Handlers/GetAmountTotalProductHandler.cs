using MyMicroservice.Models;
using MyMicroservice.Queries;
using MyMicroservice.Repositories;
using MediatR;
using MyMicroservice.Responses;

namespace MyMicroservice.Handlers
{
    public class GetAmountTotalProductHandler : IRequestHandler<GetAmountTotalProductQuery, List<AmountTotalProduct>>
    {
        private readonly ISaleRepository _saleRepository;

        public GetAmountTotalProductHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<List<AmountTotalProduct>> Handle(GetAmountTotalProductQuery query, CancellationToken cancellationToken)
        {
            return await _saleRepository.GetAmountTotalProductAsync(query.dateFrom,query.dateTo);
        }
    }
}
