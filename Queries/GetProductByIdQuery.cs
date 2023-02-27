using MyMicroservice.Models;
using MediatR;

namespace MyMicroservice.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
