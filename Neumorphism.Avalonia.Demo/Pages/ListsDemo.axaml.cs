using Avalonia.Controls;
using Avalonia.Input;
using Neumorphism.Avalonia.Demo.Models;
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

        private void Grid_PointerPressed(object sender, PointerPressedEventArgs e)
        {
            var item = ((Control)e.Source).DataContext as CustomListItem;
            ((ListsDemoViewModel)DataContext).ListItemClickCommand(item);
        }
    }
}