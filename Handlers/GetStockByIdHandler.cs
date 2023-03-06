using MyMicroservice.Models;
using MyMicroservice.Queries;
using MyMicroservice.Repositories;
using MediatR;
using System.Numerics;

namespace MyMicroservice.Handlers
{
    public class GetStockByIdHandler : IRequestHandler<GetStockByIdQuery, Stock>
    {
        private readonly IStockRepository _itemRepository;

        public GetStockByIdHandler(IStockRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Stock> Handle(GetStockByIdQuery query, CancellationToken cancellationToken)
        {
            return await _itemRepository.GetByIdAsync(query.Id);
        }
    }
}
