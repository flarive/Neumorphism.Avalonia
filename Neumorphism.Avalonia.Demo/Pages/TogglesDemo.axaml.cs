using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class TogglesDemo : UserControl
    {
        public TogglesDemo()
        {
            InitializeComponent();

            DataContext = new ButtonsDemoViewModel();
        }
    }
}
