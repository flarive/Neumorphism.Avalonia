using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Neumorphism.Demo.ViewModels;

namespace Neumorphism.Demo.Pages
{
    public class ButtonsDemo : UserControl
    {
        public ButtonsDemo()
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