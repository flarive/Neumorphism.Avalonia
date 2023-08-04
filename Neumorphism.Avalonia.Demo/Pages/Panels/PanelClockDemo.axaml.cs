using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels.Panels;

namespace Neumorphism.Avalonia.Demo.Pages.Panels
{
    public partial class PanelClockDemo : UserControl
    {
        public PanelClockDemo()
        {
            InitializeComponent();

            DataContext = new PanelClockDemoViewModel();
        }
    }
}