using MyMicroservice.Models;
using MediatR;
using MyMicroservice.Responses;

namespace MyMicroservice.Queries
{
    public class GetStockByQuantityQuery : IRequest<List<StockByQuantity>>
    {
        public int quantity { get; set; }
    }
}
