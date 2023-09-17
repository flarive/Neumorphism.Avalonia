using Avalonia.Controls;
using Avalonia.Themes.Neumorphism.Enums;

namespace Avalonia.Themes.Neumorphism.Controls
{
    public partial class ExtendedTimePicker : TimePicker
    {

        public static readonly StyledProperty<string> WatermarkProperty = AvaloniaProperty.Register<TextBox, string>(nameof(Watermark));

        public string Watermark
        {
            get => GetValue(WatermarkProperty);
            set => SetValue(WatermarkProperty, value);
        }




  
        public static readonly StyledProperty<bool> UseFloatingWatermarkProperty = AvaloniaProperty.Register<TextBox, bool>(nameof(UseFloatingWatermark));

        public bool UseFloatingWatermark
        {
            get => GetValue(UseFloatingWatermarkProperty);
            set => SetValue(UseFloatingWatermarkProperty, value);
        }





        public static readonly StyledProperty<string> CustomTimeFormatStringProperty = AvaloniaProperty.Register<ExtendedTimePicker, string>(
                nameof(CustomTimeFormatString),
                defaultValue: "d",
                validate: IsValidTimeFormatString);
 
        public string CustomTimeFormatString
        {
            get => GetValue(CustomTimeFormatStringProperty);
            set => SetValue(CustomTimeFormatStringProperty, value);
        }







        public static readonly StyledProperty<ExtendedTimePickerFormat> SelectedTimeFormatProperty = AvaloniaProperty.Register<ExtendedTimePicker, ExtendedTimePickerFormat>(
                nameof(SelectedTimeFormat),
                defaultValue: ExtendedTimePickerFormat.Default,
                validate: IsValidSelectedTimeFormat);


        public ExtendedTimePickerFormat SelectedTimeFormat
        {
            get => GetValue(SelectedTimeFormatProperty);
            set => SetValue(SelectedTimeFormatProperty, value);
        }



        public ExtendedTimePicker() : base()
        {
            
        }

        private static bool IsValidSelectedTimeFormat(ExtendedTimePickerFormat value)
        {
            return value == ExtendedTimePickerFormat.Default
                || value == ExtendedTimePickerFormat.Long
                || value == ExtendedTimePickerFormat.Short
                || value == ExtendedTimePickerFormat.Custom;
        }

        private static bool IsValidTimeFormatString(string formatString)
        {
            return !string.IsNullOrWhiteSpace(formatString);
        }

    }
}
