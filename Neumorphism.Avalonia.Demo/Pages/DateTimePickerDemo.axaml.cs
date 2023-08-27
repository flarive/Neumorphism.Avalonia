using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class DateTimePickerDemo : UserControl
    {
        public DateTimePickerDemo()
        {
            InitializeComponent();

            DataContext = new DateTimePickersDemoViewModel();
        }
    }
}
