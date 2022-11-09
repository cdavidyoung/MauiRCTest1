using MauiRCTest1.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MauiRCTest1;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.TryAddSingleton<IEmailService, EmailService>();

        return builder.Build();
    }
}
