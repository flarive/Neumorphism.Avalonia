using System.Diagnostics;

namespace Neumorphism.Avalonia.Demo
{
    public static class GlobalCommand
    {
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