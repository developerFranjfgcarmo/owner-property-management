using System.Text;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OwnerPropertyManagement.Api.Extensions;
using OwnerPropertyManagement.Api.Filters;
using OwnerPropertyManagement.Api.Middleware;

namespace OwnerPropertyManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private string PolicyOrigingAllowed => "AngularApp";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers(options =>
                    options.Filters.Add<ValidationFilter>())
                .AddFluentValidation(mvcConfiguration =>
                    mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddNewtonsoftJson();
            //services
            //    .AddControllers()
            //    .AddNewtonsoftJson();

            services.AddCorsPolicies(PolicyOrigingAllowed);

            services.AddAuthenticationWithJwtBearer(Configuration);

            //Dependency Injection
            services.AddDataBase(Configuration).AddServices();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseCustomExceptionMiddleware();
            app.UseRouting();
            // global cors policy
            app.UseCors(PolicyOrigingAllowed);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}