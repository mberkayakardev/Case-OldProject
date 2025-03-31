using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
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
    }
}
