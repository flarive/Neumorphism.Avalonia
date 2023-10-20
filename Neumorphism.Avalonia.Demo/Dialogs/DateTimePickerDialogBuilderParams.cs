using System;
using Neumorphism.Avalonia.Demo.Dialogs.Bases;

namespace Neumorphism.Avalonia.Demo.Dialogs
{
    public class DatePickerDialogBuilderParams : TwoFeedbackDialogBuilderParamsBase
    {
        /// <summary>
        /// Define implicit date.
        /// </summary>
        public DateTime ImplicitValue = DateTime.Now;
    }

    public class TimePickerDialogBuilderParams : TwoFeedbackDialogBuilderParamsBase
    {
        /// <summary>
        /// Define implicit time.
        /// </summary>
        public TimeSpan ImplicitValue = TimeSpan.Zero;
    }
}