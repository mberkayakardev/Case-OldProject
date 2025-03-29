using Core.Utilities.Results.MVC.BaseResult;
using Dtos.Concrete.Baskets;

namespace Services.Abstract
{
    public interface IBasketService
    {
        Task<IApiResult> AddBasketItem(AddBasketItemDto dto);
        Task<IApiDataResult<List<ListBasketItems>>> ListBasketItemsForUser(int id);
    }
}
