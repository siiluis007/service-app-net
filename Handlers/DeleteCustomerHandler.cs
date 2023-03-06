using MyMicroservice.Commands;
using MyMicroservice.Repositories;
using MediatR;

namespace MyMicroservice.Handlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, int>
    {
        private readonly ICustomerRepository _itemRepository;

        public DeleteCustomerHandler(ICustomerRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<int> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            return await _itemRepository.DeleteAsync(command.Id);
        }
    }
}