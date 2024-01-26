using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class ExpanderDemo : UserControl
    {
        public ExpanderDemo()
        {
            InitializeComponent();

            DataContext = new ExpanderDemoViewModel();
        }
    }
}
