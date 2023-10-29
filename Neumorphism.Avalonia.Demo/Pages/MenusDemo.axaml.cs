using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{ 
    public partial class MenusDemo : UserControl
    {
        public MenusDemo()
        {
            InitializeComponent();

            DataContext = new MenusDemoViewModel();
        }
    }
}