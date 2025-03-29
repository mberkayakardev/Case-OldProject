using ApiService.Entities.Concrete.AppEntities;
using AutoMapper;
using Core.Utilities.Results.MVC.BaseResult;
using Dtos.Concrete.Baskets;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using QuizApp.Repositories.EntityFramework.Abstract;
using QuizApp.Services.Abstract.Base;
using Repositories.Migrations;
using Services.Abstract;
using System.Security.Claims;
using System.Xml;
using static Services.Concrete.message.Messages;

namespace Services.Concrete.Services
{
    public class BasketManager : BaseServices, IBasketService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BasketManager(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IApiResult> AddBasketItem(AddBasketItemDto dto)
        {
            var LoginUser = _httpContextAccessor.HttpContext?.User;
            var LoginUserEntity = await _unitOfWork.GetGenericRepositories<AppUser>().GetAsync(x => x.Id == Convert.ToInt32(LoginUser.FindFirst(ClaimTypes.NameIdentifier).Value.ToString()));


            /// İlk olarak Kullanıcının basketi varmı buna bakarız
            var Basket = await _unitOfWork.GetGenericRepositories<Basket>().GetAsync(x => x.AppUserId == LoginUserEntity.Id, IncludeProperties: new System.Linq.Expressions.Expression<Func<Basket, object>>[] { x => x.BasketDetails });
            if (Basket == null) /// Kişinin sepeti yoksa 
            {
                var product = await _unitOfWork.GetGenericRepositories<Products>().GetAsync(x => x.Id == dto.ProductId);

                var newBasket = new Basket
                {
                    AppUserId = LoginUserEntity.Id,
                    TotalPrice = dto.Quantity * product.ProductPrice,
                    BasketDetails = new List<BasketDetail>
                    {
                        new BasketDetail
                        {
                            ProductId = product.Id,
                            ProductPrice = product.ProductPrice,
                            Quantity = dto.Quantity,
                            TotalPrice = dto.Quantity * product.ProductPrice
                        }
                    }
                };

                await _unitOfWork.GetGenericRepositories<Basket>().CreateAsync(newBasket);
                await _unitOfWork.SaveChangesAsync();

                return new ApiResult(status: Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.Created, BasketMessages.AddedBasket);
            }

            var UpdateBasketDetail = Basket.BasketDetails.Where(x => x.ProductId == dto.ProductId).ToList();
            if (UpdateBasketDetail.Count == 0 )
            {
                var product = await _unitOfWork.GetGenericRepositories<Products>().GetAsync(x => x.Id == dto.ProductId);


                Basket.BasketDetails.Add(new BasketDetail
                {
                    ProductId = product.Id,
                    ProductPrice = product.ProductPrice,
                    Quantity = dto.Quantity,
                    TotalPrice = dto.Quantity * product.ProductPrice
                });

                Basket.TotalPrice = Basket.BasketDetails.Sum(x => x.TotalPrice);

                await _unitOfWork.GetGenericRepositories<Basket>().UpdateAsync(Basket);
                await _unitOfWork.SaveChangesAsync();

                return new ApiResult(status: Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.Created, BasketMessages.AddedBasket);


            }
            else  /// Kişinin sepeti varsa aynı ürünün olup olmadığına bakacağız ona göre hesaplama + Quantity artışı yapıp kaydedeceğiz 
            {
                var product = await _unitOfWork.GetGenericRepositories<Products>().GetAsync(x => x.Id == dto.ProductId);


                var UpdatedBasketDetail = Basket.BasketDetails.Where(x => x.ProductId == dto.ProductId).FirstOrDefault();
                UpdatedBasketDetail.Quantity += dto.Quantity;
                UpdatedBasketDetail.TotalPrice  = UpdatedBasketDetail.Quantity * product.ProductPrice;

                Basket.TotalPrice = Basket.BasketDetails.Sum(x => x.TotalPrice);

                await _unitOfWork.SaveChangesAsync();

                return new ApiResult(status: Core.Utilities.Results.MVC.ComplexTypes.ApiResultStatus.Created, BasketMessages.AddedBasket);

            }

        }

        public async Task<IApiDataResult<List<ListBasketItems>>> ListBasketItemsForUser(int id)
        {
            var LoginUserEntity = await _unitOfWork.GetGenericRepositories<AppUser>().GetAsync(x => x.Id == id);
            var Basket = await _unitOfWork.GetGenericRepositories<Basket>().GetAsync(x => x.AppUserId == LoginUserEntity.Id, IncludeProperties: new System.Linq.Expressions.Expression<Func<Basket, object>>[] { x => x.BasketDetails, x=> x.BasketDetails.Select(x=> x.Basket), x => x.BasketDetails.Select(x => x.Products) });
            return null;


        }
    }
}
