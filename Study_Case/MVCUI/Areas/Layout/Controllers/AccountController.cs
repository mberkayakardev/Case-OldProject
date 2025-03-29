using Core.Dtos.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MVCUI.Areas.Layout.Models;
using MVCUI.Models;
using Newtonsoft.Json.Linq;
using NToastNotify;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;

namespace MVCUI.Areas.Layout.Controllers
{
    [Area("Layout")]
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly AppConfigReadModel _Config;
        private readonly IToastNotification _toastNotification;
        public AccountController(HttpClient httpClient, IOptions<AppConfigReadModel> config, IToastNotification toastNotification)
        {
            _httpClient = httpClient;
            _Config = config.Value;
            _toastNotification = toastNotification;

        }
        public IActionResult Singin()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Singin(SigninModel signinmodel)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync($"{_Config.BaseUrl}/Auth/CreateToken", signinmodel);

                if (response.IsSuccessStatusCode)
                {
                    var tokenResult = await response.Content.ReadFromJsonAsync<TokenDto>();

                    var authenticationTokenList = new List<AuthenticationToken>() {

                        new AuthenticationToken {
                        Name=OpenIdConnectParameterNames.AccessToken , Value = tokenResult.AccessToken

                        }
                    };

                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(tokenResult.AccessToken);

                    var identity = new ClaimsIdentity("MyCookieAuth");
                    identity.AddClaims(jwtToken.Claims);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("MyCookieAuth", principal, new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                    });


                    HttpContext.Session.SetString("access_token", tokenResult.AccessToken);
                    HttpContext.Session.SetString("refresh_token", tokenResult.RefreshToken);

                    _toastNotification.AddSuccessToastMessage("Giriş işlemi başarılı ");

                    return RedirectToAction("Dashboard");
                }
            }

            return View(signinmodel);
        }

        [HttpGet]
        public async Task<IActionResult> SingOut()
        {
            HttpContext.Session.Remove("access_token");
            HttpContext.Session.Remove("refresh_token");
            await HttpContext.SignOutAsync("MyCookieAuth");

            return RedirectToAction("Singin", "Account", new { area = "Layout" });

        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            return RedirectToAction("Index","Home");
        }



        [HttpGet]
        public IActionResult AccessDenied()
        {
           _toastNotification.AddErrorToastMessage("İstenilen sayfaya erişim yetkiniz bulunmamaktadır. lütfen tekrar giriş yapın veya sistem yönetimi ile konuşun");
            return  RedirectToAction("Singin");
        }
    }
}
