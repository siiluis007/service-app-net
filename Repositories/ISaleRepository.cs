using MyMicroservice.Models;
using MyMicroservice.Responses;

namespace MyMicroservice.Repositories
{
    public interface ISaleRepository
    {
        public Task<List<Sale>> GetListAsync();
        public Task<Sale> GetByIdAsync(int id);
        public Task<Sale> AddAsync(Sale item);
        public Task<int> UpdateAsync(Sale item);
        public Task<int> DeleteAsync(int id);
        public Task<List<SaleByRangeWithCustomer>> GetSaleByRangeWithCustomerAsync(string dateFrom, string dateTo, int age);
        public Task<List<AmountTotalProduct>> GetAmountTotalProductAsync(string dateFrom, string dateTo);
        public Task<GetLastSaleByCustomerResponse> GetLastSaleByCustomerAsync(int id);

    }
}
