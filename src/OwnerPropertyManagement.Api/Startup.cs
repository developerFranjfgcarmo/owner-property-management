using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OwnerPropertyManagement.Api.Extensions;

namespace OwnerPropertyManagement.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private string PolicyOrigingAllowed => "AngularApp";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyOrigingAllowed,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            //builder.WithOrigins(url)
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            //Dependency Injection
            services.AddDataBase(Configuration).AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            // global cors policy
            app.UseCors(PolicyOrigingAllowed);

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
