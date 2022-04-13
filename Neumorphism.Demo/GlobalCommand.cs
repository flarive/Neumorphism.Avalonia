using Neumorphism.Avalonia.Styles.Themes;
using Neumorphism.Avalonia.Styles.Themes.Base;
using System.Diagnostics;
using Avalonia;

namespace Neumorphism.Demo
{
    public static class GlobalCommand
    {
        private static readonly MaterialTheme MaterialThemeStyles = Application.Current!.LocateMaterialTheme<MaterialTheme>();

        public static void UseMaterialUIDarkTheme()
        {
            MaterialThemeStyles.BaseTheme = BaseThemeMode.Dark;
        }
        
        public static void UseMaterialUILightTheme()
        {
            MaterialThemeStyles.BaseTheme = BaseThemeMode.Light;
        }

        public static void OpenProjectRepoLink() => OpenBrowserForVisitSite("https://github.com/flarive/Neumorphism.Avalonia");

        public static void OpenAvaloniaWebsiteLink() => OpenBrowserForVisitSite("https://avaloniaui.net");

        public static void OpenBrowserForVisitSite(string link)
        {
            var param = new ProcessStartInfo
            {
                FileName = link,
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(param);
        }
    }
}