using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Themes.Neumorphism;
using Avalonia.Themes.Neumorphism.Enums;
using Neumorphism.Avalonia.Demo.Interfaces;
using Neumorphism.Avalonia.Demo.Windows;

namespace Neumorphism.Avalonia.Demo
{
    public sealed class App : Application, IThemeSwitch
    {
        private ApplicationTheme _currentTheme;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            Name = "Neumorphism.Avalonia.Demo";
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
                DataContext = desktop.MainWindow.DataContext;
            }

            base.OnFrameworkInitializationCompleted();
        }

        ApplicationTheme IThemeSwitch.Current => this._currentTheme;



        void IThemeSwitch.ChangeTheme(ApplicationTheme theme)
        {
            if (theme == this._currentTheme)
                return;

            _currentTheme = theme;

            var neumorphismTheme = Application.Current.LocateMaterialTheme<NeumorphismTheme>();
            if (neumorphismTheme != null)
            {
                neumorphismTheme.BaseTheme = theme;
            }
        }
    }
}