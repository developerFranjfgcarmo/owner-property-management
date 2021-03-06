﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

        public static IServiceCollection AddCorsPolicies(this IServiceCollection services, string policyOrigingAllowed)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(policyOrigingAllowed,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            //builder.WithOrigins(url)
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            return services;
        }

        public static IServiceCollection AddAuthenticationWithJwtBearer(this IServiceCollection services, IConfiguration configuration)
        {
            // configure jwt authentication
            var secret = configuration.GetSection("AppSettings").GetSection("Secret").Value;
            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            return services;
        }
    }
}