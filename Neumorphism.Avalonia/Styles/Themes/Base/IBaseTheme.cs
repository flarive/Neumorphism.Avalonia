using Avalonia.Media;

namespace Neumorphism.Avalonia.Styles.Themes.Base {
    public interface IBaseTheme {
        Color ValidationErrorColor { get; }
        Color MaterialDesignBackground { get; }
        Color MaterialDesignForeground { get; }
        Color MaterialDesignPaper { get; }
        Color MaterialDesignCardBackground { get; }
        Color MaterialDesignToolBarBackground { get; }
        Color MaterialDesignBody { get; }
        Color MaterialDesignBodyLight { get; }
        Color MaterialDesignColumnHeader { get; }
        Color MaterialDesignCheckBoxOff { get; }
        Color MaterialDesignCheckBoxDisabled { get; }
        Color MaterialDesignTextBoxBorder { get; }
        Color MaterialDesignDivider { get; }
        Color MaterialDesignSelection { get; }
        Color MaterialDesignToolForeground { get; }
        Color MaterialDesignToolBackground { get; }
        Color MaterialDesignFlatButtonClick { get; }
        Color MaterialDesignFlatButtonRipple { get; }
        Color MaterialDesignToolTipBackground { get; }
        Color MaterialDesignChipBackground { get; }
        Color MaterialDesignSnackbarBackground { get; }
        Color MaterialDesignSnackbarMouseOver { get; }
        Color MaterialDesignSnackbarRipple { get; }
        Color MaterialDesignTextFieldBoxBackground { get; }
        Color MaterialDesignTextFieldBoxHoverBackground { get; }
        Color MaterialDesignTextFieldBoxDisabledBackground { get; }
        Color MaterialDesignTextAreaBorder { get; }
        Color MaterialDesignTextAreaInactiveBorder { get; }
        Color MaterialDesignDataGridRowHoverBackground { get; }
        Color MaterialDesignShadowLightColor { get; }
        Color MaterialDesignShadowDarkColor { get; }
        Color MaterialDesignBorderShadowColor { get; }
        Color MaterialDesignDisabledNoTransparencyColor { get; }
    }
}