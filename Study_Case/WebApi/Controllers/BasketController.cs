using Core.Extentions.Concrete.Controller.Api;
using Dtos.Concrete.Baskets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace WebApi.Controllers
{
    public class BasketController : CostumeApiController
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost]
        [Authorize()]
        public async Task<IActionResult> AddBasketItem(AddBasketItemDto dto)
        {
      
            return ActionResultInstance(await _basketService.AddBasketItem(dto));
        }

        [HttpGet]
        [Authorize()]
        [HttpGet("user/{id}")]

        public async Task<IActionResult> GetBasketItem(int id)
        {
            return ActionResultInstance(await _basketService.ListBasketItemsForUser(id));
        }




        
    }
}

