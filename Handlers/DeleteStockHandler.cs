using MyMicroservice.Commands;
using MyMicroservice.Repositories;
using MediatR;

namespace MyMicroservice.Handlers
{
    public class DeleteStockHandler : IRequestHandler<DeleteStockCommand, int>
    {
        private readonly IStockRepository _itemRepository;

        public DeleteStockHandler(IStockRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<int> Handle(DeleteStockCommand command, CancellationToken cancellationToken)
        {
            return await _itemRepository.DeleteAsync(command.Id);
        }
    }
}