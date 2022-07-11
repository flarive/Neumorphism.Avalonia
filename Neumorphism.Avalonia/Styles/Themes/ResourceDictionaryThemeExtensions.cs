using System;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;
using Neumorphism.Avalonia.Styles.Colors.ColorManipulation;

namespace Neumorphism.Avalonia.Styles.Themes
{
    public static class ResourceDictionaryExtensions
    {
        private static Guid CurrentThemeKey { get; } = Guid.NewGuid();
        private static Guid ThemeManagerKey { get; } = Guid.NewGuid();

        internal static void SetThemeInternal(this IResourceDictionary resourceDictionary, ITheme theme)
        {
            if (resourceDictionary == null) throw new ArgumentNullException(nameof(resourceDictionary));

            SetSolidColorBrush(resourceDictionary, "PrimaryHueLightBrush", theme.PrimaryLight.Color);
            SetSolidColorBrush(resourceDictionary, "PrimaryHueLightForegroundBrush", theme.PrimaryLight.ForegroundColor ?? theme.PrimaryLight.Color.ContrastingForegroundColor());
            SetSolidColorBrush(resourceDictionary, "PrimaryHueMidBrush", theme.PrimaryMid.Color);
            SetSolidColorBrush(resourceDictionary, "PrimaryHueMidForegroundBrush", theme.PrimaryMid.ForegroundColor ?? theme.PrimaryMid.Color.ContrastingForegroundColor());
            SetSolidColorBrush(resourceDictionary, "PrimaryHueDarkBrush", theme.PrimaryDark.Color);
            SetSolidColorBrush(resourceDictionary, "PrimaryHueDarkForegroundBrush", theme.PrimaryDark.ForegroundColor ?? theme.PrimaryDark.Color.ContrastingForegroundColor());

            SetSolidColorBrush(resourceDictionary, "SecondaryHueLightBrush", theme.SecondaryLight.Color);
            SetSolidColorBrush(resourceDictionary, "SecondaryHueLightForegroundBrush", theme.SecondaryLight.ForegroundColor ?? theme.SecondaryLight.Color.ContrastingForegroundColor());
            SetSolidColorBrush(resourceDictionary, "SecondaryHueMidBrush", theme.SecondaryMid.Color);
            SetSolidColorBrush(resourceDictionary, "SecondaryHueMidForegroundBrush", theme.SecondaryMid.ForegroundColor ?? theme.SecondaryMid.Color.ContrastingForegroundColor());
            SetSolidColorBrush(resourceDictionary, "SecondaryHueDarkBrush", theme.SecondaryDark.Color);
            SetSolidColorBrush(resourceDictionary, "SecondaryHueDarkForegroundBrush", theme.SecondaryDark.ForegroundColor ?? theme.SecondaryDark.Color.ContrastingForegroundColor());

            SetSolidColorBrush(resourceDictionary, "ValidationErrorBrush", theme.ValidationError);

            SetSolidColorBrush(resourceDictionary, "MaterialDesignBackground", theme.Background);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignForeground", theme.Foreground);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignPaper", theme.Paper);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignCardBackground", theme.CardBackground);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignToolBarBackground", theme.ToolBarBackground);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignBody", theme.Body);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignBodyLight", theme.BodyLight);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignColumnHeader", theme.ColumnHeader);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignCheckBoxOff", theme.CheckBoxOff);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignCheckBoxDisabled", theme.CheckBoxDisabled);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignTextBoxBorder", theme.TextBoxBorder);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignDivider", theme.Divider);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignSelection", theme.Selection);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignToolForeground", theme.ToolForeground);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignToolBackground", theme.ToolBackground);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignFlatButtonClick", theme.FlatButtonClick);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignFlatButtonRipple", theme.FlatButtonRipple);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignToolTipBackground", theme.ToolTipBackground);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignChipBackground", theme.ChipBackground);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignSnackbarBackground", theme.SnackbarBackground);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignSnackbarMouseOver", theme.SnackbarMouseOver);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignSnackbarRipple", theme.SnackbarRipple);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignTextFieldBoxBackground", theme.TextFieldBoxBackground);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignTextFieldBoxHoverBackground", theme.TextFieldBoxHoverBackground);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignTextFieldBoxDisabledBackground", theme.TextFieldBoxDisabledBackground);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignTextAreaBorder", theme.TextAreaBorder);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignTextAreaInactiveBorder", theme.TextAreaInactiveBorder);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignDataGridRowHoverBackground", theme.DataGridRowHoverBackground);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignShadowLightColor", theme.ShadowLightColor);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignShadowDarkColor", theme.ShadowDarkColor);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignBorderShadowColor", theme.BorderShadowColor);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignTransparentColor", theme.TransparentColor);
            SetSolidColorBrush(resourceDictionary, "MaterialDesignSilverGrayColor", theme.SilverGrayColor);
        }

  
        internal static void SetSolidColorBrush(this IResourceDictionary sourceDictionary, string name, Color value)
        {
            if (sourceDictionary == null) throw new ArgumentNullException(nameof(sourceDictionary));
            if (name == null) throw new ArgumentNullException(nameof(name));

            if (sourceDictionary.TryGetValue(name + "Color", out var currentValue) && currentValue as Color? == value) return;
            sourceDictionary[name + "Color"] = value;

            if (sourceDictionary.ContainsKey(name) && sourceDictionary[name] is SolidColorBrush brush) {
                Dispatcher.UIThread.InvokeAsync(delegate
                {
                    if (brush.Color == value)
                        return;
                    
                    if (brush.Transitions == null || brush.Transitions.Count == 0)
                    {
                        brush.Transitions = new Transitions
                        {
                            new ColorTransition
                            {
                                Duration = TimeSpan.FromSeconds(0.35), Easing = new SineEaseOut(),
                                Property = SolidColorBrush.ColorProperty
                            }
                        };
                    }
                
                    brush.Color = value;
                });
                
                return;
            }

            Dispatcher.UIThread.InvokeAsync(delegate
            {
                var newBrush = new SolidColorBrush(value);
                sourceDictionary[name] = newBrush;
            });
        }
    }
}