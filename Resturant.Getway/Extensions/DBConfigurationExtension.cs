using Microsoft.EntityFrameworkCore;
using Resturant.Data;

namespace Resturant.Getway.Extensions
{
    public static class DBConfigurationExtension
    {
        public static IServiceCollection AddDBConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
            // configuration.GetConnectionString("DefaultConnection"),
            // b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(configuration.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection")));

            return services;
        }
    }
}
