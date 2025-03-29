using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Cookie
{
    public class CookieManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CookieManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Create(string key, string value, int? expireTimeInMinutes = null)
        {
            var options = new CookieOptions
            {
                IsEssential = true,
                HttpOnly = false,
                Secure = true, // HTTPS kullanıyorsanız true olmalı
                SameSite = SameSiteMode.Lax // İsteğe göre Strict / None yapabilirsiniz
            };

            if (expireTimeInMinutes.HasValue)
            {
                options.Expires = DateTimeOffset.Now.AddMinutes(expireTimeInMinutes.Value);
            }

            //var context = _httpContextAccessor.HttpContext;
            //if (context.Request.Cookies.ContainsKey(key))
            //{
            //    context.Response.Cookies.Delete(key);
            //}

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, options);
        }
        public string Get(string key)
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(key, out string value);
            return value;
        }
        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }

    }
}
