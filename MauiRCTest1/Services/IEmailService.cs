namespace MauiRCTest1.Services;
public interface IEmailService
{
    Task<bool> SendEmail(string subject, string body, List<string> recipients, bool includeAttachments = false,
        List<string> files = null, bool isHtml = false);
}
