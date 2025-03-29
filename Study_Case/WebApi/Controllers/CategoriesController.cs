using Core.Extentions.Concrete.Controller.Api;
using Dtos.Concrete.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace WebApi.Controllers
{
    public class CategoriesController : CostumeApiController
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public CategoriesController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        /// <summary>
        /// Get All
        /// </summary>
        [HttpGet(Name ="categories")]
        public async Task<IActionResult> GetCategoriesListForLanding()
        {
            return ActionResultInstance(await _categoryService.GetAllCategoriesWithLandingPage());
        }

        /// <summary>
        ///  Get By Id
        /// </summary>

        [Authorize(Roles = "Admin")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoriesListForLanding(int id)
        {
            return ActionResultInstance(await _categoryService.GetCategoryByCategoryId(id));
        }

        /// <summary>
        /// Get Active All
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllCategories()
        {
            return ActionResultInstance(await _categoryService.GetAllCategories());
        }

        /// <summary>
        /// Get Proucts For Category ID 
        /// </summary>
        /// 
        [HttpGet("{categoryId}/products")]
        public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
        {
            return ActionResultInstance(await _productService.GetAllProductsWithLandingPage(categoryId));
        }





        [Authorize(Roles = "Admin")]
        [HttpPost(Name ="categories")]
        public async Task<IActionResult> CreateProduct(CreateCategoriesDto dto)
        {
            return ActionResultInstance(await _categoryService.CreateCategory(dto));
        }




        [Authorize(Roles = "Admin")]
        [HttpPut(Name = "categories")]
        public async Task<IActionResult> UpdateProduct(UpdateCategoriesDto dto)
        {
            return ActionResultInstance(await _categoryService.UpdateCategory(dto));
        }






    }
}
