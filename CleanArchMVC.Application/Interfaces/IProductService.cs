using CleanArchMVC.Application.DTOs;

namespace CleanArchMVC.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProduct(int? id);
        Task Add(ProductDTO product);
        Task Update(ProductDTO product);
        Task Remove(int? id);
    }
}
