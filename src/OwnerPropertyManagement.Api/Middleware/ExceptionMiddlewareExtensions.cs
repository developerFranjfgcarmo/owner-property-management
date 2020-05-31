using Microsoft.AspNetCore.Builder;

namespace OwnerPropertyManagement.Api.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}