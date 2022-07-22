using Avalonia.Media;

namespace Neumorphism.Avalonia.Styles.Themes.Base
{
    public class NeumorphismDarkTheme : IBaseTheme
    {
        public Color ValidationErrorColor { get; } = Color.Parse("#f44336");
        public Color MaterialDesignBackground { get; } = Color.Parse("#FF000000");
        public Color MaterialDesignForeground { get; } = Color.Parse("#FFFFFFFF");
        public Color MaterialDesignPaper { get; } = Color.Parse("#FF2C3135");
        public Color MaterialDesignCardBackground { get; } = Color.Parse("#FF424242");
        public Color MaterialDesignToolBarBackground { get; } = Color.Parse("#FF212121");
        public Color MaterialDesignBody { get; } = Color.Parse("#DDFFFFFF");
        public Color MaterialDesignBodyLight { get; } = Color.Parse("#89FFFFFF");
        public Color MaterialDesignColumnHeader { get; } = Color.Parse("#BCFFFFFF");
        public Color MaterialDesignCheckBoxOff { get; } = Color.Parse("#89FFFFFF");
        public Color MaterialDesignCheckBoxDisabled { get; } = Color.Parse("#FF647076");
        public Color MaterialDesignTextBoxBorder { get; } = Color.Parse("#89FFFFFF");
        public Color MaterialDesignDivider { get; } = Color.Parse("#1FFFFFFF");
        public Color MaterialDesignSelection { get; } = Color.Parse("#44888b8f");
        public Color MaterialDesignToolForeground { get; } = Color.Parse("#FFCCCCCC");
        public Color MaterialDesignToolBackground { get; } = Color.Parse("#FFE0E0E0");
        public Color MaterialDesignFlatButtonClick { get; } = Color.Parse("#19757575");
        public Color MaterialDesignFlatButtonRipple { get; } = Color.Parse("#FFB6B6B6");
        public Color MaterialDesignToolTipBackground { get; } = Color.Parse("#EEEEEE");
        public Color MaterialDesignChipBackground { get; } = Color.Parse("#FF2E3C43");
        public Color MaterialDesignSnackbarBackground { get; } = Color.Parse("#FFCDCDCD");
        public Color MaterialDesignSnackbarMouseOver { get; } = Color.Parse("#FFB9B9BD");
        public Color MaterialDesignSnackbarRipple { get; } = Color.Parse("#FF494949");
        public Color MaterialDesignTextFieldBoxBackground { get; } = Color.Parse("#1AFFFFFF");
        public Color MaterialDesignTextFieldBoxHoverBackground { get; } = Color.Parse("#1FFFFFFF");
        public Color MaterialDesignTextFieldBoxDisabledBackground { get; } = Color.Parse("#0DFFFFFF");
        public Color MaterialDesignTextAreaBorder { get; } = Color.Parse("#BCFFFFFF");
        public Color MaterialDesignTextAreaInactiveBorder { get; } = Color.Parse("#1AFFFFFF");
        public Color MaterialDesignDataGridRowHoverBackground { get; } = Color.Parse("#14FFFFFF");

        public Color MaterialDesignShadowLightColor { get; } = Color.Parse("#22FFFFFF");
        public Color MaterialDesignShadowDarkColor { get; } = Color.Parse("#33000000");

        public Color MaterialDesignBorderShadowColor { get; } = Color.Parse("#FF404548");

        public Color MaterialDesignDisabledNoTransparencyColor { get; } = Color.Parse("#FF42464A");

        public Color MaterialDesignTransparentColor { get; } = Color.Parse("#00FFFFFF");
        public Color MaterialDesignSilverGrayColor { get; } = Color.Parse("#44333333");
    }
}