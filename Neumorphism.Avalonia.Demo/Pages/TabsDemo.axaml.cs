using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.Models;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class TabsDemo : UserControl
    {
        public TabsDemo()
        {
            InitializeComponent();

            DataContext = new TabsDemoViewModel();
        }

        //private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var vm = ((TabControl)sender).DataContext as TabsDemoViewModel;
        //    if (e.AddedItems.Count > 0 && vm != null)
        //    {
        //        foreach (var item in vm.TabItems)
        //        {
        //            if (item.Header == ((CustomTabItem)e.AddedItems[0]).Header)
        //            {
        //                item.Selected = true;
        //            }
        //            else
        //            {
        //                item.Selected = false;
        //            }
        //        }
        //    }
        //}
    }
}