using MediatR;

namespace MyMicroservice.Commands
{
    public class DeleteStockCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}