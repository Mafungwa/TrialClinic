using Microsoft.Extensions.Logging;
using TrialClinic.Pages;
using TrialClinic.Services;

namespace TrialClinic
{
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<UserPage>();

            builder.Services.AddTransient<ParticipantPage>();

            builder.Services.AddTransient<SignInPage>();

            builder.Services.AddSingleton<TrialLocalDatabase>();

            return builder.Build();
        }
    }
}
