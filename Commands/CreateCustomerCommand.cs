using MyMicroservice.Models;
using MediatR;
using System.Numerics;

namespace MyMicroservice.Commands
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public int Id { get; set; }
        public string Document {get;set;}
        public string Name { get; set; }
        public string LastName { get; set; }

        public CreateCustomerCommand(CustomerDto customer)
        {
            Document =customer.document;
            Name = customer.name;
            LastName = customer.lastName;
            
        }
    }
}
