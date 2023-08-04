using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels.Panels;

namespace Neumorphism.Avalonia.Demo.Pages.Panels
{
    public partial class PanelSleepQualityDemo : UserControl
    {
        public PanelSleepQualityDemo()
        {
            InitializeComponent();

            DataContext = new PanelSleepQualityDemoViewModel();
        }
    }
}
