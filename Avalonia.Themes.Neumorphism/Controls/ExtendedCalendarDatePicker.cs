#nullable enable

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Avalonia.Reactive;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Layout;
using System.Globalization;
using System.Reactive.Disposables;

namespace Avalonia.Themes.Neumorphism.Controls
{
    public partial class ExtendedCalendarDatePicker : CalendarDatePicker
    {
        private TextBox? _textBox;


        /// <inheritdoc/>
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            
            _textBox = e.NameScope.Find<TextBox>("PART_TextBox");
            _textBox.LostFocus += _textBox_LostFocus;
        }

        private void _textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_textBox.Text == "mmm")
            {
                _textBox.Text = "";
            }
        }

    }
}