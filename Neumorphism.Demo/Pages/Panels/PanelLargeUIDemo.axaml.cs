using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages.Panels
{
    public class PanelLargeUIDemo : UserControl
    {
        public PanelLargeUIDemo()
        {
            this.InitializeComponent();

            DataContext = new ButtonFieldsViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}