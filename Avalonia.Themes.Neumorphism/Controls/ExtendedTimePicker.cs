#nullable enable

using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;
using System.Globalization;

namespace Avalonia.Themes.Neumorphism.Controls
{
    //[TemplatePart(ElementTextBox, typeof(TextBox))]
    public class ExtendedTimePicker : TimePicker
    {

        //private const string ElementTextBox = "PART_TextBox";

        //private TextBox? _textBox;
        //private IDisposable? _textBoxTextChangedSubscription;

        //private string _defaultText;

        //private bool _suspendTextChangeHandler;

        /// <summary>
        /// Occurs when <see cref="P:Avalonia.Controls.DatePicker.Text" />
        /// is assigned a value that cannot be interpreted as a date.
        /// </summary>
        //public event EventHandler<CalendarDatePickerDateValidationErrorEventArgs>? TimeValidationError;





        //public static readonly StyledProperty<string> TextProperty =
        //    AvaloniaProperty.Register<ExtendedTimePicker, string>(nameof(Text));

        //public string Text
        //{
        //    get => GetValue(TextProperty);
        //    set => SetValue(TextProperty, value);
        //}


        ///// <summary>
        ///// Defines the <see cref="Watermark"/> property.
        ///// </summary>
        //public static readonly StyledProperty<string?> WatermarkProperty =
        //    TextBox.WatermarkProperty.AddOwner<CalendarDatePicker>();


        ///// <inheritdoc cref="TextBox.Watermark"/>
        //public string? Watermark
        //{
        //    get => GetValue(WatermarkProperty);
        //    set => SetValue(WatermarkProperty, value);
        //}



        ///// <summary>
        ///// Defines the <see cref="UseFloatingWatermark"/> property.
        ///// </summary>
        //public static readonly StyledProperty<bool> UseFloatingWatermarkProperty =
        //    TextBox.UseFloatingWatermarkProperty.AddOwner<CalendarDatePicker>();


        ///// <inheritdoc cref="TextBox.UseFloatingWatermark"/>
        //public bool UseFloatingWatermark
        //{
        //    get => GetValue(UseFloatingWatermarkProperty);
        //    set => SetValue(UseFloatingWatermarkProperty, value);
        //}




        //protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        //{
        //    base.OnApplyTemplate(e);

        //    if (_textBox != null)
        //    {
        //        _textBox.KeyDown -= TextBox_KeyDown;
        //        _textBox.GotFocus -= TextBox_GotFocus;
        //        _textBoxTextChangedSubscription?.Dispose();
        //    }

        //    _textBox = e.NameScope.Find<TextBox>(ElementTextBox);

        //    if (_textBox != null)
        //    {
        //        _textBox.KeyDown += TextBox_KeyDown;
        //        _textBox.GotFocus += TextBox_GotFocus;
        //        _textBoxTextChangedSubscription = _textBox.GetObservable(TextBox.TextProperty).Subscribe(_ => TextBox_TextChanged());

        //        if (SelectedTime.HasValue)
        //        {
        //            _textBox.Text = TimeToString(SelectedTime.Value);
        //        }
        //        else if (!String.IsNullOrEmpty(_defaultText))
        //        {
        //            _textBox.Text = _defaultText;
        //            SetSelectedTime();
        //        }
        //    }
        //}

        //private string? TimeToString(TimeSpan ts)
        //{
        //    DateTimeFormatInfo dtfi = GetCurrentDateFormat();

        //    return string.Format("{0}:{1}", ts.Hours, ts.Minutes);
        //}


        //private void SetSelectedTime()
        //{
        //    if (_textBox != null)
        //    {
        //        if (!string.IsNullOrEmpty(_textBox.Text))
        //        {
        //            string s = _textBox.Text;

        //            if (SelectedTime != null)
        //            {
        //                  string? selectedTime = TimeToString(SelectedTime.Value);
        //                if (selectedTime == s)
        //                {
        //                    return;
        //                }
        //            }
        //            TimeSpan? d = SetTextBoxValue(s);

