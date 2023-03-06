namespace MyMicroservice.Models
{
    public class StockUpdateDto
    {

        public int id { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public double purchasePrice { get; set; }
    }
}
