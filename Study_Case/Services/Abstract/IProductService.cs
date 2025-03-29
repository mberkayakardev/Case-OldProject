using Core.Utilities.Results.MVC.BaseResult;
using Dtos.Concrete.Categories;
using Dtos.Concrete.Products;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Services.Abstract.Base;

namespace Services.Abstract
{
    public interface IProductService : IBaseServices
    {
        Task<IApiDataResult<List<ListProductDto>>> GetAllProductsWithLandingPage(int? CategoryIdList);
        Task<IApiDataResult<List<ListProductDto>>> GetAllProduts();
        Task<IApiDataResult<ListProductDto>> CreateProduct(CreateProductsDto dto);
        Task<IApiDataResult<NoContentResult>> UpdateProduct(UpdateProductDto dto);
        Task<IApiDataResult<ListProductDto>> GetProductByProductId(int id); 
    }
}
