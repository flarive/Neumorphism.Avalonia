using Avalonia.Controls;
using Avalonia.Themes.Neumorphism.Dialogs;
using Avalonia.Themes.Neumorphism.Dialogs.Interfaces;
using Neumorphism.Avalonia.Demo.Windows.ViewModels;

namespace Neumorphism.Avalonia.Demo.Windows
{
    public partial class SampleCustomDialog : Window, IDialogWindowResult<DialogResult>, IHasNegativeResult
    {
        public SampleCustomDialog() {
            InitializeComponent();
        }

        public DialogResult GetResult() => (DataContext as SampleCustomDialogViewModel)?.DialogResult;

        public void SetNegativeResult(DialogResult result) {
            if (DataContext is SampleCustomDialogViewModel viewModel)
                viewModel.DialogResult = result;
        }
    }
}