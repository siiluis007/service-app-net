using MyMicroservice.Models;
using MyMicroservice.Queries;
using MyMicroservice.Repositories;
using MediatR;
using System.Numerics;
using MyMicroservice.Responses;

namespace MyMicroservice.Handlers
{
    public class GetPriceProductListHandler :  IRequestHandler<GetPriceProductListQuery, List<PriceProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetPriceProductListHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<PriceProductResponse>> Handle(GetPriceProductListQuery query, CancellationToken cancellationToken)
        {
            return await _productRepository.GetPriceProductListAsync();
        }
    }
}
