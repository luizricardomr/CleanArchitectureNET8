using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Application.Products.Queries;
using MediatR;

namespace CleanArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _mediator.Send(new GetProductQuery());

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        public async Task<ProductDTO> GetProduct(int? id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id.Value));
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task Add(ProductDTO productDTO)
        {
            var command = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(command);         

        }
        public async Task Update(ProductDTO productDTO)
        {
            var command = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(command);
        }

        public async Task Remove(int? id)
        {
            await _mediator.Send(new ProductRemoveCommand(id.Value));
        }

    }
}
