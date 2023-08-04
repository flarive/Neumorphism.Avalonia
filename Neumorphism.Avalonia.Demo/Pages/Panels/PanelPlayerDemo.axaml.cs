using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels.Panels;

namespace Neumorphism.Avalonia.Demo.Pages.Panels
{
    public partial class PanelPlayerDemo : UserControl
    {
        public PanelPlayerDemo()
        {
            InitializeComponent();
            
            DataContext = new PanelPlayerDemoViewModel();
        }
    }
}