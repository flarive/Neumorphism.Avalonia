using Avalonia.Controls;
using Avalonia.Themes.Neumorphism.Dialogs.Interfaces;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels;

namespace Avalonia.Themes.Neumorphism.Dialogs.Views
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
