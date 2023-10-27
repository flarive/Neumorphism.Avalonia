using System;

namespace Avalonia.Themes.Neumorphism.Events
{
    public sealed class TimePickerTimeValidationErrorEventArgs : EventArgs
    {
        private bool _throwException;

        public TimePickerTimeValidationErrorEventArgs(Exception exception, string text)
        {
            Text = text;
            Exception = exception;
        }


        public Exception Exception { get; private set; }


        public string Text { get; private set; }


        public bool ThrowException
        {
            get => _throwException;
            set
            {
                if (value && Exception == null)
                {
                    throw new ArgumentException("Cannot Throw Null Exception");
                }

                _throwException = value;
            }
        }
    }
}
