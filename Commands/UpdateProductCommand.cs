using MediatR;
using MyMicroservice.Models;

namespace MyMicroservice.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Margin { get; set; }

        public UpdateProductCommand(ProductUpdateDto product)
        {
            Id = product.id;
            Name = product.name;
            Price = product.price;
            Margin = product.margin;
        }
    }
}
