using MyMicroservice.Models;
using MyMicroservice.Queries;
using MyMicroservice.Repositories;
using MediatR;


namespace MyMicroservice.Handlers
{
    public class GetProductListHandler :  IRequestHandler<GetProductListQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductListHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(GetProductListQuery query, CancellationToken cancellationToken)
        {
            return await _productRepository.GetListAsync();
        }
    }
}
