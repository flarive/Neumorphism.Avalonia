using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class FieldsDemo : UserControl
    {
        public FieldsDemo()
        {
            InitializeComponent();

            DataContext = new TextBoxesDemoViewModel();
        }
    }
}
