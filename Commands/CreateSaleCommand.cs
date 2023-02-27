using MyMicroservice.Models;
using MediatR;
using System.Numerics;

namespace MyMicroservice.Commands
{
    public class CreateSaleCommand : IRequest<Sale>
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public CreateSaleCommand(SaleDto sale)
        {
            ProductId =sale.productId;
            Quantity = sale.quantity;
            Amount = sale.amount;
        }
    }
}
