using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Neumorphism.Demo.ViewModels;

namespace Neumorphism.Demo.Pages
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
