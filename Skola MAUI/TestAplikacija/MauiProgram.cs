using Microsoft.Extensions.Logging;
using TestAplikacija.Services.TodoServices;

namespace TestAplikacija
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

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Skola.db3");

            builder.Services.AddSingleton<ITodoServices, TodoServices>(p => ActivatorUtilities.CreateInstance<TodoServices>(p, dbPath));

            return builder.Build();
        }
    }
}
