using MyMicroservice.Models;
namespace MyMicroservice.Repositories
{
    public interface ICustomerRepository
    {
         public Task<List<Customer>> GetListAsync();
        public Task<Customer> GetByIdAsync(int id);
        public Task<Customer> AddAsync(Customer item);
        public Task<int> UpdateAsync(Customer item);
        public Task<int> DeleteAsync(int id);
    }
}
