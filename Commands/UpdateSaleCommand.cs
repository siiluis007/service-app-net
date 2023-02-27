using MediatR;

namespace MyMicroservice.Controllers
{
    internal class UpdateSaleCommand : IRequest<int>
    {
        private SaleUpdateDto product;

        public UpdateSaleCommand(SaleUpdateDto product)
        {
            this.product = product;
        }
    }
}