using CleanArchMVC.Application.DTOs;

namespace CleanArchMVC.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategory(int? id);
        Task Add(CategoryDTO category);
        Task Update(CategoryDTO category);
        Task Remove(int? id);
    }
}
