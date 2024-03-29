﻿using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Themes.Neumorphism.Dialogs.Enums;

namespace Avalonia.Themes.Neumorphism.Dialogs.Icons
{
    public sealed class DialogIcon : TemplatedControl
    {
        public static readonly StyledProperty<DialogIconKind> KindProperty
            = AvaloniaProperty.Register<DialogIcon, DialogIconKind>(nameof(Kind));

        public static readonly StyledProperty<StreamGeometry> DataProperty
            = AvaloniaProperty.Register<DialogIcon, StreamGeometry>(nameof(Data));

        public static readonly StyledProperty<string> DataPathProperty
            = AvaloniaProperty.Register<DialogIcon, string>(nameof(DataPath));

        public static readonly StyledProperty<bool> UseRecommendColorProperty
            = AvaloniaProperty.Register<DialogIcon, bool>(nameof(UseRecommendColor), true);
        static DialogIcon()
        {
            KindProperty.Changed.AddClassHandler<DialogIcon>(KindPropertyChangedCallback);
            UseRecommendColorProperty.Changed.AddClassHandler<DialogIcon>(UseRecommendColorPropertyChangedCallback);
        }

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public DialogIconKind Kind
        {
            get => GetValue(KindProperty);
            set => SetValue(KindProperty, value);
        }

        /// <summary>
        /// Gets the icon path data for the current <see cref="Kind"/>.
        /// </summary> 
        public StreamGeometry Data
        {
            get => GetValue(DataProperty);
            private set => SetValue(DataProperty, value);
        }

        /// <summary>
        /// Gets the icon path data for the current <see cref="Kind"/>.
        /// </summary>
        public string DataPath
        {
            get => GetValue(DataPathProperty);
            private set => SetValue(DataPathProperty, value);
        }

        public bool UseRecommendColor
        {
            get => GetValue(UseRecommendColorProperty);
            set => SetValue(UseRecommendColorProperty, value);
        }

        private static void KindPropertyChangedCallback(DialogIcon dialogIcon, AvaloniaPropertyChangedEventArgs avaloniaPropertyChangedEventArgs)
        {
            dialogIcon.UpdateData();
            dialogIcon.UpdateColor();
        }

        private static void UseRecommendColorPropertyChangedCallback(DialogIcon dialogIcon, AvaloniaPropertyChangedEventArgs avaloniaPropertyChangedEventArgs)
        {
            dialogIcon.UpdateColor();
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            UpdateData();
        }

        private void UpdateData()
        {
            string data = null;
            DialogIconsDataFactory.DataIndex.Value?.TryGetValue(Kind, out data);
            var g = StreamGeometry.Parse(data);
            this.Data = g;
            this.DataPath = data;
        }

        private void UpdateColor()
        {
            if (UseRecommendColor)
            {
                string color = null;
                DialogIconsDataFactory.RecommendColorIndex.Value?.TryGetValue(Kind, out color);
                Foreground = SolidColorBrush.Parse(color);
            }
        }
    }
}
