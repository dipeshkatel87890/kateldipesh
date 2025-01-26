using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MauiApp1.Services; // Ensure this namespace matches where your DatabaseService is located
using MauiApp1.Models;   // Ensure this namespace matches where your User model is located

namespace MauiApp1
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
                });

            // Register MauiBlazorWebView services
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            // Enable Blazor WebView developer tools in debug mode
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // Register DatabaseService as a singleton
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "expenseTracker.db");
            builder.Services.AddSingleton<DatabaseService>(s => new DatabaseService(dbPath));
            


            return builder.Build();
        }
    }
}