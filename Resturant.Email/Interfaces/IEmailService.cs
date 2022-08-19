using Resturant.Email.Models;

namespace Resturant.Email.Interfaces;

public interface IEmailService
{
    Task SendEmail(SingleEmailOptions options);
    Task SendEmail(SingleEmailToMultipleRecipientsOptions options);
}