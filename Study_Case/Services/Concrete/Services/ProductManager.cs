using AutoMapper;
using Core.Extentions.Concrete.FluentApi;
using Core.Utilities.Results.MVC.BaseResult;
using Core.Utilities.Results.MVC.ComplexTypes;
using Dtos.Concrete.Categories;
using Dtos.Concrete.Products;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Repositories.EntityFramework.Abstract;
using QuizApp.Services.Abstract.Base;
using Services.Abstract;
using static Services.Concrete.message.Messages;

namespace Services.Concrete.Services
{
    public class ProductManager : BaseServices, IProductService
    {
        private readonly IValidator<CreateProductsDto> _CreateProductValidator;
        private readonly IValidator<UpdateProductDto> _UpdateProductValidator;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateProductsDto> createProductValidator, IValidator<UpdateProductDto> updateProductValidator) : base(unitOfWork, mapper)
        {
            _CreateProductValidator = createProductValidator;
            _UpdateProductValidator = updateProductValidator;
        }

        public async Task<IApiDataResult<ListProductDto>> CreateProduct(CreateProductsDto dto)
        {
            var validationResult = _CreateProductValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var Mapping = _mapper.Map<Products>(dto);
                await _unitOfWork.GetGenericRepositories<Products>().CreateAsync(Mapping);
                await _unitOfWork.SaveChangesAsync();
                var ResultMapping = _mapper.Map<ListProductDto>(Mapping);

                return new ApiDataResult<ListProductDto>(ResultMapping, ApiResultStatus.Created);

            }
            return new ApiDataResult<ListProductDto>(null, ApiResultStatus.BadRequest, Category.ValidatonError, validationResult.GetErrrors());
        }

        public async Task<IApiDataResult<List<ListProductDto>>> GetAllProductsWithLandingPage(int? CategoryIdList)
        {
            var repository = await _unitOfWork.GetGenericRepositories<Products>().GetAllAsync(x => x.IsActive == true && (CategoryIdList.HasValue ? x.CategoryId == CategoryIdList : true));
            if (repository != null && repository.Count > 0)
            {
                var MappedProduct = _mapper.Map<List<ListProductDto>>(repository);
                return new ApiDataResult<List<ListProductDto>>(MappedProduct, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.Ok);
            }

            return new ApiDataResult<List<ListProductDto>>(null, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.NotFound);

        }

        public async Task<IApiDataResult<List<ListProductDto>>> GetAllProduts()
        {
            var repository = await _unitOfWork.GetGenericRepositories<Products>().GetAllAsync(IncludeProperties: new System.Linq.Expressions.Expression<Func<Products, object>>[] {x=> x.Category});
            if (repository != null && repository.Count > 0)
            {
                var MappedProduct = _mapper.Map<List<ListProductDto>>(repository);
                return new ApiDataResult<List<ListProductDto>>(MappedProduct, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.Ok);
            }

            return new ApiDataResult<List<ListProductDto>>(null, Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.NotFound);
        }

        public async Task<IApiDataResult<ListProductDto>> GetProductByProductId(int id)
        {
            var Entities = await _unitOfWork.GetGenericRepositories<Products>().GetAsync(x => x.Id == id);
            if (Entities == null)
                return new ApiDataResult<ListProductDto>(null, ApiResultStatus.NotFound);

            var mappedEntities = _mapper.Map<ListProductDto>(Entities);

            return new ApiDataResult<ListProductDto>(mappedEntities, ApiResultStatus.Ok);

        }

        public async Task<IApiDataResult<NoContentResult>> UpdateProduct(UpdateProductDto dto)
        {
            var validationResult = _UpdateProductValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var Mapping = _mapper.Map<Products>(dto);
                await _unitOfWork.GetGenericRepositories<Products>().UpdateAsync(Mapping);
                await _unitOfWork.SaveChangesAsync();
                return new ApiDataResult<NoContentResult>(null, ApiResultStatus.Created);
            }
            return new ApiDataResult<NoContentResult>(null, ApiResultStatus.BadRequest, Category.ValidatonError, validationResult.GetErrrors());
        }
    }
}
