using MyMicroservice.Data;
using MyMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using MyMicroservice.Responses;


namespace MyMicroservice.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly DbContextClass _dbContext;

        public StockRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Stock> AddAsync(Stock stock)
        {
            var result = _dbContext.Stocks.Add(stock);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var filteredData = _dbContext.Stocks.Where(x => x.StockId == Id).FirstOrDefault();
            _dbContext.Stocks.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Stock> GetByIdAsync(int Id)
        {
            return await _dbContext.Stocks.Where(x => x.StockId == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Stock>> GetListAsync()
        {
            return await _dbContext.Stocks.ToListAsync();
        }

        public async Task<List<StockByQuantity>> GetStockByQuantityAsync(int quantity)
        {
            try
            {
                var result = await _dbContext.Stocks.Where(x => x.Quantity == quantity).Include(x =>x.Product)
                .Select(x => new StockByQuantity (x.Product,x.Quantity))
                .ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }


        }

        public async Task<int> UpdateAsync(Stock stock)
        {
            _dbContext.Stocks.Update(stock);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
