#nullable enable

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Themes.Neumorphism.Events;

namespace Avalonia.Themes.Neumorphism.Controls
{
    /// <summary>
    /// A control to allow the user to select a time.
    /// </summary>
    [TemplatePart("PART_FirstColumnDivider", typeof(Rectangle))]
    [TemplatePart("PART_FirstPickerHost", typeof(Border))]
    [TemplatePart("PART_FlyoutButton", typeof(Button))]
    [TemplatePart("PART_FlyoutButtonContentGrid", typeof(Grid))]
    [TemplatePart("PART_TextBox", typeof(TextBox))]
    [TemplatePart("PART_PickerPresenter", typeof(TimePickerPresenter))]
    [TemplatePart("PART_Popup", typeof(Popup))]
    [TemplatePart("PART_SecondColumnDivider", typeof(Rectangle))]
    [TemplatePart("PART_SecondPickerHost", typeof(Border))]
    [TemplatePart("PART_ThirdPickerHost", typeof(Border))]
    [PseudoClasses(":hasnotime")]
    public class ExtendedTimePicker : TemplatedControl
    {
        // Template Items
        private TimePickerPresenter? _presenter;
        private Button? _flyoutButton;
        private Border? _firstPickerHost;
        private Border? _secondPickerHost;
        private Border? _thirdPickerHost;
        private TextBox? _textBox;
        private Rectangle? _firstSplitter;
        private Rectangle? _secondSplitter;
        private Grid? _contentGrid;
        private Popup? _popup;




        private IDisposable? _textBoxTextChangedSubscription;

        private bool _suspendTextChangeHandler;


        private bool _settingSelectedTime;


        private string _defaultText = string.Empty;


        /// <summary>
        /// Raised when the <see cref="SelectedTime"/> property changes
        /// </summary>
        public event EventHandler<TimePickerSelectedValueChangedEventArgs>? SelectedTimeChanged;


        /// <summary>
        /// Occurs when <see cref="P:Avalonia.Controls.TimePicker.Text" />
        /// is assigned a value that cannot be interpreted as a time.
        /// </summary>
        public event EventHandler<TimePickerTimeValidationErrorEventArgs>? TimeValidationError;



        /// <summary>
        /// Defines the <see cref="MinuteIncrement"/> property
        /// </summary>
        public static readonly StyledProperty<int> MinuteIncrementProperty =
            AvaloniaProperty.Register<ExtendedTimePicker, int>(nameof(MinuteIncrement), 1, coerce: CoerceMinuteIncrement);

        /// <summary>
        /// Defines the <see cref="ClockIdentifier"/> property
        /// </summary>
        public static readonly StyledProperty<string> ClockIdentifierProperty =
           AvaloniaProperty.Register<ExtendedTimePicker, string>(nameof(ClockIdentifier), "12HourClock", coerce: CoerceClockIdentifier);


        public static readonly StyledProperty<TimeSpan?> SelectedTimeProperty =
            AvaloniaProperty.Register<ExtendedTimePicker, TimeSpan?>(
                nameof(SelectedTime),
                enableDataValidation: true,
                defaultBindingMode: BindingMode.TwoWay);


        /// <summary>
        /// Defines the <see cref="Watermark"/> property.
        /// </summary>
        public static readonly StyledProperty<string?> WatermarkProperty =
            TextBox.WatermarkProperty.AddOwner<ExtendedTimePicker>();


        /// <inheritdoc cref="TextBox.Watermark"/>
        public string? Watermark
        {
            get => GetValue(WatermarkProperty);
            set => SetValue(WatermarkProperty, value);
        }



        /// <summary>
        /// Defines the <see cref="UseFloatingWatermark"/> property.
        /// </summary>
        public static readonly StyledProperty<bool> UseFloatingWatermarkProperty =
            TextBox.UseFloatingWatermarkProperty.AddOwner<ExtendedTimePicker>();


