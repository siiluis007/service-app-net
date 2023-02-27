using MyMicroservice.Data;
using MyMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using MyMicroservice.Responses;

namespace MyMicroservice.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DbContextClass _dbContext;

        public SaleRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Sale> AddAsync(Sale item)
        {
            var result = _dbContext.Sales.Add(item);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var filteredData = _dbContext.Sales.Where(x => x.SaleId == Id).FirstOrDefault();
            _dbContext.Sales.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Sale> GetByIdAsync(int Id)
        {
            return await _dbContext.Sales.Where(x => x.SaleId == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Sale>> GetListAsync()
        {
            return await _dbContext.Sales.ToListAsync();
        }

        public async Task<int> UpdateAsync(Sale item)
        {
            _dbContext.Sales.Update(item);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<SaleByRangeWithCustomer>> GetSaleByRangeWithCustomerAsync(string dateFrom, string dateTo, int age)
        {
            DateTime dtFrom = Convert.ToDateTime(dateFrom);
            DateTime dtTo = Convert.ToDateTime(dateTo);
            var result = await _dbContext.Sales
            .Where(x => x.CreatedTimestamp >= dtFrom && x.CreatedTimestamp <= dtTo && x.Customer.age <= age)
            .GroupBy(x => x.Customer)
            .Select(x => new SaleByRangeWithCustomer()
            {
                id = x.First().SaleId,
                document = x.First().Customer.Document,
                fullName = x.First().Customer.Name + " " + x.First().Customer.LastName,
                age = x.First().Customer.age,
                dateSale = x.First().CreatedTimestamp
            })
                .OrderByDescending(x => x.age)
            .ToListAsync();
            return result;
        }

        public async Task<List<AmountTotalProduct>> GetAmountTotalProductAsync(string dateFrom, string dateTo)
        {
            DateTime dtFrom = Convert.ToDateTime(dateFrom);
            DateTime dtTo = Convert.ToDateTime(dateTo);
            var result = await _dbContext.Sales
            .Where(x => x.CreatedTimestamp >= dtFrom && x.CreatedTimestamp <= dtTo)
            .GroupBy(x => x.Product.ProductId)
            .Select(x => new AmountTotalProduct()
            {
                product = x.First().Product.Name,
                AmountTotal = x.Sum(x => x.Amount)
            })
            .ToListAsync();
            return result;
        }

        public async Task<GetLastSaleByCustomerResponse> GetLastSaleByCustomerAsync(int id)
        {
            var result = await _dbContext
            .Sales.Where(x => x.CustomerId == id)
            .Select(x => new GetLastSaleByCustomerResponse()
            {
                name = x.Customer.Name + " " + x.Customer.LastName,
                idSale = x.SaleId,
                product = x.Product.Name,
                lastSale = x.CreatedTimestamp
            })
            .OrderBy(x => x.idSale).ToListAsync();
           if (result.Count ==0)
            {
                return new GetLastSaleByCustomerResponse() { };
            } 
            return result[0];
        }
    }
}
