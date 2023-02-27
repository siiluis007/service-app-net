using MyMicroservice.Commands;
using MyMicroservice.Repositories;
using MediatR;

namespace MyMicroservice.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository studentRepository)
        {
            _productRepository = studentRepository;
        }
        public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = await _productRepository.GetByIdAsync(command.Id);
            if (studentDetails == null)
                return default;   
            studentDetails.Name = command.Name;
            studentDetails.Price = command.Price;
            return await _productRepository.UpdateAsync(studentDetails);
        }
    }
}
