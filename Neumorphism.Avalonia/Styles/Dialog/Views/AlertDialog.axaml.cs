using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Neumorphism.Avalonia.Styles.Dialog.Interfaces;
using Neumorphism.Avalonia.Styles.Dialog.ViewModels;

namespace Neumorphism.Avalonia.Styles.Dialog.Views
{
    public class AlertDialog : Window, IDialogWindowResult<DialogResult>, IHasNegativeResult
    {
        public AlertDialog()
        {
            InitializeComponent(); 
        }
        
        public DialogResult GetResult() => (DataContext as AlertDialogViewModel)?.DialogResult;

        public void SetNegativeResult(DialogResult result)
        {
            if (DataContext is AlertDialogViewModel viewModel)
                viewModel.DialogResult = result;
        }

        private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
    }
}
