using Avalonia.Themes.Neumorphism.Dialogs.Bases;
using System;

namespace Avalonia.Themes.Neumorphism.Dialogs
{
    public sealed class DatePickerDialogBuilderParams : TwoFeedbackDialogBuilderParamsBase
    {
        /// <summary>
        /// Define implicit date.
        /// </summary>
        public DateTime ImplicitValue = DateTime.Now;
    }

    public sealed class TimePickerDialogBuilderParams : TwoFeedbackDialogBuilderParamsBase
    {
        /// <summary>
        /// Define implicit time.
        /// </summary>
        public TimeSpan ImplicitValue = TimeSpan.Zero;
    }
}