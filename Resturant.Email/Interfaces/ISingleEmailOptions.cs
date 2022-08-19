using Resturant.Email.Models;

namespace Resturant.Email.Interfaces;

public interface ISingleEmailOptions
{
    public EmailAddressModel To { get; }
    public string Subject { get; }
    public string Body { get; }
    public bool IsBodyHtml { get; }
}