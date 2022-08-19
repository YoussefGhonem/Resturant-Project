using Microsoft.Extensions.Configuration;
using Resturant.Email.SendGrid.Config;
using Resturant.Email.SendGrid.Exceptions;
using Resturant.Email.SendGrid.Extensions;
using SendGrid;
using SendGrid.Helpers.Mail;
using Resturant.Email.Interfaces;
using Resturant.Email.Models;

namespace Resturant.Email.SendGrid.Services;

public class EmailService : IEmailService
{
    private readonly SendGridConfig _sendGridConfig;

    public EmailService(IConfiguration configuration)
    {
        _sendGridConfig = configuration.GetSendGridConfig();
    }

    public async Task SendEmail(SingleEmailOptions options)
    {
        var client = new SendGridClient(_sendGridConfig.ApiKey);
        var from = new EmailAddress(_sendGridConfig.From?.Email, _sendGridConfig.From?.Name);
        var to = new EmailAddress(options.To.Email, options.To.Name);

        var msg = MailHelper.CreateSingleEmail(from, to, options.Subject, options.PlainTextContent,
            options.HtmlContent);

        var response = await client.SendEmailAsync(msg);
        await SendGridException.ThrowExceptionOnError(response);
    }

    public async Task SendEmail(SingleEmailToMultipleRecipientsOptions options)
    {
        var client = new SendGridClient(_sendGridConfig.ApiKey);
        var from = new EmailAddress(_sendGridConfig.From?.Email, _sendGridConfig.From?.Name);
        var tos = options.To.Select(x => new EmailAddress(x.Email, x.Name)).ToList();

        var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, options.Subject,
            options.PlainTextContent, options.HtmlContent);

        // Mail Helper.
        var response = await client.SendEmailAsync(msg);

        await SendGridException.ThrowExceptionOnError(response);
    }
}