using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        public async Task <IActionResult> Index()
        {
            var products = await _service.GetProducts();
            return View(products);
        }
    }
}
