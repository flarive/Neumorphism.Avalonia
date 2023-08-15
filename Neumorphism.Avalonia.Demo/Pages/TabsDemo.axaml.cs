using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class TabsDemo : UserControl
    {
        public TabsDemo()
        {
            InitializeComponent();

            DataContext = new TabsDemoViewModel();
        }
    }
}
