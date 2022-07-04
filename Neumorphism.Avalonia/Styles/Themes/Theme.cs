using System;
using Avalonia.Media;
using Neumorphism.Avalonia.Styles.Colors;
using Neumorphism.Avalonia.Styles.Themes.Base;

namespace Neumorphism.Avalonia.Styles.Themes
{
    public class Theme : ITheme
    {
        public static IBaseTheme Light { get; } = new NeumorphismLightTheme();
        public static IBaseTheme Dark { get; } = new NeumorphismDarkTheme();

        public ColorPair SecondaryLight { get; set; }
        public ColorPair SecondaryMid { get; set; }
        public ColorPair SecondaryDark { get; set; }

        public ColorPair PrimaryLight { get; set; }
        public ColorPair PrimaryMid { get; set; }
        public ColorPair PrimaryDark { get; set; }

        public Color ValidationError { get; set; }
        public Color Background { get; set; }
        public Color Foreground { get; set; }
        public Color Paper { get; set; }
        public Color CardBackground { get; set; }
        public Color ToolBarBackground { get; set; }
        public Color Body { get; set; }
        public Color BodyLight { get; set; }
        public Color ColumnHeader { get; set; }
        public Color CheckBoxOff { get; set; }
        public Color CheckBoxDisabled { get; set; }
        public Color Divider { get; set; }
        public Color Selection { get; set; }
        public Color ToolForeground { get; set; }
        public Color ToolBackground { get; set; }
        public Color FlatButtonClick { get; set; }
        public Color FlatButtonRipple { get; set; }
        public Color ToolTipBackground { get; set; }
        public Color ChipBackground { get; set; }
        public Color SnackbarBackground { get; set; }
        public Color SnackbarMouseOver { get; set; }
        public Color SnackbarRipple { get; set; }
        public Color TextBoxBorder { get; set; }
        public Color TextFieldBoxBackground { get; set; }
        public Color TextFieldBoxHoverBackground { get; set; }
        public Color TextFieldBoxDisabledBackground { get; set; }
        public Color TextAreaBorder { get; set; }
        public Color TextAreaInactiveBorder { get; set; }
        public Color DataGridRowHoverBackground { get; set; }
        public Color ShadowLightColor { get; set; }
        public Color ShadowDarkColor { get; set; }
        public Color BorderShadowColor { get; set; }
        public Color DisabledNoTransparencyColor { get; set; }

        

        public static BaseThemeMode? GetSystemTheme() {
            // TODO Implement getting system themes
            return null;
        }

        public static Theme Create(IBaseTheme baseTheme, Color primary, Color accent) {
            if (baseTheme is null) throw new ArgumentNullException(nameof(baseTheme));
            var theme = new Theme();

            theme.SetBaseTheme(baseTheme);
            theme.SetPrimaryColor(primary);
            theme.SetSecondaryColor(accent);

            return theme;
        }
    }
}