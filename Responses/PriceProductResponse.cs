using MyMicroservice.Models;

namespace MyMicroservice.Responses
{
    public class PriceProductResponse
    {
        public int id { get;  }
        public string name { get;  }
        public double price { get;  }
        public PriceProductResponse(Product product){
            id = product.ProductId;
            name = product.Name;
            price = product.Price;
        }
    }
}
