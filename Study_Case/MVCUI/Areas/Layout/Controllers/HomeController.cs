using Dtos.Concrete.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVCUI.Models;
using NToastNotify;
using System.Text.Json;

namespace UI.Areas.Layout.Controllers
{
    [Area("Layout")]
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly AppConfigReadModel _Config;
        private readonly IToastNotification _toastNotification;
        public HomeController(IHttpClientFactory httpClient, IOptions<AppConfigReadModel> config, IToastNotification toastNotification)
        {

            _httpClient = httpClient.CreateClient();
            _Config = config.Value;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index(int CategoryId)
        {
            var response = new HttpResponseMessage();

            if (CategoryId == 0)
            {
                response = await _httpClient.GetAsync($"{_Config.BaseUrl}/products");

            }
            else
            {
                response = await _httpClient.GetAsync($"{_Config.BaseUrl}/Categories/{CategoryId}/products");

            }

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var productList = JsonSerializer.Deserialize<List<ListProductDto>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View(productList);

            }
           
            
            _toastNotification.AddErrorToastMessage($"Bir hata ile karşılaşıldı : {response.IsSuccessStatusCode}");
            return View();
        }
    }
}
