namespace MyMicroservice.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }        
        public string Document { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime CreatedTimestamp { get; set; }

    }

}
