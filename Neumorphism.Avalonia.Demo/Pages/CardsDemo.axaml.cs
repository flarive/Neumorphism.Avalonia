using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class CardsDemo : UserControl
    {
        public CardsDemo()
        {
            InitializeComponent();

            DataContext = new CardsDemoViewModel();
        }
    }
}