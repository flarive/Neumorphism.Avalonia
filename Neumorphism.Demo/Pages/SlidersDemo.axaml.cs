using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public class SlidersDemo : UserControl
    {
        public SlidersDemo()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
