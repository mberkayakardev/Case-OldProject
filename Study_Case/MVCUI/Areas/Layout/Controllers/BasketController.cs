using Dtos.Concrete.Baskets;
using Dtos.Concrete.Products;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVCUI.Areas.Layout.Models;
using MVCUI.Areas.Layout.Services;
using MVCUI.Models;
using NToastNotify;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;

namespace MVCUI.Areas.Layout.Controllers
{
    [Area("Layout")]
    public class BasketController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly AppConfigReadModel _Config;
        private readonly IToastNotification _toastNotification;
        private readonly CartManager cartManager;


        public BasketController(IHttpClientFactory httpClient, IOptions<AppConfigReadModel> config, IToastNotification toastNotification, CartManager cartManager)
        {
            _httpClient = httpClient.CreateClient("ApiClient");
            _Config = config.Value;
            _toastNotification = toastNotification;
            this.cartManager = cartManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {

            }
            var BasketItems = cartManager.GetAllItems();
            return View(BasketItems);
        }


        [HttpPost]
        public async Task<IActionResult> Add(int Id)
        {
            ///// Kullanıcı login durumda ise tüm operasyon 
            //if (User.Identity.IsAuthenticated)
            //{
            //    //var request = new AddBasketItemDto
            //    //{
            //    //    ProductId = Id,
            //    //    Quantity = 1
            //    //};

            //    //var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            //    //var response = await _httpClient.PostAsync($"{_Config.BaseUrl}/Basket", jsonContent);

            //    //if (response.IsSuccessStatusCode)
            //    //{
            //    //    _toastNotification.AddSuccessToastMessage("Sepete eklendi (DB)");
            //    //    return RedirectToAction("Index");
            //    //}
            //    //if (response.StatusCode == HttpStatusCode.Unauthorized)
            //    //{
            //    //    await HttpContext.SignOutAsync("MyCookieAuth");
            //    //    return RedirectToAction("Index", "Home");

            //    //}

            //    //var errorMessage = await response.Content.ReadAsStringAsync();
            //    //_toastNotification.AddSuccessToastMessage($"Bir Hata ile karşılaşıldı : {response.StatusCode}  {response.RequestMessage}");

            //    //return RedirectToAction("Index");

            //}
            //else
            //{

            var response = await _httpClient.GetAsync($"{_Config.BaseUrl}/products/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var productList = JsonSerializer.Deserialize<ListProductDto>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                cartManager.AddToCart(new Models.CartItem
                {
                    Id = productList.Id,
                    ProductPrice = productList.ProductPrice,
                    ProductName = productList.ProductName,
                    Quantity = 1,
                    TotalLinePrice = productList.ProductPrice * 1

                });

                _toastNotification.AddSuccessToastMessage("Sepete eklendi");
                return RedirectToAction("Index");

            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                _toastNotification.AddErrorToastMessage("Aradığınız ürün bulunamadı");
                return RedirectToAction("Index");
            }
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await HttpContext.SignOutAsync("MyCookieAuth");
            }

            _toastNotification.AddErrorToastMessage($"Bir Hata ile karşılaşıldı : Durum : {response.StatusCode} {response.RequestMessage}");
            return RedirectToAction("Index");


            //}

        }


        [HttpPost]
        public async Task<IActionResult> Update(List<CartItemUpdateDto> cartItems)
        {
            cartManager.UpdateCartItemBulkInsert(cartItems);

            _toastNotification.AddSuccessToastMessage("Sepet güncellendi eklendi");
            return RedirectToAction("Index", "Home");
        }


    }
}
