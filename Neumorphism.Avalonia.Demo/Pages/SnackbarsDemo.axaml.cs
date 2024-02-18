using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Primitives;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class SnackbarsDemo : UserControl
    {
        public SnackbarsDemo()
        {
            InitializeComponent();
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime app)
            {
                // Lazy Initialize view model
                DataContext = new SnackbarsDemoViewModel(app.MainWindow);
            }

            base.OnApplyTemplate(e);
        }
    }
}