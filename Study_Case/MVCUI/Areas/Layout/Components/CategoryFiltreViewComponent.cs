using Core.Utilities.Managers;
using Dtos.Concrete.Categories;
using Dtos.Concrete.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVCUI.Models;
using Services.Concrete.Messages;
using System.Text.Json;

namespace MVCUI.Areas.Layout.Components
{
    public class CategoryFiltreViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly AppConfigReadModel _Config;
        private readonly MemoryCacheManager _MemoryCacheManager;
        public CategoryFiltreViewComponent(IHttpClientFactory httpClient, IOptions<AppConfigReadModel> config, MemoryCacheManager memoryCacheManager)
        {

            _httpClient = httpClient.CreateClient();
            _Config = config.Value;
            _MemoryCacheManager = memoryCacheManager;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = _MemoryCacheManager.Get<List<ListCategoriesDto>>(ConstVerables.AllActiveCategoryCacheKey);
            if (data != null && data.Count > 0)
            {
                return View(data);
            }


            var response = await _httpClient.GetAsync($"{_Config.BaseUrl}/Categories");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var CategoryList = JsonSerializer.Deserialize<List<ListCategoriesDto>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                _MemoryCacheManager.Create<List<ListCategoriesDto>>(ConstVerables.AllActiveCategoryCacheKey, CategoryList);


                return View(CategoryList);

            }
            return View();
        }

    }
}
