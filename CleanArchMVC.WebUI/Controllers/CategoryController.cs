using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var categoriaDTO = await _service.GetCategory(id);

            if (categoriaDTO == null) return NotFound();

            return View(categoriaDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(category);
                }
                catch (Exception ex)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var dto = await _service.GetCategory(id);

            if (dto == null) return NotFound();


            return View(dto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var categoriaDTO = await _service.GetCategory(id);

            if (categoriaDTO == null) return NotFound();

            return View(categoriaDTO);
        }
    }
}
