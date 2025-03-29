using Dtos.Concrete.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
using MVCUI.Models;
using NToastNotify;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly AppConfigReadModel _Config;
        private readonly IToastNotification _toastNotification;

        public CategoriesController(IHttpClientFactory httpClient, IOptions<AppConfigReadModel> config, IToastNotification toastNotification)
        {
            _httpClient = httpClient.CreateClient("ApiClient");
            _Config = config.Value;
            _toastNotification = toastNotification;
        }

        #region List
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{_Config.BaseUrl}/categories/all");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var categories = JsonSerializer.Deserialize<List<ListCategoriesDto>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                _toastNotification.AddSuccessToastMessage($"Kategoriler başarılı bir şekilde listelenmiştir. ");
                return View(categories);

            }
            _toastNotification.AddErrorToastMessage($"Listelerken bir hata oluştu : Statu {response.StatusCode} " + response.RequestMessage);
            return View();
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoriesDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_Config.BaseUrl}/Categories", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var errorMessage = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError("", "Kategori oluşturulamadı. Hata: " + errorMessage);
            return View(dto);

        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _httpClient.GetAsync($"{_Config.BaseUrl}/categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var categories = JsonSerializer.Deserialize<UpdateCategoriesDto>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View(categories);

            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                _toastNotification.AddErrorToastMessage($"Aradığınız öğe bulunamadı");
                return NotFound();
            }

            _toastNotification.AddErrorToastMessage($"Bir hata ile karşılaşıldı : {response.StatusCode} "+ Environment.NewLine + Environment.NewLine + response.RequestMessage);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoriesDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_Config.BaseUrl}/Categories", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                _toastNotification.AddSuccessToastMessage("Güncelleme işlemleri başarı ile gerçekleşti");
                return RedirectToAction("Index");
            }

            var errorMessage = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError("", "Kategori oluşturulamadı. Hata: " + errorMessage);
            _toastNotification.AddErrorToastMessage($"Error: {errorMessage}");
            return View(dto);

        }

        #endregion

    }
}
