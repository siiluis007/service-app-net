using MediatR;

namespace MyMicroservice.Controllers
{
    internal class DeleteSaleCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}