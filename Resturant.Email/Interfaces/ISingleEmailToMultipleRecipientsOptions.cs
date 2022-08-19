using Resturant.Email.Models;

namespace Resturant.Email.Interfaces;

public interface ISingleEmailToMultipleRecipientsOptions
{
    public List<EmailAddressModel> To { get; }
    public string Subject { get; }
    public string Body { get; }
    public bool IsBodyHtml { get; }
}