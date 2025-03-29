using Core.Utilities.Results.MVC.BaseResult;
using Dtos.Concrete.Categories;
using Dtos.Concrete.Products;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Services.Abstract.Base;

namespace Services.Abstract
{
    public interface ICategoryService : IBaseServices
    {
        Task<IApiDataResult<List<ListCategoriesDto>>> GetAllCategoriesWithLandingPage();
        Task<IApiDataResult<UpdateCategoriesDto>> GetCategoryByCategoryId(int id);
        Task<IApiDataResult<ListCategoriesDto>> CreateCategory(CreateCategoriesDto dto);
        Task<IApiDataResult<NoContentResult>> UpdateCategory(UpdateCategoriesDto dto);
        Task<IApiDataResult<List<ListCategoriesDto>>> GetAllCategories();


    }
}
