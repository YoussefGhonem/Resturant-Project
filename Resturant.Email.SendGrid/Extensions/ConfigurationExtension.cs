using Microsoft.Extensions.Configuration;
using Resturant.Email.SendGrid.Config;

namespace Resturant.Email.SendGrid.Extensions;

public static class ConfigurationExtension
{
    public static SendGridConfig GetSendGridConfig(this IConfiguration configuration)
    {
        var confg = configuration.GetSection("MailProviders:SendGrid").Get<SendGridConfig>();
        if (confg == null)
            throw new Exception("Missing 'SendGrid' configuration section from the appsettings.");
        return confg;
    }
}