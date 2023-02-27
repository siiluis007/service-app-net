using MyMicroservice.Models;
using MyMicroservice.Responses;
namespace MyMicroservice.Repositories
{
    public interface IStockRepository
    {
        public Task<List<Stock>> GetListAsync();
        public Task<Stock> GetByIdAsync(int id);
        public Task<List<StockByQuantity>> GetStockByQuantityAsync(int quantity);
        public Task<Stock> AddAsync(Stock product);
        public Task<int> UpdateAsync(Stock product);
        public Task<int> DeleteAsync(int id);
    }
}
