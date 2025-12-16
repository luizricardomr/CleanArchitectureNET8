using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Mappings;
using CleanArchMVC.Application.Services;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using CleanArchMVC.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchMVC.Infra.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), 
                              b=> b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
                
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<DomainToDTOMappingProfile>();
            });

            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(DomainToDTOMappingProfile).Assembly));

            return services;
        }
    }
}
