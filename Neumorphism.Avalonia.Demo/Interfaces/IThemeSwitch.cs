using Avalonia.Themes.Neumorphism.Enums;

namespace Neumorphism.Avalonia.Demo.Interfaces
{
    public interface IThemeSwitch
    {
        ApplicationTheme Current { get; }
        void ChangeTheme(ApplicationTheme theme);
    }
}
