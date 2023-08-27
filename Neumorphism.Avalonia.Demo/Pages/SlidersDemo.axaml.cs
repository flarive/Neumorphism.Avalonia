using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class SlidersDemo : UserControl
    {
        public SlidersDemo()
        {
            InitializeComponent();

            DataContext = new SlidersDemoViewModel();
        }
    }
}
