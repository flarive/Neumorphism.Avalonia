using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels.Panels;

namespace Neumorphism.Avalonia.Demo.Pages.Panels
{
    public partial class PanelUserProfilDemo : UserControl
    {
        public PanelUserProfilDemo()
        {
            InitializeComponent();

            DataContext = new PanelUserProfilDemoViewModel();
        }
    }
}