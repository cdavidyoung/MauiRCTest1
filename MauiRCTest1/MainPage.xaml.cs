using MauiRCTest1.Services;

namespace MauiRCTest1;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnSendEmailClicked(object sender, EventArgs e)
    {
        var emailService = ServicesProvider.GetService<IEmailService>();
        var recipients = new List<string>();
        recipients.Add(txtEmail.Text);
        var success = emailService.SendEmail("Sample Question", "", recipients);


    }
}

