using MyMicroservice.Models;
using MyMicroservice.Queries;
using MyMicroservice.Repositories;
using MediatR;
using System.Numerics;
using MyMicroservice.Responses;

namespace MyMicroservice.Handlers
{
    public class GetStockByQuantityHandler :  IRequestHandler<GetStockByQuantityQuery, List<StockByQuantity>>
    {
        private readonly IStockRepository _stockRepository;

        public GetStockByQuantityHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<List<StockByQuantity>> Handle(GetStockByQuantityQuery query, CancellationToken cancellationToken)
        {
            return await _stockRepository.GetStockByQuantityAsync(query.quantity);
        }
    }
}
