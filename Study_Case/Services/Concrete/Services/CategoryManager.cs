using AutoMapper;
using Core.Utilities.Managers;
using Core.Utilities.Results.MVC.BaseResult;
using Core.Utilities.Results.MVC.ComplexTypes;
using Dtos.Concrete.Categories;
using Entities.Concrete;
using FluentValidation;
using QuizApp.Repositories.EntityFramework.Abstract;
using QuizApp.Services.Abstract.Base;
using Services.Abstract;
using Services.Concrete.Messages;
using Core.Extentions.Concrete.FluentApi;
using static Services.Concrete.message.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Services.Concrete.Services
{
    public class CategoryManager : BaseServices, ICategoryService
    {
        private readonly MemoryCacheManager _cacheManager;
        private readonly IValidator<CreateCategoriesDto> CreateCategoryValidaton;
        private readonly IValidator<UpdateCategoriesDto> UpdateCategoryValidaton;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper, MemoryCacheManager cacheManager, IValidator<CreateCategoriesDto> createCategoryValidaton, IValidator<UpdateCategoriesDto> updateCategoryValidaton) : base(unitOfWork, mapper)
        {
            _cacheManager = cacheManager;
            CreateCategoryValidaton = createCategoryValidaton;
            UpdateCategoryValidaton = updateCategoryValidaton;
        }

        public async Task<IApiDataResult<ListCategoriesDto>> CreateCategory(CreateCategoriesDto dto)
        {
            var validationResult = CreateCategoryValidaton.Validate(dto);
            if (validationResult.IsValid)
            {
                var Mapping = _mapper.Map<Categories>(dto);
                await _unitOfWork.GetGenericRepositories<Categories>().CreateAsync(Mapping);
                await _unitOfWork.SaveChangesAsync();
                var ResultMapping = _mapper.Map<ListCategoriesDto>(Mapping);

                return new ApiDataResult<ListCategoriesDto>(ResultMapping, ApiResultStatus.Created);

            }
            return new ApiDataResult<ListCategoriesDto>(null, ApiResultStatus.BadRequest, Category.ValidatonError, validationResult.GetErrrors());
        }



        public async Task<IApiDataResult<List<ListCategoriesDto>>> GetAllCategoriesWithLandingPage()
        {
            var memroyCachedata = _cacheManager.Get<List<ListCategoriesDto>>(ConstVerables.AllActiveCategoryCacheKey);
            if (memroyCachedata == null || memroyCachedata.Count == 0)
            {
                var result = await _unitOfWork.GetGenericRepositories<Categories>().GetAllAsync(x => x.IsActive == true);
                if (result != null && result.Count > 0)
                {
                    var MappedData = _mapper.Map<List<ListCategoriesDto>>(result);
                    _cacheManager.Create<List<ListCategoriesDto>>(ConstVerables.AllActiveCategoryCacheKey, MappedData);
                    return new ApiDataResult<List<ListCategoriesDto>>(MappedData, ApiResultStatus.Ok);
                }
                return new ApiDataResult<List<ListCategoriesDto>>(null, ApiResultStatus.NotFound);

            }
            return new ApiDataResult<List<ListCategoriesDto>>(memroyCachedata, ApiResultStatus.Ok); ;

        }

        public async Task<IApiDataResult<List<ListCategoriesDto>>> GetAllCategories()
        {
            var Entities = await _unitOfWork.GetGenericRepositories<Categories>().GetAllAsync(x => x.IsActive == true);
            if (Entities.Count == 0)
                return new ApiDataResult<List<ListCategoriesDto>>(null, ApiResultStatus.NotFound);  

            var mappedEntities = _mapper.Map<List<ListCategoriesDto>>(Entities);

            return new ApiDataResult<List<ListCategoriesDto>>(mappedEntities, ApiResultStatus.Ok);

        }

        public async Task<IApiDataResult<UpdateCategoriesDto>> GetCategoryByCategoryId(int id)
        {
            var Entities = await _unitOfWork.GetGenericRepositories<Categories>().GetAsync(x => x.Id == id);
            if (Entities == null)
                return new ApiDataResult<UpdateCategoriesDto>(null, ApiResultStatus.NotFound);

            var mappedEntities = _mapper.Map<UpdateCategoriesDto>(Entities);

            return new ApiDataResult<UpdateCategoriesDto>(mappedEntities, ApiResultStatus.Ok);
        }

        public async Task<IApiDataResult<NoContentResult>> UpdateCategory(UpdateCategoriesDto dto)
        {
            var validationResult = UpdateCategoryValidaton.Validate(dto);
            if (validationResult.IsValid)
            {
                var Mapping = _mapper.Map<Categories>(dto);
                await _unitOfWork.GetGenericRepositories<Categories>().UpdateAsync(Mapping);
                await _unitOfWork.SaveChangesAsync();

                return new ApiDataResult<NoContentResult>(null, ApiResultStatus.Created);

            }
            return new ApiDataResult<NoContentResult>(null, ApiResultStatus.BadRequest, Category.ValidatonError, validationResult.GetErrrors());


        }
    }
}
