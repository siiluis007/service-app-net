using MyMicroservice.Models;
using MediatR;
using System.Numerics;

namespace MyMicroservice.Commands
{
    public class CreateStockCommand : IRequest<Stock>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public CreateStockCommand(StockDto stock)
        {
            Title =stock.title;
            Quantity = stock.quantity;
            ProductId = stock.productId;
            
        }
    }
}
