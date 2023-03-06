using MediatR;

namespace MyMicroservice.Controllers
{
    public class DeleteSaleCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}