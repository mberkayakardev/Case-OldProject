using Dtos.Concrete.Categories;
using Dtos.Concrete.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MVCUI.Models;
using NToastNotify;
using System.Net;
using System.Text;
using System.Text.Json;

namespace MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly AppConfigReadModel _Config;
        private readonly IToastNotification _toastNotification;
        public ProductsController(IHttpClientFactory httpClient, IOptions<AppConfigReadModel> config, IToastNotification toastNotification)
        {
            _httpClient = httpClient.CreateClient("ApiClient");
            _Config = config.Value;
            _toastNotification = toastNotification;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = new HttpResponseMessage();

            response = await _httpClient.GetAsync($"{_Config.BaseUrl}/products/all");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var productList = JsonSerializer.Deserialize<List<ListProductDto>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                _toastNotification.AddSuccessToastMessage("Ürünler başarılı bir şekilde listelendi");
                return View(productList);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _toastNotification.AddErrorToastMessage("Oturum süreniz doldu. Lütfen tekrar giriş yapınız. ");
                return RedirectToAction("SingOut", "Account", new { area = "Layout" });
            }

            _toastNotification.AddErrorToastMessage($"Bir hata ile karşılaşıldı : {response.IsSuccessStatusCode}");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var response = new HttpResponseMessage();

            response = await _httpClient.GetAsync($"{_Config.BaseUrl}/categories/all");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var productList = JsonSerializer.Deserialize<List<ListCategoriesDto>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var categoryList = productList.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName

                }).ToList();

                ViewBag.Categories = categoryList;

                return View();

            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _toastNotification.AddErrorToastMessage("Oturum süreniz doldu. Lütfen tekrar giriş yapınız. ");
                return RedirectToAction("SingOut", "Account", new { area = "Layout" });
            }

            _toastNotification.AddErrorToastMessage($"Bir hata ile karşılaşıldı : {response.IsSuccessStatusCode}");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductsDto dto)
        {
            if (!ModelState.IsValid)
            {
                var responsecategory = new HttpResponseMessage();

                responsecategory = await _httpClient.GetAsync($"{_Config.BaseUrl}/categories/all");

                var jsoncategory = await responsecategory.Content.ReadAsStringAsync();
                var productListCategory = JsonSerializer.Deserialize<List<ListCategoriesDto>>(jsoncategory, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var categoryListcategory = productListCategory.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName,
                    Selected = (c.Id == dto.CategoryId ? true : false)

                }).ToList();

                ViewBag.Categories = categoryListcategory;
                return View(dto);


            }

            var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_Config.BaseUrl}/Products", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                _toastNotification.AddSuccessToastMessage("Kayıt işlemi başarı ile gerçekleşti");
                return RedirectToAction("Index");
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _toastNotification.AddErrorToastMessage("Oturum süreniz doldu. Lütfen tekrar giriş yapınız. ");
                return RedirectToAction("SingOut", "Account", new { area = "Layout" });
            }

            var responsecategory2 = new HttpResponseMessage();
            responsecategory2 = await _httpClient.GetAsync($"{_Config.BaseUrl}/categories/all");
            var jsoncategory2 = await responsecategory2.Content.ReadAsStringAsync();
            var productListCategory2 = JsonSerializer.Deserialize<List<ListCategoriesDto>>(jsoncategory2, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            var categoryListcategory2 = productListCategory2.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName,
                Selected = (c.Id == dto.CategoryId ? true : false)

            }).ToList();
            ViewBag.Categories = categoryListcategory2;
            _toastNotification.AddErrorToastMessage($"Bir hata ile karşılaşıldı : {response.IsSuccessStatusCode}");
            return View(dto);

        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var response = new HttpResponseMessage();

            response = await _httpClient.GetAsync($"{_Config.BaseUrl}/products/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<ListProductDto>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var responsecategory = new HttpResponseMessage();
                responsecategory = await _httpClient.GetAsync($"{_Config.BaseUrl}/categories/all");
                var jsoncategory = await responsecategory.Content.ReadAsStringAsync();
                var productListCategory = JsonSerializer.Deserialize<List<ListCategoriesDto>>(jsoncategory, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var categoryListcategory = productListCategory.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName,
                    Selected = (c.Id == product.CategoryId ? true : false )

                }).ToList();

                ViewBag.Categories = categoryListcategory;

                return View(product);

            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _toastNotification.AddErrorToastMessage("Oturum süreniz doldu. Lütfen tekrar giriş yapınız. ");
                return RedirectToAction("SingOut", "Account", new { area = "Layout" });
            }

            _toastNotification.AddErrorToastMessage($"Bir hata ile karşılaşıldı : {response.IsSuccessStatusCode}");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_Config.BaseUrl}/Products", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                _toastNotification.AddSuccessToastMessage("Kayıt işlemi başarı ile gerçekleşti");
                return RedirectToAction("Index");
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _toastNotification.AddErrorToastMessage("Oturum süreniz doldu. Lütfen tekrar giriş yapınız. ");
                return RedirectToAction("SingOut", "Account", new { area = "Layout" });
            }

            var json = await response.Content.ReadAsStringAsync();
            var productList = JsonSerializer.Deserialize<List<ListCategoriesDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var categoryList = productList.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName,
                Selected = (c.Id == dto.CategoryId ? true : false)

            }).ToList();

            ViewBag.Categories = categoryList;

            _toastNotification.AddErrorToastMessage($"Bir hata ile karşılaşıldı : {response.IsSuccessStatusCode}");
            return View(dto);



        }






    }
}
