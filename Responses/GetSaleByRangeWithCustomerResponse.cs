using MyMicroservice.Models;

namespace MyMicroservice.Responses
{
    public class SaleByRangeWithCustomer {

        public int id { get; set; }
        public string? document { get; set; }

        public string? fullName { get; set; }

        public int age { get; set; }
        public DateTime dateSale { get; set; }
    }

}

