using MyMicroservice.Models;
using MyMicroservice.Queries;
using MyMicroservice.Repositories;
using MediatR;

namespace MyMicroservice.Handlers
{
    public class GetSaleListHandler : IRequestHandler<GetSaleListQuery, List<Sale>>
    {
        private readonly ISaleRepository _saleRepository;

        public GetSaleListHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<List<Sale>> Handle(GetSaleListQuery query, CancellationToken cancellationToken)
        {
            return await _saleRepository.GetListAsync();
        }
    }
}
