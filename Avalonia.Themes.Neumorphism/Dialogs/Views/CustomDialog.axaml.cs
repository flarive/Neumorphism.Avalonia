using Avalonia.Controls;
using Avalonia.Themes.Neumorphism.Dialogs.Interfaces;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels;

namespace Avalonia.Themes.Neumorphism.Dialogs.Views
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
