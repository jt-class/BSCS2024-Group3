using Firebase.Auth;
using Firebase.Auth.Providers;
using Go_Trade.Pages;
using Microsoft.Extensions.Logging;

namespace Go_Trade
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


            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                
                ApiKey = "AIzaSyD9zV46bVXEdiUxpzJUzK7tlZvZTTuTmMs",
                AuthDomain = "go-t-e82a4.firebaseapp.com",
                Providers = new FirebaseAuthProvider[] {
                  new EmailProvider()
                }
            }));


            builder.Services.AddSingleton<SignInView>();
            builder.Services.AddSingleton<SignInModel>();
            builder.Services.AddSingleton<SignUpView>();
            builder.Services.AddSingleton<SignUpModel>();


            return builder.Build();
        }
    }
}