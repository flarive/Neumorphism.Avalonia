using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class DateTimePickersDemo : UserControl
    {
        public DateTimePickersDemo()
        {
            InitializeComponent();

            DataContext = new DateTimePickersDemoViewModel();
        }
    }
}