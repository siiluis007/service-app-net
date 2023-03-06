using MyMicroservice.Models;
using MediatR;

namespace MyMicroservice.Queries
{
    public class GetStockByIdQuery : IRequest<Stock>
    {
        public int Id { get; set; }
    }
}
