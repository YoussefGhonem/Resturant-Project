using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resturant.Data;
using Resturant.Data.DataContext;
using Resturant.Data.DbModels.SecuritySchema;

namespace Resturant.Getway.Extensions;

public static class DatabaseExtension
{

    public static async Task MigrateDatabase(this IServiceScope scope)
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await dbContext.Database.MigrateAsync();
    }

    public static async Task SeedDatabase(this IServiceScope scope)
    {
        var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await DataSeedingIntilization.SeedDataAsync(appDbContext, scope.ServiceProvider);
    }
}
