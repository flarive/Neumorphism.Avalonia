using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.Dialogs.Interfaces;
using Neumorphism.Avalonia.Demo.Dialogs.ViewModels;

namespace Neumorphism.Avalonia.Demo.Dialogs.Views
{
    public partial class DatePickerDialog : Window, IDialogWindowResult<DateTimePickerDialogResult>, IHasNegativeResult
    {
        private DatePickerDialogViewModel viewModel;

        public DatePickerDialog() {
            Result = new DateTimePickerDialogResult();

            InitializeComponent();
        }

        public DateTimePickerDialogResult Result { get; set; }

        public DateTimePickerDialogResult GetResult() {
            return Result;
        }

        public void SetNegativeResult(DialogResult result) {
            Result.Result = result.GetResult;
        }

        public void AttachViewModel(DatePickerDialogViewModel vm) {
            DataContext = vm;
            viewModel = vm;
        }
    }
}
