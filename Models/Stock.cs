using System.ComponentModel.DataAnnotations.Schema;

namespace MyMicroservice.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice {get;set;}
        public DateTime CreatedTimestamp { get; set; }

        public int ProductId {get;set;}
        public Product Product {get;set;}
    }
}
