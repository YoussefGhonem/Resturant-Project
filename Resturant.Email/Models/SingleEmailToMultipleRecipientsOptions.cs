using Ardalis.GuardClauses;
using Resturant.Email.Extensions;
using Resturant.Email.Interfaces;

namespace Resturant.Email.Models;

public class SingleEmailToMultipleRecipientsOptions : ISingleEmailToMultipleRecipientsOptions
{
    public List<EmailAddressModel> To { get; private set; }
    public string Subject { get; private set; }
    public string Body { get; private set; }
    public bool IsBodyHtml { get; private set; }

    public string? PlainTextContent
    {
        get { return IsBodyHtml ? null : Body; }
    }

    public string? HtmlContent
    {
        get { return IsBodyHtml ? Body : null; }
    }

    public SingleEmailToMultipleRecipientsOptions(List<EmailAddressModel> to, string subject, string body,
        bool isBodyHtml = false)
    {
        To = Guard.Against.Default(to, nameof(to));
        Subject = Guard.Against.NullOrWhiteSpace(subject, nameof(subject));
        Body = Guard.Against.NullOrWhiteSpace(body, nameof(body));
        ;
        IsBodyHtml = isBodyHtml;
    }

    public SingleEmailToMultipleRecipientsOptions(List<EmailAddressModel> to, string subject, string htmlBody,
        List<TemplatePlaceholder> placeholders)
    {
        var body = htmlBody.ReplacePlaceholders(placeholders);
        To = to;
        Subject = Guard.Against.NullOrWhiteSpace(subject, nameof(subject));
        Body = Guard.Against.NullOrWhiteSpace(body, nameof(body));
        IsBodyHtml = true;
    }
}