using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DmlStarterkit.Persistance.Context;
using DmlStarterkit.Domain.Entities;

namespace DmlStarterkit.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            string myConnStr = ApplicationSettings.DbConnString;
            services.AddDbContext<DatabaseContext>(options => options.UseMySql(myConnStr,
                                                                            ServerVersion.AutoDetect(myConnStr)));

            return services;
        }
    }
}
