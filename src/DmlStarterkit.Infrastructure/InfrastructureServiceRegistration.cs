using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DmlStarterkit.Infrastructure.Errors.Middleware;
using DmlStarterkit.Infrastructure.CustomExceptionFilter;
using DmlStarterkit.Infrastructure.LogEntries;
using DmlStarterkit.Infrastructure.Security.JwtToken;

namespace DmlStarterkit.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<ExceptionMiddleware>();

            services.AddTransient<LogFilter>();
            services.AddTransient<ExceptionFilter>();

            return services;

        }
    }
}
