using MediatR;

namespace MyMicroservice.Commands
{
    public class DeleteCustomerCommand: IRequest<int>
    {
         public int Id { get; set; }
    }
}