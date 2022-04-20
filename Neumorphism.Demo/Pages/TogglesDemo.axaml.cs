using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public class TogglesDemo : UserControl
    {
        public TogglesDemo()
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
