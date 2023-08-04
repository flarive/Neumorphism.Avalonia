using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class ButtonsDemo : UserControl
    {
        public ButtonsDemo()
        {
            InitializeComponent();

            DataContext = new ButtonFieldsViewModel();
        }
    }
}
