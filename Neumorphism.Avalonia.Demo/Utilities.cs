using System;
using System.IO;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Neumorphism.Avalonia.Demo
{
    internal static class Utilities
    {
        public static readonly bool IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static readonly bool IsOSX = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public static Bitmap GetImageFromResources(String fileName)
        {
            return new Bitmap(AssetLoader.Open(new Uri($"avares://Neumorphism.Avalonia.Demo/Assets/{fileName}")));
        }

        public static PixelPoint GetWindowPosition(Window window)
        {
            if (!IsOSX || !window.FrameSize.HasValue)
                return window.Position;
            else
            {
                Int32 yOffset = (Int32)(window.FrameSize.Value.Height - window.ClientSize.Height);
                return new(window.Position.X, window.Position.Y + yOffset);
            }
        }

        public static Bitmap GetImageFromFile(String path)
        {
            try
            {
                return new Bitmap(GetImageFullPath(path));
            }
            catch (Exception)
            {
                return GetImageFromResources("broken-link.png");
            }
        }

        private static String GetImageFullPath(String fileName)
            => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
    }
}
