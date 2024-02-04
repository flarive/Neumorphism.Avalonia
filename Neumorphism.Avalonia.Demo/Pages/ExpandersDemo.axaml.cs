using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class ExpandersDemo : UserControl
    {
        public ExpandersDemo()
        {
            InitializeComponent();

            DataContext = new ExpandersDemoViewModel();
        }
    }
}