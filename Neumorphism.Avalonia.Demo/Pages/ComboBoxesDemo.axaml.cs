using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class ComboBoxesDemo : UserControl
    {
        public ComboBoxesDemo()
        {
            InitializeComponent();

            DataContext = new ComboBoxesDemoViewModel();
        }

        private void ClassicComboBoxes1SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var item = e.AddedItems[0] as ComboBoxItem;
                if (item != null && item.Tag is string)
                {
                    if ((string)item.Tag == "-1")
                    {
                        // deselect item
                        ((ComboBox)sender).SelectedIndex = -1;
                    }
                }
            }
        }
    }
}