        //            if (SelectedTime != d)
        //            {
        //                SetCurrentValue(SelectedTimeProperty, d);
        //            }
        //        }
        //        else
        //        {
        //            if (SelectedTime != null)
        //            {
        //                SetCurrentValue(SelectedTimeProperty, null);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        TimeSpan? d = SetTextBoxValue(_defaultText);

        //        if (SelectedTime != d)
        //        {
        //            SetCurrentValue(SelectedTimeProperty, d);
        //        }
        //    }
        //}

        //private void SetSelectedTimeText()
        //{
        //    if (_textBox == null)
        //        return;

        //    var time = SelectedTime;
        //    if (time.HasValue)
        //    {
        //        _textBox.Text = "bb";
        //    }
        //    else
        //    {
        //        _textBox.Text = "aa";
        //    }
        //}


        //private TimeSpan? SetTextBoxValue(string s)
        //{
        //    if (string.IsNullOrEmpty(s))
        //    {
        //        SetValue(TextProperty, s);
        //        return SelectedTime;
        //    }
        //    else
        //    {
        //        TimeSpan? d = ParseText(s);
        //        if (d != null)
        //        {
        //            SetValue(TextProperty, s);
        //            return d;
        //        }
        //        else
        //        {
        //            // If parse error: TextBox should have the latest valid
        //            // SelectedDate value:
        //            if (SelectedTime != null)
        //            {
        //                string? newtext = TimeToString(SelectedTime.Value);
        //                SetValue(TextProperty, newtext);
        //                return SelectedTime;
        //            }
        //            else
        //            {
        //                SetWaterMarkText();
        //                return null;
        //            }
        //        }
        //    }
        //}


        //private void SetWaterMarkText()
        //{
        //    if (_textBox != null)
        //    {
        //        SetCurrentValue(TextProperty, String.Empty);

        //        if (string.IsNullOrEmpty(Watermark) && !UseFloatingWatermark)
        //        {
        //            DateTimeFormatInfo dtfi = GetCurrentDateFormat();
        //            _defaultText = string.Empty;
        //            var watermarkFormat = "<{0}>";
        //            string watermarkText;

        //            //switch (SelectedDateFormat)
        //            //{
        //            //    case CalendarDatePickerFormat.Long:
        //            //        {
        //            //            watermarkText = string.Format(CultureInfo.CurrentCulture, watermarkFormat, dtfi.LongDatePattern.ToString());
        //            //            break;
        //            //        }
        //            //    case CalendarDatePickerFormat.Short:
        //            //    default:
        //            //        {
        //            //            watermarkText = string.Format(CultureInfo.CurrentCulture, watermarkFormat, dtfi.ShortDatePattern.ToString());
        //            //            break;
        //            //        }
        //            //}

        //            watermarkText = string.Format(CultureInfo.CurrentCulture, watermarkFormat, dtfi.ShortTimePattern.ToString());


        //            _textBox.Watermark = watermarkText;
        //        }
        //        else
        //        {
        //            _textBox.ClearValue(TextBox.WatermarkProperty);
        //        }
        //    }
        //}


        ///// <summary>
        ///// Input text is parsed in the correct format and changed into a
        ///// DateTime object.  If the text can not be parsed TextParseError Event
        ///// is thrown.
        ///// </summary>
        ///// <param name="text">Inherited code: Requires comment.</param>
        ///// <returns>
        ///// IT SHOULD RETURN NULL IF THE STRING IS NOT VALID, RETURN THE
        ///// DATETIME VALUE IF IT IS VALID.
        ///// </returns>
        //private TimeSpan? ParseText(string text)
        //{
        //    TimeSpan newSelectedTime;

        //    // TryParse is not used in order to be able to pass the exception to
        //    // the TextParseError event
        //    try
        //    {
        //        newSelectedTime = TimeSpan.Parse(text, GetCurrentDateFormat());

