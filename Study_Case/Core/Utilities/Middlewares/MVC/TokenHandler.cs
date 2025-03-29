using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Core.Dtos.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace Core.Utilities.Middlewares.MVC
{
    public class TokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public TokenHandler(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
   
            var accessToken = _httpContextAccessor.HttpContext.Session.GetString("access_token");
            var refreshToken = _httpContextAccessor.HttpContext.Session.GetString("refresh_token");

            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
   

            var response = await base.SendAsync(request, cancellationToken);

            // Eğer yetkisizsa (401), token yenile
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && !string.IsNullOrEmpty(refreshToken))
            {
                var newTokens = await RefreshAccessToken(refreshToken);
                if (newTokens != null)
                {
                    // Yeni token'ları session'a kaydet
                    _httpContextAccessor.HttpContext.Session.SetString("access_token", newTokens.AccessToken);
                    _httpContextAccessor.HttpContext.Session.SetString("refresh_token", newTokens.RefreshToken);

                    // İsteği yeniden oluştur
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", newTokens.AccessToken);
                    request.Content?.Headers.ContentLength.Equals(request.Content?.ReadAsByteArrayAsync().Result.Length);


                    // İsteği tekrar gönder
                    response = await base.SendAsync(request, cancellationToken);
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await ForceLogout();
                    }
                }
                else
                {
                    await ForceLogout();
                }
             
            }
            return response;
        }

        private async Task ForceLogout()
        {
            var context = _httpContextAccessor.HttpContext;
            context.Session.Remove("access_token");
            context.Session.Remove("refresh_token");
            context.Session.Clear();
            await context.SignOutAsync("MyCookieAuth");
        }

        private async Task<TokenDto?> RefreshAccessToken(string refreshToken)
        {
            using var client = new HttpClient();
            var refreshRequest = new
            {
                RefreshToken = refreshToken
            };
            var content = new StringContent(JsonSerializer.Serialize(refreshRequest), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_configuration["ApiSettings:RefreshToken"]+ $"?Token={refreshToken}", content);
            if (response.IsSuccessStatusCode)
            {
                var resultString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TokenDto>(resultString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return null;
        }

    }
}
