using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.Dialogs.Interfaces;
using Neumorphism.Avalonia.Demo.Dialogs.ViewModels;

namespace Neumorphism.Avalonia.Demo.Dialogs.Views
{
    public partial class TimePickerDialog : Window, IDialogWindowResult<DateTimePickerDialogResult>, IHasNegativeResult
    {
        public TimePickerDialog() {
            Result = new DateTimePickerDialogResult();

            InitializeComponent();
        }
        public DateTimePickerDialogResult Result { get; set; }

        public DateTimePickerDialogResult GetResult() => Result;

        public void SetNegativeResult(DialogResult result) => Result.Result = result.GetResult;

        public void AttachViewModel(TimePickerDialogViewModel vm) {
            this.DataContext = vm;
        }
    }
}
