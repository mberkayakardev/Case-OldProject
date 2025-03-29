using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    /// <summary>
    /// Global Exceptionlarımızı bu sayfalar üzerinden Handle edeceğiz. 
    /// </summary>
    public class ErrorHandlingController : Controller
    {
        [Route("/exception")]
        public IActionResult ExceptionHandling()
        {
            return View("500");
        }
        [Route("/Error/{statusCode}")]
        public IActionResult Errors(int statusCode)
        {
            if (statusCode == 404)
                return View("404");

            return View("500");
        }

    }
}
