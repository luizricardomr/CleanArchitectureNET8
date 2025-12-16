using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;

namespace CleanArchMVC.Application.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }
        public async Task<CategoryDTO> GetCategory(int? id)
        {
            var category = await _categoryRepository.GetById(id);

            return _mapper.Map<CategoryDTO>(category);
        }


        public async Task Add(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Create(category);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            category.Id = categoryDTO.Id;
            await _categoryRepository.Update(category);
        }


        public async Task Remove(int? id)
        {
            var category = await _categoryRepository.GetById(id);
            await _categoryRepository.Remove(category);
        }        
    }
}
