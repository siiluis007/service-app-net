using MyMicroservice.Commands;
using MyMicroservice.Models;
using MyMicroservice.Repositories;
using MediatR;
using System.Numerics;

namespace MyMicroservice.Handlers
{
    public class CreateProductHandler: IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            var productDetails = new Product()
            {
                Name = command.Name,
                Price = command.Price,
                CreatedTimestamp = DateTime.Now
            };

            return await _productRepository.AddAsync(productDetails);
        }
    }
}
