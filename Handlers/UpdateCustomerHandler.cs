using MyMicroservice.Commands;
using MyMicroservice.Repositories;
using MediatR;

namespace MyMicroservice.Handlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly ICustomerRepository _itemRepository;

        public UpdateCustomerHandler(ICustomerRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await _itemRepository.GetByIdAsync(command.Id);
            if (customer == null) return default;   
            customer.Document = command.Document;
            customer.Name = command.Name;
            customer.LastName = command.LastName;
            customer.Age = command.Age;
            return await _itemRepository.UpdateAsync(customer);
        }
    }
}
