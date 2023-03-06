using MediatR;
using MyMicroservice.Models;

namespace MyMicroservice.Commands
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public UpdateCustomerCommand(CustomerUpdateDto item)
        {
            Id = item.id;
            Document = item.document;
            Name = item.name;
            LastName = item.lastName;
            Age = item.age;
        }
    }
}
