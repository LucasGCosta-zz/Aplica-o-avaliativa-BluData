using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BluData.Avaliacao.App.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var errorDetails = new ErrorDetails();

                        switch (contextFeature.Error)
                        {
                            case InvalidOperationException invalidOperationException:
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                                errorDetails.Message = contextFeature.Error.Message;
                                break;

                            default:
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                errorDetails.Message = "Internal Server Error";
                                break;
                        }

                        errorDetails.StatusCode = context.Response.StatusCode;

                        await context.Response.WriteAsync(errorDetails.ToString());
                    }
                });
            });
        }
    }
}
