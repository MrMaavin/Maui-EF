using DbLibrary.Data;
using DbLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MauiEF;

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
        // Set database path safely for all platforms (including Android)
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "dbLibrary123.db");
        string password = "SavePassword"; // TODO: store in secure place
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite($"Data Source={dbPath};Password={password}"));
        builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddSingleton<GroupRepository>();
        
        builder.Services.AddTransient<MainPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}