        //        //if (Calendar.IsValidDateSelection(this._calendar!, newSelectedDate))
        //        //{
        //            return newSelectedTime;
        //        //}
        //        //else
        //        //{
        //        //    var dateValidationError = new CalendarDatePickerDateValidationErrorEventArgs(new ArgumentOutOfRangeException(nameof(text), "SelectedDate value is not valid."), text);
        //        //    OnTimeValidationError(dateValidationError);

        //        //    if (dateValidationError.ThrowException)
        //        //    {
        //        //        throw dateValidationError.Exception;
        //        //    }
        //        //}
        //    }
        //    catch (FormatException ex)
        //    {
        //        CalendarDatePickerDateValidationErrorEventArgs textParseError = new CalendarDatePickerDateValidationErrorEventArgs(ex, text);
        //        OnTimeValidationError(textParseError);

        //        if (textParseError.ThrowException)
        //        {
        //            throw textParseError.Exception;
        //        }
        //    }

        //    return null;
        //}

        //private DateTimeFormatInfo GetCurrentDateFormat()
        //{
        //    if (CultureInfo.CurrentCulture.Calendar is GregorianCalendar)
        //    {
        //        return CultureInfo.CurrentCulture.DateTimeFormat;
        //    }
        //    else
        //    {
        //        foreach (System.Globalization.Calendar cal in CultureInfo.CurrentCulture.OptionalCalendars)
        //        {
        //            if (cal is GregorianCalendar)
        //            {
        //                // if the default calendar is not Gregorian, return the
        //                // first supported GregorianCalendar dtfi
        //                DateTimeFormatInfo dtfi = new CultureInfo(CultureInfo.CurrentCulture.Name).DateTimeFormat;
        //                dtfi.Calendar = cal;
        //                return dtfi;
        //            }
        //        }

        //        // if there are no GregorianCalendars in the OptionalCalendars
        //        // list, use the invariant dtfi
        //        DateTimeFormatInfo dt = new CultureInfo(CultureInfo.InvariantCulture.Name).DateTimeFormat;
        //        dt.Calendar = new GregorianCalendar();
        //        return dt;
        //    }
        //}

        ///// <summary>
        ///// Raises the
        ///// <see cref="E:Avalonia.Controls.CalendarDatePicker.DateValidationError" />
        ///// event.
        ///// </summary>
        ///// <param name="e">
        ///// A
        ///// <see cref="T:Avalonia.Controls.CalendarDatePickerDateValidationErrorEventArgs" />
        ///// that contains the event data.
        ///// </param>
        //protected virtual void OnTimeValidationError(CalendarDatePickerDateValidationErrorEventArgs e)
        //{
        //    TimeValidationError?.Invoke(this, e);
        //}


        //private void TextBox_GotFocus(object? sender, RoutedEventArgs e)
        //{
        //    //SetCurrentValue(IsDropDownOpenProperty, false);
        //}

        //private void TextBox_KeyDown(object? sender, KeyEventArgs e)
        //{
        //    if (!e.Handled)
        //    {
        //        //e.Handled = ProcessDatePickerKey(e);
        //    }
        //}

        //private void TextBox_TextChanged()
        //{
        //    if (_textBox != null)
        //    {
        //        _suspendTextChangeHandler = true;
        //        SetCurrentValue(TextProperty, _textBox.Text);
        //        _suspendTextChangeHandler = false;
        //    }
        //}

        //protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        //{
        //    base.OnPropertyChanged(change);

        //    if (change.Property == MinuteIncrementProperty)
        //    {
        //        SetSelectedTimeText();
        //    }
        //    else if (change.Property == ClockIdentifierProperty)
        //    {
        //        //SetGrid();
        //        SetSelectedTimeText();
        //    }
        //    else if (change.Property == SelectedTimeProperty)
        //    {
        //        var (oldValue, newValue) = change.GetOldAndNewValue<TimeSpan?>();
        //        OnSelectedTimeChanged(oldValue, newValue);
        //        SetSelectedTimeText();
        //    }
        //}
    }
}