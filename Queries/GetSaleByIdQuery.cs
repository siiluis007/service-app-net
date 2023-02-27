using MediatR;
using MyMicroservice.Models;

namespace MyMicroservice.Queries
{
    public class  GetSaleByIdQuery : IRequest<Sale>
    {
        public int Id { get; set; }
    }
}