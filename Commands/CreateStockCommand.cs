using MyMicroservice.Models;
using MediatR;
using System.Numerics;

namespace MyMicroservice.Commands
{
    public class CreateStockCommand : IRequest<Stock>
    {

        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public double purchasePrice { get; set; }

        public CreateStockCommand(StockDto stock)
        {
            purchasePrice = stock.purchasePrice;
            Quantity = stock.quantity;
            ProductId = stock.productId;
        }
    }
}
