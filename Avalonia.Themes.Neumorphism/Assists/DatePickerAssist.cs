using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class DatePickerAssist
    {
        public static readonly AttachedProperty<string> DateTimeFormatProperty 
            = AvaloniaProperty.RegisterAttached<DatePicker, string>("DateTimeFormat", typeof(DatePickerAssist));

        public static string GetDateTimeFormat(DatePicker element) {
            return element.GetValue(DateTimeFormatProperty);
        }

        /// <summary>
        /// Sets <see cref="DateTimeFormatProperty"/>
        /// </summary>
        /// <param name="element">Target DatePicker</param>
        /// <param name="value">Format string</param>
        /// <remarks>When not null then 
        /// <see cref="DatePicker.YearFormat"/>, 
        /// <see cref="DatePicker.YearVisible"/>,
        /// <see cref="DatePicker.DayFormat"/>, 
        /// <see cref="DatePicker.DayVisible"/>,
        /// <see cref="DatePicker.MonthFormat"/> and 
        /// <see cref="DatePicker.MonthVisible"/>
        /// are ignored
        /// </remarks>
        /// <example>"dddd, dd MMMM yyyy" will be displayed as "Friday, 29 May 2015"</example>
        public static void SetDateTimeFormat(DatePicker element, string value) {
            element.SetValue(DateTimeFormatProperty, value);
        }


        public static AvaloniaProperty<bool> UseFloatingWatermarkProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, bool>("UseFloatingWatermark", typeof(DatePickerAssist));

        public static void SetUseFloatingWatermark(AvaloniaObject element, bool value) => element.SetValue(UseFloatingWatermarkProperty, value);

        public static bool GetUseFloatingWatermark(AvaloniaObject element) => (bool)element.GetValue(UseFloatingWatermarkProperty);





        public static AvaloniaProperty<IBrush> InnerRightBackgroundProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, IBrush>(
            "InnerRightBackground", typeof(DatePickerAssist));

        public static void SetInnerRightBackground(AvaloniaObject element, IBrush value) => element.SetValue(InnerRightBackgroundProperty, value);

        public static IBrush GetInnerRightBackground(AvaloniaObject element) => (IBrush)element.GetValue(InnerRightBackgroundProperty);






        public static AvaloniaProperty<Thickness> InnerRightPaddingProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, Thickness>(
            "InnerRightPadding", typeof(DatePickerAssist));

        public static void SetInnerRightPadding(AvaloniaObject element, Thickness value) => element.SetValue(InnerRightPaddingProperty, value);

        public static Thickness GetInnerRightPadding(AvaloniaObject element) => (Thickness)element.GetValue(InnerRightPaddingProperty);




        public static AvaloniaProperty<string> LabelProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, string>(
            "Label", typeof(DatePickerAssist));

        public static void SetLabel(AvaloniaObject element, string value) => element.SetValue(LabelProperty, value);

        public static string GetLabel(AvaloniaObject element) => (string)element.GetValue(LabelProperty);
    }
}