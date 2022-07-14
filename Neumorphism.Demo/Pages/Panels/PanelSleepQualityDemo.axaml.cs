using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Neumorphism.Avalonia.Demo.ViewModels.Panels;

namespace Neumorphism.Avalonia.Demo.Pages.Panels
{
    public class PanelSleepQualityDemo : UserControl
    {
        public PanelSleepQualityDemo()
        {
            this.InitializeComponent();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}