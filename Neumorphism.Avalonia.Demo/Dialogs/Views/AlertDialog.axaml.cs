using Avalonia.Controls;
using Avalonia.Themes.Neumorphism.Dialogs;
using Avalonia.Themes.Neumorphism.Dialogs.Interfaces;
using Neumorphism.Avalonia.Demo.Dialogs.ViewModels;

namespace Neumorphism.Avalonia.Demo.Dialogs.Views
{
    public partial class AlertDialog : Window, IDialogWindowResult<DialogResult>, IHasNegativeResult
    {
        public AlertDialog() {
            InitializeComponent();
        }

        public DialogResult GetResult() => (DataContext as AlertDialogViewModel)?.DialogResult;

        public void SetNegativeResult(DialogResult result) {
            if (DataContext is AlertDialogViewModel viewModel)
                viewModel.DialogResult = result;
        }
    }
}
