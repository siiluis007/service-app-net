using MyMicroservice.Data;
using MyMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;

namespace MyMicroservice.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbContextClass _dbContext;

        public CustomerRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> AddAsync(Customer item)
        {
            var result = _dbContext.Customers.Add(item);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var filteredData = _dbContext.Customers.Where(x => x.CustomerId == Id).FirstOrDefault();
            _dbContext.Customers.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Customer> GetByIdAsync(int Id)
        {
            return await _dbContext.Customers.Where(x => x.CustomerId == Id).FirstOrDefaultAsync();
        }
/* 
        public async Task<List<Customer>> GetListAsync()
        {
            return await _dbContext.Customers.Take(100).ToListAsync();
        }
 */
         public async Task<List<Customer>> GetListAsync()
        {
            return await _dbContext.Customers.Where(x=>x.age <=35).Take(100).ToListAsync();
        }

        public async Task<int> UpdateAsync(Customer item)
        {
            _dbContext.Customers.Update(item);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
