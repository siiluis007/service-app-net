using MyMicroservice.Data;
using MyMicroservice.Models;
using MyMicroservice.Responses;
using Microsoft.EntityFrameworkCore;


namespace MyMicroservice.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContextClass _dbContext;

        public ProductRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddAsync(Product item)
        {
            var result = _dbContext.Products.Add(item);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.ProductId == Id).FirstOrDefault();
            _dbContext.Products.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int Id)
        {
            return await _dbContext.Products.Where(x => x.ProductId == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetListAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<List<PriceProductResponse>> GetPriceProductListAsync()
        {
            return await _dbContext.Products.Select(x => new PriceProductResponse(x) ).ToListAsync();
        }

        public async Task<int> UpdateAsync(Product item)
        {
            _dbContext.Products.Update(item);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
