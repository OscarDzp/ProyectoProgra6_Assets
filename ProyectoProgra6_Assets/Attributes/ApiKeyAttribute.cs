﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProyectoProgra6_Assets.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.All)]
    public sealed class ApiKeyAttribute : Attribute , IAsyncActionFilter
    {
        private readonly string _apiKey = "P6ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
                                                 ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(_apiKey, out var ApiSalida)) 
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "The http request doesn't contain security information"
                };
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var ApikeyValue = appSettings.GetValue<string>(_apiKey);
            if (ApikeyValue != null && !ApikeyValue.Equals(ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Incorrect ApiKey Data........"
                };
                return;
            }

            await next();
        }



    }
}
