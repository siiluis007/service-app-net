using MyMicroservice.Models;

namespace MyMicroservice.Responses
{

    public class StockByQuantity : PriceProductResponse
    {
        public int quantity { get; set; }
        public StockByQuantity(Product product, int total) : base(product)
        {
            quantity = total;
        }
    }
    

}