        /// <inheritdoc cref="TextBox.UseFloatingWatermark"/>
        public bool UseFloatingWatermark
        {
            get => GetValue(UseFloatingWatermarkProperty);
            set => SetValue(UseFloatingWatermarkProperty, value);
        }



        /// <summary>
        /// Defines the <see cref="Text"/> property.
        /// </summary>
        public static readonly StyledProperty<string?> TextProperty =
            AvaloniaProperty.Register<ExtendedTimePicker, string?>(
                nameof(Text),
                enableDataValidation: true,
                defaultBindingMode: BindingMode.TwoWay);


        public string? Text
        {
            get => GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }


        


        public ExtendedTimePicker()
        {
            PseudoClasses.Set(":hasnotime", true);

            var timePattern = CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern;
            if (timePattern.IndexOf("H") != -1)
                SetCurrentValue(ClockIdentifierProperty, "24HourClock");
        }

        /// <summary>
        /// Gets or sets the minute increment in the picker
        /// </summary>
        public int MinuteIncrement
        {
            get => GetValue(MinuteIncrementProperty);
            set => SetValue(MinuteIncrementProperty, value);
        }

        private static int CoerceMinuteIncrement(AvaloniaObject sender, int value)
        {
            if (value < 1 || value > 59)
                throw new ArgumentOutOfRangeException(null, "1 >= MinuteIncrement <= 59");

            return value;
        }

        /// <summary>
        /// Gets or sets the clock identifier, either 12HourClock or 24HourClock
        /// </summary>
        public string ClockIdentifier
        {

            get => GetValue(ClockIdentifierProperty);
            set => SetValue(ClockIdentifierProperty, value);
        }

        private static string CoerceClockIdentifier(AvaloniaObject sender, string value)
        {
            if (!(string.IsNullOrEmpty(value) || value == "12HourClock" || value == "24HourClock"))
                throw new ArgumentException("Invalid ClockIdentifier", default(string));

            return value;
        }

        /// <summary>
        /// Gets or sets the selected time. Can be null.
        /// </summary>
        public TimeSpan? SelectedTime
        {
            get => GetValue(SelectedTimeProperty);
            set => SetValue(SelectedTimeProperty, value);
        }



        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            if (_flyoutButton != null)
                _flyoutButton.Click -= OnFlyoutButtonClicked;

            if (_presenter != null)
            {
                _presenter.Confirmed -= OnConfirmed;
                _presenter.Dismissed -= OnDismissPicker;
            }
            base.OnApplyTemplate(e);

            _flyoutButton = e.NameScope.Find<Button>("PART_FlyoutButton");

            _firstPickerHost = e.NameScope.Find<Border>("PART_FirstPickerHost");
            _secondPickerHost = e.NameScope.Find<Border>("PART_SecondPickerHost");
            _thirdPickerHost = e.NameScope.Find<Border>("PART_ThirdPickerHost");

            _firstSplitter = e.NameScope.Find<Rectangle>("PART_FirstColumnDivider");
            _secondSplitter = e.NameScope.Find<Rectangle>("PART_SecondColumnDivider");

            _contentGrid = e.NameScope.Find<Grid>("PART_FlyoutButtonContentGrid");

            _popup = e.NameScope.Find<Popup>("PART_Popup");
            _presenter = e.NameScope.Find<TimePickerPresenter>("PART_PickerPresenter");

            if (_flyoutButton != null)
                _flyoutButton.Click += OnFlyoutButtonClicked;

            SetGrid();
            SetSelectedTimeText();

            if (_presenter != null)
            {
                _presenter.Confirmed += OnConfirmed;
                _presenter.Dismissed += OnDismissPicker;

                _presenter[!TimePickerPresenter.MinuteIncrementProperty] = this[!MinuteIncrementProperty];
                _presenter[!TimePickerPresenter.ClockIdentifierProperty] = this[!ClockIdentifierProperty];
            }

            if (_textBox != null)
            {
                _textBox.KeyDown -= TextBox_KeyDown;
                _textBox.GotFocus -= TextBox_GotFocus;
                _textBoxTextChangedSubscription?.Dispose();
            }

