using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class DrawingsDemo : UserControl
    {
        public DrawingsDemo()
        {
            InitializeComponent();

            DataContext = new DrawingsDemoViewModel();
        }
    }
}
