using System.Reflection;

namespace MauiRCTest1.Services;

public class EmailService : IEmailService
{
    public EmailService()
    {
    }

    public async Task<bool> SendEmail(string subject, string body, List<string> recipients, bool includeAttachments = false, List<string> files = null, bool isHtml = false)
    {
        bool success = false;

        try
        {
            var message = new EmailMessage
            {
                Subject = subject,
                Body = body,
                BodyFormat = isHtml ? EmailBodyFormat.Html : EmailBodyFormat.PlainText,
                To = recipients,
            };

            if (includeAttachments && files != null)
            {
                foreach (string file in files)
                {
                    message.Attachments.Add(new EmailAttachment(file));
                }
            }

            await Email.ComposeAsync(message);

            success = true;
        }
        catch (FeatureNotSupportedException fbsEx)
        {

            MethodBase? m = MethodBase.GetCurrentMethod();

            await Shell.Current.DisplayAlert("Error", "Email is not supported on this device..", "Ok");
            // Email is not supported on this device

            success = false;
        }
        catch (Exception ex)
        {
            // Some other exception occurred
            MethodBase? m = MethodBase.GetCurrentMethod();

            await Shell.Current.DisplayAlert("Error", $"An error occured during sending email..{ex}", "Ok");

            success = false;
        }

        return success;
    }
}
