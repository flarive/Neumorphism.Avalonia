#nullable enable

using System;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace Avalonia.Themes.Neumorphism.Controls
{
    public partial class ExtendedCalendarDatePicker : CalendarDatePicker
    {
        private TextBox? _textBox;
        private Calendar? _calendar;



        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            _textBox = e.NameScope.Find<TextBox>("PART_TextBox");

            if (_textBox != null)
            {
                _textBox.Loaded -= TextBox_Loaded;
                _textBox.Loaded += TextBox_Loaded;

                _textBox.GotFocus -= TextBox_GotFocus;
                _textBox.GotFocus += TextBox_GotFocus;

                _textBox.LostFocus -= TextBox_LostFocus;
                _textBox.LostFocus += TextBox_LostFocus;
            }

            _calendar = e.NameScope.Find<Calendar>("PART_Calendar");

            base.OnApplyTemplate(e);
        }



        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (_textBox != null)
            {
                if (UseFloatingWatermark)
                {
                    _textBox.Watermark = string.Empty;
                }

                if (e != null && e.Source != null)
                {
                    string text = ((TextBox)e.Source).Text ?? string.Empty;
                    SetValue(TextProperty, text);
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_textBox != null)
            {
                if (!string.IsNullOrEmpty(_textBox.Text))
                {
                    DateTime? d = ParseText(_textBox.Text);

                    if (!d.HasValue)
                    {
                        // clear invalid text entries
                        _textBox.Text = string.Empty;
                    }
                    else
                    {
                        SetValue(SelectedDateProperty, d.Value);
                    }
                }
                else
                {
                    SetValue(TextProperty, string.Empty);
                    SetValue(SelectedDateProperty, null);
                }

                if (UseFloatingWatermark)
                {
                    _textBox.Watermark = string.Empty;
                }
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_textBox != null)
            {
                if (UseFloatingWatermark)
                {
                    _textBox.Watermark = Watermark;
                }
            }
        }


        /// <summary>
        /// Input text is parsed in the correct format and changed into a
        /// DateTime object.  If the text can not be parsed TextParseError Event
        /// is thrown.
        /// </summary>
        /// <param name="text">Inherited code: Requires comment.</param>
        /// <returns>
        /// IT SHOULD RETURN NULL IF THE STRING IS NOT VALID, RETURN THE
        /// DATETIME VALUE IF IT IS VALID.
        /// </returns>
        private DateTime? ParseText(string text)
        {
            DateTime newSelectedDate;

            // TryParse is not used in order to be able to pass the exception to
            // the TextParseError event
            try
            {
                newSelectedDate = DateTime.Parse(text, GetCurrentDateFormat());

                if (IsValidDateSelection(this._calendar!, newSelectedDate))
                {
                    return newSelectedDate;
                }
                else
                {
                    var dateValidationError = new CalendarDatePickerDateValidationErrorEventArgs(new ArgumentOutOfRangeException(nameof(text), "SelectedDate value is not valid."), text);
                    OnDateValidationError(dateValidationError);

                    if (dateValidationError.ThrowException)
                    {
                        throw dateValidationError.Exception;
                    }
                }
            }
            catch (FormatException ex)
            {
                var textParseError = new CalendarDatePickerDateValidationErrorEventArgs(ex, text);
                OnDateValidationError(textParseError);

                if (textParseError.ThrowException)
                {
                    throw textParseError.Exception;
                }
            }

            return null;
        }


        /// <summary>
        /// Taken from Avalonia DateTimeHelper
        /// </summary>
        /// <returns></returns>
        public System.Globalization.DateTimeFormatInfo GetCurrentDateFormat()
        {
            if (System.Globalization.CultureInfo.CurrentCulture.Calendar is System.Globalization.GregorianCalendar)
            {
                return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
            }
            else
            {
                foreach (System.Globalization.Calendar cal in System.Globalization.CultureInfo.CurrentCulture.OptionalCalendars)
                {
                    if (cal is System.Globalization.GregorianCalendar)
                    {
                        // if the default calendar is not Gregorian, return the
                        // first supported GregorianCalendar dtfi
                        System.Globalization.DateTimeFormatInfo dtfi = new System.Globalization.CultureInfo(System.Globalization.CultureInfo.CurrentCulture.Name).DateTimeFormat;
                        dtfi.Calendar = cal;
                        return dtfi;
                    }
                }

                // if there are no GregorianCalendars in the OptionalCalendars
                // list, use the invariant dtfi
                System.Globalization.DateTimeFormatInfo dt = new System.Globalization.CultureInfo(System.Globalization.CultureInfo.InvariantCulture.Name).DateTimeFormat;
                dt.Calendar = new System.Globalization.GregorianCalendar();
                return dt;
            }
        }

        /// <summary>
        /// Taken from Avalonia Calendar
        /// </summary>
        /// <param name="cal"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsValidDateSelection(Calendar cal, DateTime? value)
        {
            if (!value.HasValue)
            {
                return true;
            }
            else
            {
                if (cal.BlackoutDates.Contains(value.Value))
                {
                    return false;
                }
                else
                {
                    //cal._displayDateIsChanging = true;
                    //if (DateTime.Compare(value.Value, cal.DisplayDateRangeStart) < 0)
                    //{
                    //    cal.DisplayDateStart = value;
                    //}
                    //else if (DateTime.Compare(value.Value, cal.DisplayDateRangeEnd) > 0)
                    //{
                    //    cal.DisplayDateEnd = value;
                    //}
                    //cal._displayDateIsChanging = false;

                    return true;
                }
            }
        }
    }
}