using CleanArchMVC.Application.Products.Queries;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;

namespace CleanArchMVC.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _repository;

        public GetProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProductsAsync();
        }
    }
}
