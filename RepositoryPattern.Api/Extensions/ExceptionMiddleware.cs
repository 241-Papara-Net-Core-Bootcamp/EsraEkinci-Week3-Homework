using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace RepositoryPattern.Api.Extensions
    
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType="application/json";

                    var contextFuture = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFuture is not null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode=context.Response.StatusCode,
                            Message="Internal Server Error!"
                        }.ToString());
                    }
                });
            });
        }
    }
}
