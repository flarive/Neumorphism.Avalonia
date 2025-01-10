using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Primitives;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{ 
    public partial class DialogsDemo : UserControl
    {
        public DialogsDemo()
        {
            InitializeComponent();

            // to avoid binding errors when app start
            DataContext = new DialogsDemoViewModel();
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime app)
            {
                // Lazy Initialize view model
                DataContext = new DialogsDemoViewModel(app.MainWindow);
            }

            base.OnApplyTemplate(e);
        }
    }
}