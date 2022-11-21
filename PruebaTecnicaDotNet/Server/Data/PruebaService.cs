using Microsoft.EntityFrameworkCore;
using PruebaTecnicaDotNet.Server.Models;
using PruebaTecnicaDotNet.Server.Repository;

namespace PruebaTecnicaDotNet.Server.Data
{
    public static class PruebaService
    {
        public static IServiceCollection AddPruebaServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<PruebaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PruebaDbConnection"));
                options.EnableSensitiveDataLogging();
            });
            services.AddScoped(typeof(IRepository<Customers>), typeof(CustomerRepository));
            services.AddScoped(typeof(ICustomerPhoneRepository), typeof(CustomerPhoneRepository));
            return services;
        }
    }
}
