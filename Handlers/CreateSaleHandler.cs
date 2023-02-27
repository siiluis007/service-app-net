using MyMicroservice.Commands;
using MyMicroservice.Models;
using MyMicroservice.Repositories;
using MediatR;


namespace MyMicroservice.Handlers
{
    public class CreateSaleHandler: IRequestHandler<CreateSaleCommand, Sale>
    {
        private readonly ISaleRepository _itemRepository;

        public CreateSaleHandler(ISaleRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<Sale> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {

            var sale = new Sale()
            {
                Amount = command.Amount,
                Quantity = command.Quantity,
                CreatedTimestamp = DateTime.Now
            };

            return await _itemRepository.AddAsync(sale);
        }
    }
}
