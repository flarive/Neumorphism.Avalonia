using System;
using Avalonia.Themes.Neumorphism.Dialogs.Commands;
using Avalonia.Themes.Neumorphism.Dialogs.Views;
using Avalonia.Threading;

namespace Avalonia.Themes.Neumorphism.Dialogs.ViewModels
{
    public sealed class DatePickerDialogViewModel : DialogWindowViewModel
    {
        private readonly DatePickerDialog _window;

        public DialogButton PositiveButton { get; internal set; }

        public DialogButton NegativeButton { get; internal set; }

        private DateTime _dateTime;

        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                OnPropertyChanged();
            }
        }

        public DatePickerDialogViewModel(DatePickerDialog dialog) : base(dialog)
        {
            ButtonClick = new MaterialDialogRelayCommand(OnPressButton, CanPressButton);
        }

        public bool CanPressButton(object args)
        {
            return true;
        }

        public async void OnPressButton(object args)
        {
            var button = args as DialogButton;
            if (button is null)
                return;

            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                var result = new DateTimePickerDialogResult(button.Result, DateTime);

                _window.Result = result;
                _window.Close();
            });
        }

        public MaterialDialogRelayCommand ButtonClick { get; }
    }
}