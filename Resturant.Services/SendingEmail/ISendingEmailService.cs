namespace Resturant.Services.SendingEmail;

public interface ISendingEmailService
{
    Task BeforeResetPassword(Guid userId, string encodedToken);
    Task BeforeResendResetPassword(Guid userId, string encodedToken);
    Task AfterLockUser(Guid userId);
    Task AfterUnlockUser(Guid userId);
}