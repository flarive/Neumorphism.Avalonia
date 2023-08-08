using Avalonia.Controls;
using Avalonia.Themes.Neumorphism.Enums;
using Neumorphism.Avalonia.Demo.Interfaces;
using System;

namespace Neumorphism.Avalonia.Demo.Windows.ViewModels
{
    internal sealed class MainViewModel<TWindow> : ApplicationModelBase
        where TWindow : Window, IMainWindow
    {
        private readonly TWindow _window;

        public MainViewModel(TWindow window)
            : base(window.ThemeSwitch)
        {
            _window = window;
        }

        public override void HelpAboutMethod() => base.RunHelpAbout(_window);

        public override void FileExitCommand()
        {
            Environment.Exit(0);
        }

        public override void SwitchThemeCommand(bool dark)
        {
            if (dark)
            {
                base.SetTheme(ApplicationTheme.Dark);
            }
            else
            {
                base.SetTheme(ApplicationTheme.Light);
            }
        }


    }
}