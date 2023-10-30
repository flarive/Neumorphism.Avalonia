using Avalonia.Controls;
using Avalonia.Themes.Neumorphism.Enums;
using Neumorphism.Avalonia.Demo.Interfaces;

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


        public override void SayHelloCommand(string msg) => base.SayHello(msg);
        public override void HelpAboutMethod() => base.RunHelpAbout(_window);
        public override void AppExitCommand() => base.AppExit();


        public override void SwitchThemeCommand(bool dark)
        {
            base.SetTheme(dark ? ApplicationTheme.Dark : ApplicationTheme.Light);
        }
    }
}