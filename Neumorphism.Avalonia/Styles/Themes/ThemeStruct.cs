using Avalonia.Media;
using Neumorphism.Avalonia.Styles.Colors;

namespace Neumorphism.Avalonia.Styles.Themes
{
    internal struct ThemeStruct : ITheme
    {
        public ThemeStruct(ITheme baseTheme)
        {
            PrimaryLight = baseTheme.PrimaryLight;
            PrimaryMid = baseTheme.PrimaryMid;
            PrimaryDark = baseTheme.PrimaryDark;
            SecondaryLight = baseTheme.SecondaryLight;
            SecondaryMid = baseTheme.SecondaryMid;
            SecondaryDark = baseTheme.SecondaryDark;
            ValidationError = baseTheme.ValidationError;
            Background = baseTheme.Background;
            Foreground = baseTheme.Foreground;
            Paper = baseTheme.Paper;
            CardBackground = baseTheme.CardBackground;
            ToolBarBackground = baseTheme.ToolBarBackground;
            Body = baseTheme.Body;
            BodyLight = baseTheme.BodyLight;
            ColumnHeader = baseTheme.ColumnHeader;
            CheckBoxOff = baseTheme.CheckBoxOff;
            CheckBoxDisabled = baseTheme.CheckBoxDisabled;
            Divider = baseTheme.Divider;
            Selection = baseTheme.Selection;
            ToolForeground = baseTheme.ToolForeground;
            ToolBackground = baseTheme.ToolBackground;
            FlatButtonClick = baseTheme.FlatButtonClick;
            FlatButtonRipple = baseTheme.FlatButtonRipple;
            ToolTipBackground = baseTheme.ToolTipBackground;
            ChipBackground = baseTheme.ChipBackground;
            SnackbarBackground = baseTheme.SnackbarBackground;
            SnackbarMouseOver = baseTheme.SnackbarMouseOver;
            SnackbarRipple = baseTheme.SnackbarRipple;
            TextBoxBorder = baseTheme.TextBoxBorder;
            TextFieldBoxBackground = baseTheme.TextFieldBoxBackground;
            TextFieldBoxHoverBackground = baseTheme.TextFieldBoxHoverBackground;
            TextFieldBoxDisabledBackground = baseTheme.TextFieldBoxDisabledBackground;
            TextAreaBorder = baseTheme.TextAreaBorder;
            TextAreaInactiveBorder = baseTheme.TextAreaInactiveBorder;
            DataGridRowHoverBackground = baseTheme.DataGridRowHoverBackground;
            ShadowLightColor = baseTheme.ShadowLightColor;
            ShadowDarkColor = baseTheme.ShadowDarkColor;
            BorderShadowColor = baseTheme.BorderShadowColor;
            DisabledNoTransparencyColor = baseTheme.DisabledNoTransparencyColor;
            TransparentColor = baseTheme.TransparentColor;
            SilverGrayColor = baseTheme.SilverGrayColor;
        }

        public ColorPair PrimaryLight { get; set; }
        public ColorPair PrimaryMid { get; set; }
        public ColorPair PrimaryDark { get; set; }
        public ColorPair SecondaryLight { get; set; }
        public ColorPair SecondaryMid { get; set; }
        public ColorPair SecondaryDark { get; set; }
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
        public Color TransparentColor { get; set; }
        public Color SilverGrayColor { get; set; }
    }
}