            _textBox = e.NameScope.Find<TextBox>("PART_TextBox");

            //if (!SelectedTime.HasValue)
            //{
            //    //SetWaterMarkText();
            //}

            if (_textBox != null)
            {
                _textBox.KeyDown += TextBox_KeyDown;
                _textBox.GotFocus += TextBox_GotFocus;
                _textBox.LostFocus += _textBox_LostFocus;
                _textBoxTextChangedSubscription = _textBox.GetObservable(TextBox.TextProperty).Subscribe(_ => TextBox_TextChanged());

                if (SelectedTime.HasValue)
                {
                    _textBox.Text = TimeToString(SelectedTime.Value);
                    PseudoClasses.Set(":hasnotime", false);
                    SetSelectedTime();
                }
                else if (!string.IsNullOrEmpty(_defaultText))
                {
                    _textBox.Text = _defaultText;
                    PseudoClasses.Set(":hasnotime", false);
                    SetSelectedTime();
                }
            }
        }



        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == MinuteIncrementProperty)
            {
                SetSelectedTimeText();
            }
            else if (change.Property == ClockIdentifierProperty)
            {
                SetGrid();
                SetSelectedTimeText();
            }
            else if (change.Property == SelectedTimeProperty)
            {
                var (oldValue, newValue) = change.GetOldAndNewValue<TimeSpan?>();
                OnSelectedTimeChanged(oldValue, newValue);
                SetSelectedTimeText();
            }
            else if (change.Property == TextProperty)
            {
                var (_, newValue) = change.GetOldAndNewValue<string?>();

                if (!_suspendTextChangeHandler)
                {
                    if (newValue != null)
                    {
                        if (_textBox != null)
                        {
                            _textBox.Text = newValue;
                        }
                        else
                        {
                            _defaultText = newValue;
                        }

                        if (!_settingSelectedTime)
                        {
                            SetSelectedTime();
                        }
                    }
                    else
                    {
                        if (!_settingSelectedTime)
                        {
                            _settingSelectedTime = true;
                            SetCurrentValue(SelectedTimeProperty, null);
                            _settingSelectedTime = false;
                        }
                    }
                }
                else
                {
                    //SetWaterMarkText();
                }
            }
        }

        private void SetGrid()
        {
            if (_contentGrid == null)
                return;

            bool use24HourClock = ClockIdentifier == "24HourClock";

            var columnsD = use24HourClock ? "*, Auto, *" : "*, Auto, *, Auto, *";
            _contentGrid.ColumnDefinitions = new ColumnDefinitions(columnsD);

            _thirdPickerHost!.IsVisible = !use24HourClock;
            _secondSplitter!.IsVisible = !use24HourClock;

            Grid.SetColumn(_firstPickerHost!, 0);
            Grid.SetColumn(_secondPickerHost!, 2);

            Grid.SetColumn(_thirdPickerHost, use24HourClock ? 0 : 4);

            Grid.SetColumn(_firstSplitter!, 1);
            Grid.SetColumn(_secondSplitter, use24HourClock ? 0 : 3);
        }

     
        private void SetSelectedTimeText()
        {
            if (_textBox == null)
                return;

            var time = SelectedTime;
            if (time.HasValue)
            {
                var newTime = SelectedTime!.Value;

                PseudoClasses.Set(":hasnotime", false);
                _textBox.Text = TimeToString(newTime);
            }
            else
            {
                PseudoClasses.Set(":hasnotime", true);
                _textBox.Text = string.Empty;
            }
        }

        protected virtual void OnSelectedTimeChanged(TimeSpan? oldTime, TimeSpan? newTime)
        {
            SelectedTimeChanged?.Invoke(this, new TimePickerSelectedValueChangedEventArgs(oldTime, newTime));
        }

        private void OnFlyoutButtonClicked(object? sender, RoutedEventArgs e)
        {
            if (_presenter == null)
                throw new InvalidOperationException("No DatePickerPresenter found.");
            if (_popup == null)
                throw new InvalidOperationException("No Popup found.");

            _presenter.Time = SelectedTime ?? DateTime.Now.TimeOfDay;

            _popup.Placement = PlacementMode.AnchorAndGravity;
            _popup.PlacementAnchor = Avalonia.Controls.Primitives.PopupPositioning.PopupAnchor.Bottom;
            _popup.PlacementGravity = Avalonia.Controls.Primitives.PopupPositioning.PopupGravity.Bottom;
            _popup.PlacementConstraintAdjustment = Avalonia.Controls.Primitives.PopupPositioning.PopupPositionerConstraintAdjustment.SlideY;
            _popup.IsOpen = true;

            // Overlay popup hosts won't get measured until the next layout pass, but we need the
            // template to be applied to `_presenter` now. Detect this case and force a layout pass.
            //if (!_presenter.IsMeasureValid)
            //    (VisualRoot as ILayoutRoot)?.LayoutManager?.ExecuteInitialLayoutPass();

            //var deltaY = _presenter.GetOffsetForPopup();

            //var deltaY = -6;

            // The extra 5 px I think is related to default popup placement behavior
            _popup.VerticalOffset = -1;
        }

        private void OnDismissPicker(object? sender, EventArgs e)
        {
            _popup!.Close();
            Focus();
        }

        private void OnConfirmed(object? sender, EventArgs e)
        {
            _popup!.Close();
            SetCurrentValue(SelectedTimeProperty, _presenter!.Time);
        }

        /// <summary>
        /// Clear <see cref="SelectedTime"/>.
        /// </summary>
        public void Clear()
        {
            SetCurrentValue(SelectedTimeProperty, null);
        }

        private void TextBox_GotFocus(object? sender, RoutedEventArgs e)
        {

        }

        private void _textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            SetTextBoxValue(_textBox?.Text ?? string.Empty);
        }

        private void TextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = ProcessTimePickerKey(e);
            }
        }

        private bool ProcessTimePickerKey(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    {
                        SetTextBoxValue(_textBox?.Text ?? string.Empty);
                        return true;
                    }
                case Key.Down:
                    {
                        if ((e.KeyModifiers & KeyModifiers.Control) == KeyModifiers.Control)
                        {
                            //TogglePopUp();
                            return true;
                        }
                        break;
                    }
            }

            return false;
        }

        private void TextBox_TextChanged()
        {
            if (_textBox != null)
            {
                _suspendTextChangeHandler = true;
                SetCurrentValue(TextProperty, _textBox.Text);
                _suspendTextChangeHandler = false;
            }
        }

        protected virtual void OnTimeValidationError(TimePickerTimeValidationErrorEventArgs e)
        {
            TimeValidationError?.Invoke(this, e);
        }


        private void OnTimeSelected(TimeSpan? addedDate, TimeSpan? removedDate)
        {
            EventHandler<TimePickerSelectedValueChangedEventArgs>? handler = this.SelectedTimeChanged;
            if (null != handler)
            {
                Collection<TimeSpan> addedItems = new Collection<TimeSpan>();
                Collection<TimeSpan> removedItems = new Collection<TimeSpan>();

                if (addedDate.HasValue)
                {
                    addedItems.Add(addedDate.Value);
                }

                if (removedDate.HasValue)
                {
                    removedItems.Add(removedDate.Value);
                }

                handler(this, new TimePickerSelectedValueChangedEventArgs(removedDate.HasValue ? removedDate.Value : null, addedDate.HasValue ? addedDate.Value : null));
            }
        }

        private void SetSelectedTime()
        {
            if (_textBox != null)
            {
                if (!string.IsNullOrEmpty(_textBox.Text))
                {
                    string s = _textBox.Text;

                    if (SelectedTime != null)
                    {
                        string? selectedTime = TimeToString(SelectedTime.Value);
                        if (selectedTime == s)
                        {
                            return;
                        }
                    }
                    TimeSpan? ts = SetTextBoxValue(s);

                    if (SelectedTime != ts)
                    {
                        SetCurrentValue(SelectedTimeProperty, ts);
                    }
                }
                else
                {
                    if (SelectedTime != null)
                    {
                        SetCurrentValue(SelectedTimeProperty, null);
                    }
                }
            }
            else
            {
                TimeSpan? d = SetTextBoxValue(_defaultText);

                if (SelectedTime != d)
                {
                    SetCurrentValue(SelectedTimeProperty, d);
                }
            }
        }

        private TimeSpan? SetTextBoxValue(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                SetValue(TextProperty, s);
                
                SetCurrentValue(TextProperty, string.Empty);
                if (_textBox != null)
                {
                    _textBox.Text = string.Empty;
                    PseudoClasses.Set(":hasnotime", true);
                }
                Clear();
                return null;
            }
            else
            {
                TimeSpan? d = ParseText(s);
                if (d != null)
                {
                    SetValue(TextProperty, s);
                    PseudoClasses.Set(":hasnotime", false);
                    SetCurrentValue(SelectedTimeProperty, d);
                    return d;
                }
                else
                {
                    // If parse error: TextBox should have the latest valid
                    // SelectedDate value:
                    if (SelectedTime != null)
                    {
                        string? newtext = TimeToString(SelectedTime.Value);
                        SetValue(TextProperty, newtext);
                        return SelectedTime;
                    }
                    else
                    {
                        //SetWaterMarkText();
                        SetCurrentValue(TextProperty, string.Empty);

                        if (_textBox != null)
                        {
                            _textBox.Text = string.Empty;
                            PseudoClasses.Set(":hasnotime", true);
                        }

                        Clear();
                        return null;
                    }
                }
            }
        }

        private TimeSpan? ParseText(string text)
        {
            try
            {
                string template = "H:mm";

                if (ClockIdentifier == "12HourClock")
                {
                    template = "h:mm tt";
                }

                DateTime dt;
                if (DateTime.TryParseExact(text.ToUpper(), template, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                    return dt.TimeOfDay;
                }
                else
                {
                    var timeValidationError = new TimePickerTimeValidationErrorEventArgs(new ArgumentOutOfRangeException(nameof(text), "SelectedTime value is not valid."), text);
                    OnTimeValidationError(timeValidationError);

                    if (timeValidationError.ThrowException)
                    {
                        throw timeValidationError.Exception;
                    }
                }
            }
            catch (FormatException ex)
            {
                var textParseError = new TimePickerTimeValidationErrorEventArgs(ex, text);
                OnTimeValidationError(textParseError);

                if (textParseError.ThrowException)
                {
                    throw textParseError.Exception;
                }
            }

            return null;
        }


        private string? TimeToString(TimeSpan ts)
        {
            //DateTimeFormatInfo dtfi = GetCurrentDateFormat();

            if (ClockIdentifier == "12HourClock")
            {

                var hr = ts.Hours;
                hr = hr > 12 ? hr - 12 : hr == 0 ? 12 : hr;
                TimeSpan newTime = new TimeSpan(hr, ts.Minutes, 0);



                string period = ts.Hours >= 12 ? CultureInfo.CurrentCulture.DateTimeFormat.PMDesignator : CultureInfo.CurrentCulture.DateTimeFormat.AMDesignator;
                return string.Format("{0}:{1} {2}", newTime.Hours, newTime.Minutes.ToString().PadLeft(2, '0'), period);
            }

            return string.Format("{0}:{1}", ts.Hours, ts.Minutes.ToString().PadLeft(2, '0'));
        }

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



        protected override void UpdateDataValidation(AvaloniaProperty property, BindingValueType state, Exception? error)
        {
            if (property == TextProperty)
            {
                DataValidationErrors.SetError(this, error);
            }
            else if (property == SelectedTimeProperty)
            {
                DataValidationErrors.SetError(this, error);
            }
        }
    }
}
