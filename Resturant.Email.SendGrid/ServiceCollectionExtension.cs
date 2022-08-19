using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resturant.Email.SendGrid.Extensions;
using Resturant.Email.SendGrid.Services;
using Resturant.Email.Interfaces;

namespace Resturant.Email.SendGrid;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSendGrid(this IServiceCollection services, IConfiguration configuration)
    {
        configuration.GetSendGridConfig();

        services.AddSingleton<IEmailService, EmailService>();
        return services;
    }
}