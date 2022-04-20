using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public class FieldsDemo : UserControl
    {
        public FieldsDemo()
        {
            this.InitializeComponent();

            DataContext = new TextFieldsViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
