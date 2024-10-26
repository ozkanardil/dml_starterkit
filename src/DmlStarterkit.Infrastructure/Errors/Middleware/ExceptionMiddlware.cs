using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Http;
using DmlStarterkit.Infrastructure.Errors.Models;

namespace DmlStarterkit.Infrastructure.Errors.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
             
                var errorResult = new ErrorResult
                {
                    Success = false,
                    Message = exception.Message,
                };

                var response = context.Response;
                if (!response.HasStarted)
                {
                    response.ContentType = "application/json";
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await response.WriteAsync(JsonConvert.SerializeObject(errorResult));
                }
              
            }
        }
    }
}
