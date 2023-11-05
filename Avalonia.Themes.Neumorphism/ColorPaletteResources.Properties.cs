using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism
{
    public partial class ColorPaletteResources
    {
        private bool _hasAccentColor;
        private Color _accentColor;
        private Color _accentColorDark1, _accentColorDark2, _accentColorDark3;
        private Color _accentColorLight1, _accentColorLight2, _accentColorLight3;


        public static readonly DirectProperty<ColorPaletteResources, Color> AccentProperty
            = AvaloniaProperty.RegisterDirect<ColorPaletteResources, Color>(nameof(Accent), r => r.Accent, (r, v) => r.Accent = v);

        /// <summary>
        /// Gets or sets the Accent color value.
        /// </summary>
        public Color Accent
        {
            get => _accentColor;
            set => SetAndRaise(AccentProperty, ref _accentColor, value);
        }

        /// <summary>
        /// Gets or sets the AltHigh color value.
        /// </summary>
        public Color AltHigh { get => GetColor("SystemAltHighColor"); set => SetColor("SystemAltHighColor", value); }

        /// <summary>
        /// Gets or sets the AltLow color value.
        /// </summary>
        public Color AltLow { get => GetColor("SystemAltLowColor"); set => SetColor("SystemAltLowColor", value); }

        /// <summary>
        /// Gets or sets the AltMedium color value.
        /// </summary>
        public Color AltMedium { get => GetColor("SystemAltMediumColor"); set => SetColor("SystemAltMediumColor", value); }

        /// <summary>
        /// Gets or sets the AltMediumHigh color value.
        /// </summary>
        public Color AltMediumHigh { get => GetColor("SystemAltMediumHighColor"); set => SetColor("SystemAltMediumHighColor", value); }

        /// <summary>
        /// Gets or sets the AltMediumLow color value.
        /// </summary>
        public Color AltMediumLow { get => GetColor("SystemAltMediumLowColor"); set => SetColor("SystemAltMediumLowColor", value); }

        /// <summary>
        /// Gets or sets the BaseHigh color value.
        /// </summary>
        public Color BaseHigh { get => GetColor("SystemBaseHighColor"); set => SetColor("SystemBaseHighColor", value); }

        /// <summary>
        /// Gets or sets the BaseLow color value.
        /// </summary>
        public Color BaseLow { get => GetColor("SystemBaseLowColor"); set => SetColor("SystemBaseLowColor", value); }

        /// <summary>
        /// Gets or sets the BaseMedium color value.
        /// </summary>
        public Color BaseMedium { get => GetColor("SystemBaseMediumColor"); set => SetColor("SystemBaseMediumColor", value); }

        /// <summary>
        /// Gets or sets the BaseMediumHigh color value.
        /// </summary>
        public Color BaseMediumHigh { get => GetColor("SystemBaseMediumHighColor"); set => SetColor("SystemBaseMediumHighColor", value); }

        /// <summary>
        /// Gets or sets the BaseMediumLow color value.
        /// </summary>
        public Color BaseMediumLow { get => GetColor("SystemBaseMediumLowColor"); set => SetColor("SystemBaseMediumLowColor", value); }

        /// <summary>
        /// Gets or sets the ChromeAltLow color value.
        /// </summary>
        public Color ChromeAltLow { get => GetColor("SystemChromeAltLowColor"); set => SetColor("SystemChromeAltLowColor", value); }

        /// <summary>
        /// Gets or sets the ChromeBlackHigh color value.
        /// </summary>
        public Color ChromeBlackHigh { get => GetColor("SystemChromeBlackHighColor"); set => SetColor("SystemChromeBlackHighColor", value); }

        /// <summary>
        /// Gets or sets the ChromeBlackLow color value.
        /// </summary>
        public Color ChromeBlackLow { get => GetColor("SystemChromeBlackLowColor"); set => SetColor("SystemChromeBlackLowColor", value); }

        /// <summary>
        /// Gets or sets the ChromeBlackMedium color value.
        /// </summary>
        public Color ChromeBlackMedium { get => GetColor("SystemChromeBlackMediumColor"); set => SetColor("SystemChromeBlackMediumColor", value); }

        /// <summary>
        /// Gets or sets the ChromeBlackMediumLow color value.
        /// </summary>
        public Color ChromeBlackMediumLow { get => GetColor("SystemChromeBlackMediumLowColor"); set => SetColor("SystemChromeBlackMediumLowColor", value); }

        /// <summary>
        /// Gets or sets the ChromeDisabledHigh color value.
        /// </summary>
        public Color ChromeDisabledHigh { get => GetColor("SystemChromeDisabledHighColor"); set => SetColor("SystemChromeDisabledHighColor", value); }

        /// <summary>
        /// Gets or sets the ChromeDisabledLow color value.
        /// </summary>
        public Color ChromeDisabledLow { get => GetColor("SystemChromeDisabledLowColor"); set => SetColor("SystemChromeDisabledLowColor", value); }

        /// <summary>
        /// Gets or sets the ChromeGray color value.
        /// </summary>
        public Color ChromeGray { get => GetColor("SystemChromeGrayColor"); set => SetColor("SystemChromeGrayColor", value); }

        /// <summary>
        /// Gets or sets the ChromeHigh color value.
        /// </summary>
        public Color ChromeHigh { get => GetColor("SystemChromeHighColor"); set => SetColor("SystemChromeHighColor", value); }

        /// <summary>
        /// Gets or sets the ChromeLow color value.
        /// </summary>
        public Color ChromeLow { get => GetColor("SystemChromeLowColor"); set => SetColor("SystemChromeLowColor", value); }

        /// <summary>
        /// Gets or sets the ChromeMedium color value.
        /// </summary>
        public Color ChromeMedium { get => GetColor("SystemChromeMediumColor"); set => SetColor("SystemChromeMediumColor", value); }

        /// <summary>
        /// Gets or sets the ChromeMediumLow color value.
        /// </summary>
        public Color ChromeMediumLow { get => GetColor("SystemChromeMediumLowColor"); set => SetColor("SystemChromeMediumLowColor", value); }

        /// <summary>
        /// Gets or sets the ChromeWhite color value.
        /// </summary>
        public Color ChromeWhite { get => GetColor("SystemChromeWhiteColor"); set => SetColor("SystemChromeWhiteColor", value); }

        /// <summary>
        /// Gets or sets the ErrorText color value.
        /// </summary>
        public Color ErrorText { get => GetColor("SystemErrorTextColor"); set => SetColor("SystemErrorTextColor", value); }

        /// <summary>
        /// Gets or sets the ListLow color value.
        /// </summary>
        public Color ListLow { get => GetColor("SystemListLowColor"); set => SetColor("SystemListLowColor", value); }

        /// <summary>
        /// Gets or sets the ListMedium color value.
        /// </summary>
        public Color ListMedium { get => GetColor("SystemListMediumColor"); set => SetColor("SystemListMediumColor", value); }

        /// <summary>
        /// Gets or sets the RegionColor color value.
        /// </summary>
        public Color RegionColor { get => GetColor("SystemRegionColor"); set => SetColor("SystemRegionColor", value); }


        //new !!!!!!!!!!!!!!


        /// <summary>
        /// Gets or sets the ValidationErrorColor color value.
        /// </summary>
        public Color ValidationErrorColor { get => GetColor("ValidationErrorColor"); set => SetColor("ValidationErrorColor", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignPaper color value.
        /// </summary>
        public Color MaterialDesignPaper { get => GetColor("MaterialDesignPaper"); set => SetColor("MaterialDesignPaper", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignBackground color value.
        /// </summary>
        public Color MaterialDesignBackground { get => GetColor("MaterialDesignBackground"); set => SetColor("MaterialDesignBackground", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignForeground color value.
        /// </summary>
        public Color MaterialDesignForeground { get => GetColor("MaterialDesignForeground"); set => SetColor("MaterialDesignForeground", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignCardBackground color value.
        /// </summary>
        public Color MaterialDesignCardBackground { get => GetColor("MaterialDesignCardBackground"); set => SetColor("MaterialDesignCardBackground", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignToolBarBackground color value.
        /// </summary>
        public Color MaterialDesignToolBarBackground { get => GetColor("MaterialDesignToolBarBackground"); set => SetColor("MaterialDesignToolBarBackground", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignBody color value.
        /// </summary>
        public Color MaterialDesignBody { get => GetColor("MaterialDesignBody"); set => SetColor("MaterialDesignBody", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignBodyLight color value.
        /// </summary>
        public Color MaterialDesignBodyLight { get => GetColor("MaterialDesignBodyLight"); set => SetColor("MaterialDesignBodyLight", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignColumnHeader color value.
        /// </summary>
        public Color MaterialDesignColumnHeader { get => GetColor("MaterialDesignColumnHeader"); set => SetColor("MaterialDesignColumnHeader", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignCheckBoxOff color value.
        /// </summary>
        public Color MaterialDesignCheckBoxOff { get => GetColor("MaterialDesignCheckBoxOff"); set => SetColor("MaterialDesignCheckBoxOff", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignCheckBoxDisabled color value.
        /// </summary>
        public Color MaterialDesignCheckBoxDisabled { get => GetColor("MaterialDesignCheckBoxDisabled"); set => SetColor("MaterialDesignCheckBoxDisabled", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignTextBoxBorder color value.
        /// </summary>
        public Color MaterialDesignTextBoxBorder { get => GetColor("MaterialDesignTextBoxBorder"); set => SetColor("MaterialDesignTextBoxBorder", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignDivider color value.
        /// </summary>
        public Color MaterialDesignDivider { get => GetColor("MaterialDesignDivider"); set => SetColor("MaterialDesignDivider", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignSelection color value.
        /// </summary>
        public Color MaterialDesignSelection { get => GetColor("MaterialDesignSelection"); set => SetColor("MaterialDesignSelection", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignToolForeground color value.
        /// </summary>
        public Color MaterialDesignToolForeground { get => GetColor("MaterialDesignToolForeground"); set => SetColor("MaterialDesignToolForeground", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignToolBackground color value.
        /// </summary>
        public Color MaterialDesignToolBackground { get => GetColor("MaterialDesignToolBackground"); set => SetColor("MaterialDesignToolBackground", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignFlatButtonClick color value.
        /// </summary>
        public Color MaterialDesignFlatButtonClick { get => GetColor("MaterialDesignFlatButtonClick"); set => SetColor("MaterialDesignFlatButtonClick", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignFlatButtonRipple color value.
        /// </summary>
        public Color MaterialDesignFlatButtonRipple { get => GetColor("MaterialDesignFlatButtonRipple"); set => SetColor("MaterialDesignFlatButtonRipple", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignToolTipBackground color value.
        /// </summary>
        public Color MaterialDesignToolTipBackground { get => GetColor("MaterialDesignToolTipBackground"); set => SetColor("MaterialDesignToolTipBackground", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignChipBackground color value.
        /// </summary>
        public Color MaterialDesignChipBackground { get => GetColor("MaterialDesignChipBackground"); set => SetColor("MaterialDesignChipBackground", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignSnackbarBackground color value.
        /// </summary>
        public Color MaterialDesignSnackbarBackground { get => GetColor("MaterialDesignSnackbarBackground"); set => SetColor("MaterialDesignSnackbarBackground", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignSnackbarMouseOver color value.
        /// </summary>
        public Color MaterialDesignSnackbarMouseOver { get => GetColor("MaterialDesignSnackbarMouseOver"); set => SetColor("MaterialDesignSnackbarMouseOver", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignSnackbarRipple color value.
        /// </summary>
        public Color MaterialDesignSnackbarRipple { get => GetColor("MaterialDesignSnackbarRipple"); set => SetColor("MaterialDesignSnackbarRipple", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignTextFieldBoxBackground color value.
        /// </summary>
        public Color MaterialDesignTextFieldBoxBackground { get => GetColor("MaterialDesignTextFieldBoxBackground"); set => SetColor("MaterialDesignTextFieldBoxBackground", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignTextFieldBoxHoverBackground color value.
        /// </summary>
        public Color MaterialDesignTextFieldBoxHoverBackground { get => GetColor("MaterialDesignTextFieldBoxHoverBackground"); set => SetColor("MaterialDesignTextFieldBoxHoverBackground", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignTextFieldBoxDisabledBackground color value.
        /// </summary>
        public Color MaterialDesignTextFieldBoxDisabledBackground { get => GetColor("MaterialDesignTextFieldBoxDisabledBackground"); set => SetColor("MaterialDesignTextFieldBoxDisabledBackground", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignTextAreaBorder color value.
        /// </summary>
        public Color MaterialDesignTextAreaBorder { get => GetColor("MaterialDesignTextAreaBorder"); set => SetColor("MaterialDesignTextAreaBorder", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignTextAreaInactiveBorder color value.
        /// </summary>
        public Color MaterialDesignTextAreaInactiveBorder { get => GetColor("MaterialDesignTextAreaInactiveBorder"); set => SetColor("MaterialDesignTextAreaInactiveBorder", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignDataGridRowHoverBackground color value.
        /// </summary>
        public Color MaterialDesignDataGridRowHoverBackground { get => GetColor("MaterialDesignDataGridRowHoverBackground"); set => SetColor("MaterialDesignDataGridRowHoverBackground", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignShadowLight color value.
        /// </summary>
        public Color MaterialDesignShadowLight { get => GetColor("MaterialDesignShadowLight"); set => SetColor("MaterialDesignShadowLight", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignShadowDark color value.
        /// </summary>
        public Color MaterialDesignShadowDark { get => GetColor("MaterialDesignShadowDark"); set => SetColor("MaterialDesignShadowDark", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignBorderShadow color value.
        /// </summary>
        public Color MaterialDesignBorderShadow { get => GetColor("MaterialDesignBorderShadow"); set => SetColor("MaterialDesignBorderShadow", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignDisabledNoTransparency color value.
        /// </summary>
        public Color MaterialDesignDisabledNoTransparency { get => GetColor("MaterialDesignDisabledNoTransparency"); set => SetColor("MaterialDesignDisabledNoTransparency", value); }


        /// <summary>
        /// Gets or sets the MaterialDesignTransparent color value.
        /// </summary>
        public Color MaterialDesignTransparent { get => GetColor("MaterialDesignTransparent"); set => SetColor("MaterialDesignTransparent", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignSilverGray color value.
        /// </summary>
        public Color MaterialDesignSilverGray { get => GetColor("MaterialDesignSilverGray"); set => SetColor("MaterialDesignSilverGray", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignDarkGray color value.
        /// </summary>
        public Color MaterialDesignDarkGray { get => GetColor("MaterialDesignDarkGray"); set => SetColor("MaterialDesignDarkGray", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignMediumGray color value.
        /// </summary>
        public Color MaterialDesignMediumGray { get => GetColor("MaterialDesignMediumGray"); set => SetColor("MaterialDesignMediumGray", value); }

        /// <summary>
        /// Gets or sets the MaterialDesignLightGray color value.
        /// </summary>
        public Color MaterialDesignLightGray { get => GetColor("MaterialDesignLightGray"); set => SetColor("MaterialDesignLightGray", value); }
    }
}