using MyMicroservice.Commands;
using MyMicroservice.Models;
using MyMicroservice.Repositories;
using MediatR;
using System.Numerics;

namespace MyMicroservice.Handlers
{
    public class CreateStockHandler: IRequestHandler<CreateStockCommand, Stock>
    {
        private readonly IStockRepository _stockRepository;

        public CreateStockHandler(IStockRepository productRepository)
        {
            _stockRepository = productRepository;
        }
        public async Task<Stock> Handle(CreateStockCommand command, CancellationToken cancellationToken)
        {

            var stock = new Stock()
            {
                Quantity = command.Quantity,
                StockId = command.ProductId,
                CreatedTimestamp = DateTime.Now
            };

            return await _stockRepository.AddAsync(stock);
        }
    }
}
