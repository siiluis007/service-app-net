using MyMicroservice.Commands;
using MyMicroservice.Repositories;
using MediatR;

namespace MyMicroservice.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = await _productRepository.GetByIdAsync(command.Id);
            if (studentDetails == null)
                return default;
            return await _productRepository.DeleteAsync(studentDetails.ProductId);
        }
    }
}