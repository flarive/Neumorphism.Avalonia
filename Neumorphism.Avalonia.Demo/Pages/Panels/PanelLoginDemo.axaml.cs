using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels.Panels;

namespace Neumorphism.Avalonia.Demo.Pages.Panels
{
    public partial class PanelLoginDemo : UserControl
    {
        public PanelLoginDemo()
        {
            InitializeComponent();

            DataContext = new PanelLoginDemoViewModel();
        }
    }
}