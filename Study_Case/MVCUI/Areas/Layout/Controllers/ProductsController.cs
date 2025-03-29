using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVCUI.Models;
using Services.Abstract;

namespace MVCUI.Areas.Layout.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly AppConfigReadModel _Config;
        public ProductsController(IHttpClientFactory httpClient, IOptions<AppConfigReadModel> config)
        {

            _httpClient = httpClient.CreateClient();
            _Config = config.Value;
        }


        public IActionResult Products(int? categoryId)
        {
            //var products = _productService.GetAll();

            //if (categoryId.HasValue)
            //{
            //    products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            //}

            //var categories = _categoryService.GetAll(); // sidebar için

            //ViewBag.Categories = categories;
            //return View(products);
            return View();
        }

    }
}
