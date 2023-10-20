using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.Dialogs.Interfaces;
using Neumorphism.Avalonia.Demo.Dialogs.ViewModels;

namespace Neumorphism.Avalonia.Demo.Dialogs.Views
{
    public partial class CustomDialog : Window, IDialogWindowResult<DialogResult>, IHasNegativeResult
    {
        public CustomDialog() {
            InitializeComponent();
        }

        public DialogResult GetResult() => (DataContext as CustomDialogViewModel)?.DialogResult;

        public void SetNegativeResult(DialogResult result) {
            if (DataContext is CustomDialogViewModel viewModel)
                viewModel.DialogResult = result;
        }
    }
}
