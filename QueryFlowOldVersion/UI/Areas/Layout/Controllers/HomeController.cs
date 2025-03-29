using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Layout.Controllers
{
    [Area("Layout")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
