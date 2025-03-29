using Microsoft.Extensions.FileProviders;
using Services.DependencyResolves.Microsoft;

#region Services

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation(); /// MVC nin eklenmesi için eklendi. 


builder.Services.AddDependencies(builder.Configuration,builder.Environment);
#endregion

var app = builder.Build();

#region Middlewares

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
{
    app.UseExceptionHandler("/exception");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error/{0}"); // Costume Exception Handler


app.UseHttpsRedirection(); /// HTTP leri HTTPS e yönlendirir 

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/npm" ,
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory() + "/node_modules"))

});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

#region Costume Middlewares
/// Bu alana costume middleware ler yazılacaktır. 
#endregion

app.UseEndpoints(e =>
{
    e.MapControllerRoute(name: "defaults", pattern: "{Area=Layout}/{Controller=Home}/{Action=Index}/{id?}");
});

#endregion



app.Run();
