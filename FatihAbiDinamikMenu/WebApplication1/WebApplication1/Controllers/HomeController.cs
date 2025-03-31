using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var menuItems = GetMenuItems();
            return View(menuItems);
        }
        private List<MenuItem> GetMenuItems()
        {
            var allItems = context.menuItems.ToList();
            return BuildMenuHierarchy(allItems, null);
        }
        private List<MenuItem> BuildMenuHierarchy(List<MenuItem> items, int? parentId)
        {
            return items
                .Where(i => i.ParentId == parentId)
                .Select(i => new MenuItem
                {
                    Id = i.Id,
                    Title = i.Title,
                    Url = i.Url,
                    ParentId = i.ParentId,
                    SubItems = BuildMenuHierarchy(items, i.Id)
                })
                .ToList();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
