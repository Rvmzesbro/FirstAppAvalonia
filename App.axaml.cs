using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using FirstAppAvalonia.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAppAvalonia;

public partial class App : Application
{
    public static MainWindow MainWindow;
    public static PostgresContext dbContext = new PostgresContext();
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}