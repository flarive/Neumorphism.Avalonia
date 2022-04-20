using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public class TypographyDemo : UserControl
    {
        public TypographyDemo()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
