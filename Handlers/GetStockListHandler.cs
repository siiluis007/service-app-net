using MyMicroservice.Models;
using MyMicroservice.Queries;
using MyMicroservice.Repositories;
using MediatR;
using System.Numerics;

namespace MyMicroservice.Handlers
{
    public class GetStockListHandler :  IRequestHandler<GetStockListQuery, List<Stock>>
    {
        private readonly IStockRepository _stockRepository;

        public GetStockListHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<List<Stock>> Handle(GetStockListQuery query, CancellationToken cancellationToken)
        {
            return await _stockRepository.GetListAsync();
        }
    }
}
