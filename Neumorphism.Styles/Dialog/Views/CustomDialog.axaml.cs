using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Neumorphism.Styles.Dialog.Interfaces;
using Neumorphism.Styles.Dialog.ViewModels;

namespace Neumorphism.Styles.Dialog.Views
{
    public class CustomDialog : Window, IDialogWindowResult<DialogResult>, IHasNegativeResult
    {
        public CustomDialog()
        {
            InitializeComponent(); 
        }

        public DialogResult GetResult() => (DataContext as CustomDialogViewModel)?.DialogResult;

        public void SetNegativeResult(DialogResult result)
        {
            if (DataContext is CustomDialogViewModel viewModel)
                viewModel.DialogResult = result;
        }

        private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
    }
}
