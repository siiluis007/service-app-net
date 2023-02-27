using MyMicroservice.Models;
using MyMicroservice.Responses;
namespace MyMicroservice.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetListAsync();
        public Task<Product> GetByIdAsync(int id);
        public Task<List<PriceProductResponse>> GetPriceProductListAsync();
        public Task<Product> AddAsync(Product item);
        public Task<int> UpdateAsync(Product item);
        public Task<int> DeleteAsync(int id);
    }
}
