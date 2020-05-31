using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OwnerPropertyManagement.Api.Auth.Service;
using OwnerPropertyManagement.Data.Context;
using OwnerPropertyManagement.Domain.Domain;
using OwnerPropertyManagement.Domain.IDomain;

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
            services.AddScoped<IOwnerDomain, OwnerDomain>();
            services.AddScoped<IPropertyDomain, PropertyDomain>();
            services.AddScoped<IMasterTablesDomain, MasterTablesDomain>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
