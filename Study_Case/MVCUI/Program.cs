using Core.Utilities.Cookie;
using Core.Utilities.Managers;
using Core.Utilities.Middlewares.MVC;
using Microsoft.Extensions.FileProviders;
using MVCUI.Areas.Layout.Services;
using MVCUI.Models;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
                .AddNToastNotifyToastr(new ToastrOptions
                {
                    PositionClass = ToastPositions.TopRight,
                    TimeOut = 3000,
                    ProgressBar = true
                })
                .AddRazorRuntimeCompilation();


builder.Services.Configure<AppConfigReadModel>(builder.Configuration.GetSection("ApiSettings"));
builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<MemoryCacheManager>();
builder.Services.AddScoped<CookieManager>();
builder.Services.AddScoped<CartManager>();
builder.Services.AddTransient<TokenHandler>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient("ApiClient").AddHttpMessageHandler<TokenHandler>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum süresi
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication("MyCookieAuth")
    .AddCookie("MyCookieAuth", options =>
    {
        options.LoginPath = "/Layout/Account/Singin";
        options.AccessDeniedPath = "/Layout/Account/AccessDenied";
        options.Cookie.Name = "ECommerceCookie";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });


builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

else
{
    app.UseExceptionHandler("/exception");
    app.UseHsts();
}
app.UseNToastNotify();


app.UseStatusCodePagesWithReExecute("/Error/{0}"); // Costume Exception Handler

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/node_modules",
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory() + "/node_modules"))

});

app.UseRouting();

app.UseSession();


app.UseAuthentication();
app.UseAuthorization();

#region Costume Middlewares

#endregion


app.UseEndpoints(e =>
{
    e.MapControllerRoute(name: "defaults", pattern: "{Area=Layout}/{Controller=Home}/{Action=Index}/{id?}");
});


app.Run();