using MediatR;
using MyMicroservice.Models;

namespace MyMicroservice.Commands
{
    public class UpdateStockCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public int ProductId { get; set; }

        public UpdateStockCommand(StockUpdateDto item)
        {
            Id = item.id;
            Quantity = item.quantity;
            PurchasePrice = item.purchasePrice;
            ProductId = item.productId;
        }
    }
}
