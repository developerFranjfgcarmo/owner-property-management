using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OwnerPropertyManagement.Data.Context;
using OwnerPropertyManagement.Domain.IServices;
using OwnerPropertyManagement.Domain.Services;

namespace OwnerPropertyManagement.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OwnerPropertyDbContext>(c =>
                c.UseSqlServer(configuration.GetConnectionString("OwnerPropertyDatabase")));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOwnerPropertyDbContext, OwnerPropertyDbContext>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IPropertyService, PropertyService>();
            return services;
        }
    }
}
