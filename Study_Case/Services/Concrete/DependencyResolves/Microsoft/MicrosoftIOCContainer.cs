using Core.Utilities.Cookie;
using Core.Utilities.Managers;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Repositories.EntityFramework.Abstract;
using QuizApp.Repositories.EntityFramework.Concrete.Contexts;
using QuizApp.Repositories.EntityFramework.Concrete.UnitOfWorks;
using Services.Abstract;
using Services.Concrete.Services;
using System.Reflection;

namespace ApiService.Services.Concrete.DependencyResolves.Microsoft
{
    public static class MicrosoftIOCContainer
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);

            AddConfiguration(services, configuration);

            AddServices(services, configuration);

            AddUnitOfWork(services, configuration);

            AddAutoMapper(services, configuration);

            AddFluentValidation(services, configuration);
        
        }

     
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });
        }

        private static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IBasketService, BasketManager>();

        }

        private static void AddAutoMapper(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        private static void AddFluentValidation(IServiceCollection services, IConfiguration configuration)
        {
            var assemblyList = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType != null).Where(x => x.BaseType.Name.Contains("AbstractValidator")).ToList();
            foreach (var item in assemblyList)
            {
                var DtoType = item.BaseType.GetGenericArguments()[0];
                services.AddSingleton(typeof(IValidator<>).MakeGenericType(DtoType), item);
            }


        }

        private static void AddConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<MemoryCacheManager>();
            services.AddScoped<CookieManager>();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
        }

        private static void AddUnitOfWork(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


    }
}
