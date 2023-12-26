using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;
using System.Collections.Generic;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class ComboBoxesDemo : UserControl
    {
        public ComboBoxesDemo()
        {
            InitializeComponent();

            DataContext = new ComboBoxesDemoViewModel();
        }

        private void ClassicComboBoxesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && e.AddedItems != null && e.AddedItems.Count > 0)
            {
                if (e.AddedItems[0] is KeyValuePair<int, string> pair)
                {
                    var item = (KeyValuePair<int, string>)e.AddedItems[0];
                    if (item.Key < 0)
                    {
                        // deselect item
                        ((ComboBox)sender).SelectedItem = null;
                    }
                }
            }
        }
    }
}