namespace MyMicroservice.Responses
{
    public class GetLastSaleByCustomerResponse
    {
        public int? idSale {get;set;}
        public string name { get; set; }
        public string? product { get; set; }
        public DateTime? lastSale {get;set;}
    }

     
}