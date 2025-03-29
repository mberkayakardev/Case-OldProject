using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories.EntityFramework.Abstract;
using Repositories.EntityFramework.Concrete.Contexts;
using Repositories.EntityFramework.Concrete.UnitOfWorks;
using Services.Abstract;
using Services.Services;
using System.Reflection;

namespace Services.DependencyResolves.Microsoft
{
    public static class MicrosoftIOCContainer
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
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
            services.AddScoped<IAppUserServices, AppUserManager>();
        }

        private static void AddAutoMapper(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        private static void AddFluentValidation(IServiceCollection services, IConfiguration configuration)
        {
            var validatorTypes = Assembly.GetExecutingAssembly()
                                            .GetTypes()
                                            .Where(t => !t.IsAbstract && !t.IsInterface)
                                            .Where(t => t.BaseType != null && t.BaseType.IsGenericType)
                                            .Where(t => t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>))
                                            .ToList();

            foreach (var validatorType in validatorTypes)
            {
                var validatedType = validatorType.BaseType!.GetGenericArguments()[0];
                var interfaceType = typeof(IValidator<>).MakeGenericType(validatedType);

                services.AddScoped(interfaceType, validatorType);
            }

        }

        private static void AddConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            /// Costume AppSettings dosyaları belirli bir formatta isimlendirilmeyip enviromet bazında okumak istersek bunlarıda projeye register edebilmemizi sağlar 
            //var newConfiguration = new ConfigurationBuilder()
            //        .AddConfiguration(configuration) 
            //        .AddJsonFile("customsettings.json", optional: true, reloadOnChange: true) 
            //        .Build(); 


        }

        private static void AddUnitOfWork(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}

