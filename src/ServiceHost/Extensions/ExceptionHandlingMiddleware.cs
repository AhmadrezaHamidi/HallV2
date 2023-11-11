using System.Net;
 using Framework.Application;
 using Framework.Autofac;
 using Framework.Domain;
using Microsoft.AspNetCore.Diagnostics;

namespace ServiceHost.Extensions
{
    public static class ExceptionHandlingMiddleware
    {
        public static void ConfigureExceptionHandling(this IApplicationBuilder app, IExceptionLoggerRepository exceptionLoggerRepository, BaseConfig insuranceConfig)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    if (IsTypeOfBusinessException(context))
                    {
                        await HandleResponse(context);
                        return;
                    }
                    if (IsTypeOfAppException(context))
                    {
                        await HandleAppResponse(context);
                        return;
                    }

                    await DoLog(context, exceptionLoggerRepository, insuranceConfig);
                    await ThrowUnHandledError(context);
                });
            });
        }

        private static async Task HandleResponse(HttpContext context)
        {
            await SetResponse(context);
        }
        private static async Task SetResponse(HttpContext context)
        {
            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            var code = exceptionHandlerFeature.Error.GetType().GetProperty("Code").GetValue(exceptionHandlerFeature.Error);
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(new ErrorDetails()
            {
                Message = exceptionHandlerFeature.Error.Message,
                Code = code
            }.ToString());
        }
        
        private static async Task HandleAppResponse(HttpContext context)
        {
            await SetAppResponse(context);
        }
        private static async Task SetAppResponse(HttpContext context)
        {
            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            var code = exceptionHandlerFeature.Error.GetType().GetProperty("Code").GetValue(exceptionHandlerFeature.Error);
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(new ErrorDetails()
            {
                Message = exceptionHandlerFeature.Error.Message,
                Code = code
            }.ToString());
        }

        private static async Task ThrowUnHandledError(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(new ErrorDetails()
            {
                Message = "عملیات با شکست مواجه شد",
                Code = 5
            }.ToString());
        }

        private static async Task DoLog(HttpContext context, IExceptionLoggerRepository exceptionLoggerRepository, BaseConfig insuranceConfig)
        {
            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            var exception = new ExceptionLogModel("StockAsset", exceptionHandlerFeature.Error.Message, exceptionHandlerFeature.Error.StackTrace);
            await exceptionLoggerRepository.Save(exception, insuranceConfig.ConnectionString);
        }

        private static bool IsTypeOfBusinessException(HttpContext context)
        {
            var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerFeature>();
            if (exceptionHandlerPathFeature?.Error is BusinessException)
                return true;
            return false;
        }

        private static bool IsTypeOfAppException(HttpContext context)
        {
            var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerFeature>();
            if (exceptionHandlerPathFeature?.Error is AppException)
                return true;
            return false;
        }
    }
}
