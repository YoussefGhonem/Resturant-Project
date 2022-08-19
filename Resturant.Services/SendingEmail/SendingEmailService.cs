using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Resturant.Core.CurrentUser;
using Resturant.Data;
using Resturant.Email.Extensions;
using Resturant.Email.Interfaces;
using Resturant.Email.Models;
using Resturant.Services.Identity.Configuration;

namespace Resturant.Services.SendingEmail;

public class SendingEmailService : ISendingEmailService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;
    private readonly IHostingEnvironment _hostingEnvironment;

    public SendingEmailService(
        IEmailService emailService,
        IHostingEnvironment hostingEnvironment,
        AppDbContext context,
        IConfiguration configuration)
    {
        _emailService = emailService;
        _hostingEnvironment = hostingEnvironment;
        _context = context;
        _configuration = configuration;
    }

    public async Task BeforeResetPassword(Guid userId, string encodedToken)
    {

        var user = await _context.Users.Include(u => u.Claims).Select(u => new
        {
            u.Id,
            FirstName = u.Claims.First(c => c.ClaimType == ClaimKeys.FirstName).ClaimValue,
            LastName = u.Claims.First(c => c.ClaimType == ClaimKeys.LastName).ClaimValue,
            u.Email,
        }).FirstOrDefaultAsync(x => x.Id == userId);
        var config = _configuration.GetJwtConfig();
        var webUrl = config.WebUrl;
        var redirectPage = $"{webUrl}/auth/reset-password?email={user?.Email}&token={encodedToken}";

        const string subject = "Reset Password";
        const string templateName = "forgot-password.html";
        var htmlBody = _hostingEnvironment.ExtractStringFromHtml(templateName);

        List<TemplatePlaceholder> placeholders = new()
        {
            new TemplatePlaceholder { Placeholder = "{redirectPage}", Value = redirectPage },
            new TemplatePlaceholder { Placeholder = "{user-name}", Value = user!.Email },
        };
        var options = new SingleEmailOptions(new EmailAddressModel(user.Email, user.Id.ToString()), subject, htmlBody,
            placeholders);

        await _emailService.SendEmail(options);
    }

    public async Task BeforeResendResetPassword(Guid userId, string encodedToken)
    {

        var user = await _context.Users.Include(u => u.Claims).Select(u => new
        {
            u.Id,
            FirstName = u.Claims.First(c => c.ClaimType == ClaimKeys.FirstName).ClaimValue,
            LastName = u.Claims.First(c => c.ClaimType == ClaimKeys.LastName).ClaimValue,
            u.Email,
        }).FirstOrDefaultAsync(x => x.Id == userId);
        var config = _configuration.GetJwtConfig();
        var webUrl = config.WebUrl;
        var redirectPage = $"{webUrl}/auth/reset-password?email={user?.Email}&token={encodedToken}";

        const string subject = "Reset Password";
        const string templateName = "forgot-password.html";
        var htmlBody = _hostingEnvironment.ExtractStringFromHtml(templateName);

        List<TemplatePlaceholder> placeholders = new()
        {
            new TemplatePlaceholder { Placeholder = "{redirectPage}", Value = redirectPage },
            new TemplatePlaceholder { Placeholder = "{user-name}", Value = user!.Email },
        };

        var options = new SingleEmailOptions(new EmailAddressModel(user.Email, user.Id.ToString()), subject, htmlBody,
            placeholders);

        await _emailService.SendEmail(options);
    }

    public async Task AfterLockUser(Guid userId)
    {
        var user = await _context.Users
            .Select(x => new
            {
                x.Id,
                x.Email
            }).FirstOrDefaultAsync(x => x.Id == userId);

        var webUrl = _configuration["WebClients:PublicWebUrl"];
        const string subject = "Your account has been locked";
        const string templateName = "lock-user.html";

        var htmlPage = _hostingEnvironment.ExtractStringFromHtml(templateName);

        List<TemplatePlaceholder> placeholders = new()
        {
            new TemplatePlaceholder { Placeholder = "{terms-page}", Value = $"{webUrl}/auth/terms" },
            new TemplatePlaceholder { Placeholder = $"email", Value = $"{user!.Email}" }
        };

        var options = new SingleEmailOptions(new EmailAddressModel(user!.Email, $"{user!.Email}"), subject,
            htmlPage, placeholders);

        await _emailService.SendEmail(options);
    }

    public async Task AfterUnlockUser(Guid userId)
    {
        var user = await _context.Users
            .Select(x => new
            {
                x.Id,
                x.Email
            }).FirstOrDefaultAsync(x => x.Id == userId);

        var webUrl = _configuration.GetJwtConfig().WebUrl;
        const string subject = "Your acount has been unlocked";
        const string templateName = "unlock-user.html";

        var htmlPage = _hostingEnvironment.ExtractStringFromHtml(templateName);

        List<TemplatePlaceholder> placeholders = new()
        {
            new TemplatePlaceholder { Placeholder = "{terms-page}", Value = $"{webUrl}/auth/terms" },
            new TemplatePlaceholder { Placeholder = "email", Value = $"{user!.Email}" }
        };

        var options = new SingleEmailOptions(new EmailAddressModel(user!.Email, $"{user!.Email}"), subject,
            htmlPage, placeholders);

        await _emailService.SendEmail(options);
    }

}