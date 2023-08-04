using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels.Panels;

namespace Neumorphism.Avalonia.Demo.Pages.Panels
{
    public partial class PanelMessagesDemo : UserControl
    {
        public PanelMessagesDemo()
        {
            InitializeComponent();

            DataContext = new PanelMessagesDemoViewModel();
        }
    }
}
