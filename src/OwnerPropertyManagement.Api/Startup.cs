using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OwnerPropertyManagement.Api.Extensions;
using OwnerPropertyManagement.Api.Middleware;

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
            services.AddControllers().AddNewtonsoftJson();
            var url = Configuration.GetSection("PolicyAllowOrigin").GetSection("Url").Value;
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
            // configure jwt authentication
            var secret = Configuration.GetSection("AppSettings").GetSection("Secret").Value;
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
