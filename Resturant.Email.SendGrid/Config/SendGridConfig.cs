namespace Resturant.Email.SendGrid.Config;

public sealed class SendGridConfig
{
    public string? ApiKey { get; set; }
    public SendGridFromConfig? From { get; set; }
}