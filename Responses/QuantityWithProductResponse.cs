using MyMicroservice.Models;

namespace MyMicroservice.Responses
{
    public class QuantityWithProductResponse: PriceProductResponse
    {
        public int quantity { get;  }
        public QuantityWithProductResponse(Product product, int _quantity):base(product){
            quantity = _quantity;
        }
  
    }
}