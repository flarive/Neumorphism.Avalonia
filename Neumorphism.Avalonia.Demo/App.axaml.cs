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
            this.Name = "Neumorphism.Avalonia.Demo";
        }

        public override void OnFrameworkInitializationCompleted()
        {
            //this.InitializeThemes();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
                this.DataContext = desktop.MainWindow.DataContext;
            }

            base.OnFrameworkInitializationCompleted();
        }

        //private void InitializeThemes()
        //{
        //    //this._currentTheme = ApplicationTheme.Light;
        //    //this.SetValue(ThemeVariantScope.ActualThemeVariantProperty, this._currentTheme == ApplicationTheme.Dark ? ThemeVariant.Dark : ThemeVariant.Light);
        //}

        ApplicationTheme IThemeSwitch.Current => this._currentTheme;



        void IThemeSwitch.ChangeTheme(ApplicationTheme theme)
        {
            if (theme == this._currentTheme)
                return;

            //bool themeChanged = theme switch
            //{
            //    ApplicationTheme.Light => this._currentTheme is ApplicationTheme.Light or ApplicationTheme.Dark,
            //    ApplicationTheme.Dark => this._currentTheme is ApplicationTheme.Light or ApplicationTheme.Dark,
            //    _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, null)
            //};

            this._currentTheme = theme;

            var zz = Application.Current.LocateMaterialTheme<NeumorphismTheme>();
            if (zz != null)
            {
                zz.BaseTheme = theme;
            }




            //switch (theme)
            //{
            //    case ApplicationTheme.Light:
            //        //this.SetValue(ThemeVariantScope.ActualThemeVariantProperty, ThemeVariant.Light);
            //        break;
            //    case ApplicationTheme.Dark:
            //        //this.SetValue(ThemeVariantScope.ActualThemeVariantProperty, ThemeVariant.Dark);
            //        break;
            //}



            //if (themeChanged && this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            //{
            //    MainWindow oldWindow = desktop.MainWindow as MainWindow;
            //    MainWindow newWindow = new MainWindow(oldWindow);

            //    desktop.MainWindow = newWindow;
            //    this.DataContext = newWindow.DataContext;


            //    oldWindow.Hide();
            //    newWindow.Show();
            //    oldWindow.Close();
            //}
        }
    }
}