using Avalonia.Controls;
using Avalonia.Themes.Neumorphism.Dialogs.Interfaces;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels;

namespace Avalonia.Themes.Neumorphism.Dialogs.Views
{
    public partial class CommonDialog : Window, IDialogWindowResult<DialogResult>, IHasNegativeResult
    {
        public CommonDialog() {
            InitializeComponent();
        }

        public DialogResult GetResult() => (DataContext as AlertDialogViewModel)?.DialogResult;

        public void SetNegativeResult(DialogResult result)
        {
            if (DataContext is AlertDialogViewModel viewModel)
                viewModel.DialogResult = result;
        }
    }
}
