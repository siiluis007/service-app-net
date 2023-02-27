
using System.Text.Json;
using MyMicroservice.Models;

namespace MyMicroservice.DataSeed
{
  
    public static class JsonFileReader
    {
        public  static  List<Product> GetProductsSeed()
        {
            string json = System.IO.File.ReadAllText("DataSeed/SeedProducts.json");
            List<Product> products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(json);
            return products;
        }
        public  static  List<Customer> GetCustomersSeed()
        {
            string json = System.IO.File.ReadAllText("DataSeed/SeedCustomers.json");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Customer>>(json);
        }

        public  static  List<Stock> GetStocksSeed()
        {
            string json = System.IO.File.ReadAllText("DataSeed/SeedStocks.json");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Stock>>(json);
        }

        public  static  List<Sale> GetSalesSeed()
        {
            string json = System.IO.File.ReadAllText("DataSeed/SeedSales.json");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Sale>>(json);
        }
    }

}

