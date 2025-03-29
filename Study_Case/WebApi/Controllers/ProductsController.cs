using Core.Extentions.Concrete.Controller.Api;
using Core.Utilities.Results.MVC.BaseResult;
using Dtos.Concrete.Categories;
using Dtos.Concrete.Products;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace WebApi.Controllers
{
    public class ProductsController : CostumeApiController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "products")]
        public async Task<IActionResult> GetProductListForLanding([FromQuery] int? CategoryIdList)
        {
            return ActionResultInstance(await _productService.GetAllProductsWithLandingPage(CategoryIdList));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoriesListForLanding(int id)
        {
            return ActionResultInstance(await _productService.GetProductByProductId(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllCategories()
        {
            return ActionResultInstance(await _productService.GetAllProduts());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "products")]
        public async Task<IActionResult> CreateProduct(CreateProductsDto dto)
        {
            return ActionResultInstance(await _productService.CreateProduct(dto));
        }



        [Authorize(Roles = "Admin")]
        [HttpPut(Name = "products")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            return ActionResultInstance(await _productService.UpdateProduct(dto));
        }



        //[HttpPost(Name = "products")]
        //public async Task<IActionResult> CreateProduct(CreateProductDto)
        //{
        //    return ActionResultInstance(await _productService.GetAllProductsWithLandingPage(CategoryIdList));
        //}

        //[HttpGet(Name = "categories/{CategoryIdList}")]
        //public async Task<IActionResult> GetProductWithCategoryListForLanding([FromQuery]int? CategoryIdList)
        //{
        //    return ActionResultInstance( await _productService.GetAllProductsWithLandingPage(CategoryIdList));
        //}
    }
}
