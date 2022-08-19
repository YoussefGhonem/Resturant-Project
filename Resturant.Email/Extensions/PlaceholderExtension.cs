using Resturant.Email.Models;

namespace Resturant.Email.Extensions;

public static class PlaceholderExtension
{
    public static string ReplacePlaceholders(this string htmlBody, List<TemplatePlaceholder> placeholders)
    {
        foreach (var item in placeholders)
        {
            var oldValue = item.Placeholder!.Trim();
            htmlBody = htmlBody.Replace(oldValue, item.Value);
        }

        return htmlBody;
    }
}