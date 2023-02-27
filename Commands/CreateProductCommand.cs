using MyMicroservice.Models;
using MediatR;
using System.Numerics;

namespace MyMicroservice.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Margin { get; set; }

        public CreateProductCommand(ProductDto product)
        {
            Name = product.name;
            Price = product.price;
        }
    }
}
