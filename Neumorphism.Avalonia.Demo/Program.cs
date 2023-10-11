using System;
using System.Threading.Tasks;
using Avalonia;
using Neumorphism.Avalonia.Demo.Windows;
using ShowMeTheXaml;

namespace Neumorphism.Avalonia.Demo
{
    public static class Program
    {
        public static MainWindow MainWindow { get; private set; }

        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args)
        {
            //dotnet publish -c release --framework net7.0 -r win-x64
            //dotnet publish -c release --framework net8.0 -r win-x64

            // how to debug a native aot crash :
            // https://github.com/dotnet/runtime/blob/main/src/coreclr/nativeaot/docs/debugging.md



            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            try
            {
                // prepare and run your App here
                BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
            }
            catch (Exception ex)
            {
                // here we can work with the exception, for example add it to our log file
                string msg = ex.ToString();
            }
            finally
            {
                // This block is optional. 
                // Use the finally-block if you need to clean things up or similar
            }
        }

        /// <summary>
        /// Exceptions occurring inside tasks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs ex)
        {
            string msg = ex.ToString();
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .UseXamlDisplay()
            .LogToTrace();
    }
}
