using MyMicroservice.Commands;
using MyMicroservice.Repositories;
using MediatR;

namespace MyMicroservice.Handlers
{
    public class UpdateStockHandler : IRequestHandler<UpdateStockCommand, int>
    {
        private readonly IStockRepository _itemRepository;

        public UpdateStockHandler(IStockRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<int> Handle(UpdateStockCommand command, CancellationToken cancellationToken)
        {
            var stock = await _itemRepository.GetByIdAsync(command.Id);
            if (stock == null) return default;   
            stock.StockId = command.Id;
            stock.ProductId = command.ProductId;
            stock.Quantity = command.Quantity;
            stock.PurchasePrice = command.PurchasePrice;
            return await _itemRepository.UpdateAsync(stock);
        }
    }
}
