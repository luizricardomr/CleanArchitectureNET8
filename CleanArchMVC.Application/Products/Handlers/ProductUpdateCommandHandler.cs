using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;

namespace CleanArchMVC.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductUpdateCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
                throw new ApplicationException($"Product could not be found.");

            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

            return await _repository.UpdateAsync(product);
        }
    }
}
