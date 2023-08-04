using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class ListsDemo : UserControl
    {
        public ListsDemo()
        {
            InitializeComponent();

            DataContext = new ListsDemoViewModel();
        }
    }
}
