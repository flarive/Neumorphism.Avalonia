using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using DialogHostAvalonia;
using Neumorphism.Avalonia.Demo.Models;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{ 
    public partial class DialogsDemo : UserControl
    {
        public DialogsDemo()
        {
            InitializeComponent();
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

        private void OpenDialogWithView(object sender, RoutedEventArgs e)
        {
            // View DialogSampleView is defined in <UserControl.Resources> in DialogsDemo.axaml
            var view = this.Resources["DialogSampleView"]!;
            if (view != null)
            {
                DialogHost.Show(view, "MainDialogHost");
            }
        }

        private void OpenDialogWithModel(object sender, RoutedEventArgs e)
        {
            // View that associated with this model defined in <Window.DataTemplates> in MainWindow.axaml
            var model = new Sample2Model(new Random().Next(0, 100));
            DialogHost.Show(model, "MainDialogHost");
        }
    }
}