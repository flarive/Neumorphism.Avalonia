using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Neumorphism.Avalonia.Demo.ViewModels.Panels;

namespace Neumorphism.Avalonia.Demo.Pages.Panels
{
    public partial class PanelMessagesDemo : UserControl
    {
        public PanelMessagesDemo()
        {
            InitializeComponent();

            this.DataContext = new PanelMessagesDemoViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
