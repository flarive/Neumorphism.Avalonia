using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Themes.Neumorphism.Colors;
using Avalonia.Themes.Neumorphism.Colors.ColorManipulation;
using Avalonia.Themes.Neumorphism.Enums;

namespace Avalonia.Themes.Neumorphism
{
    /// <summary>
    /// Includes the fluent theme in an application.
    /// </summary>
    public class NeumorphismTheme : Styles
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NeumorphismTheme"/> class.
        /// </summary>
        /// <param name="sp">The parent's service provider.</param>
        public NeumorphismTheme(IServiceProvider sp = null)
        {
            AvaloniaXamlLoader.Load(sp, this);
        }



        public static readonly StyledProperty<ApplicationTheme> BaseThemeProperty
            = AvaloniaProperty.Register<NeumorphismTheme, ApplicationTheme>(nameof(BaseTheme));

        public ApplicationTheme BaseTheme
        {
            get => GetValue(BaseThemeProperty);
            set => SetValue(BaseThemeProperty, value);
        }


        public static readonly StyledProperty<PrimaryColor> PrimaryColorProperty =
            AvaloniaProperty.Register<NeumorphismTheme, PrimaryColor>(nameof(PrimaryColor));


        // <summary>
        /// Gets or sets the primary color of the neumorphism theme
        /// </summary>
        public PrimaryColor PrimaryColor
        {
            get => GetValue(PrimaryColorProperty);
            set => SetValue(PrimaryColorProperty, value);
        }


        public static readonly StyledProperty<SecondaryColor> SecondaryColorProperty =
            AvaloniaProperty.Register<NeumorphismTheme, SecondaryColor>(nameof(SecondaryColor));


        // <summary>
        /// Gets or sets the secondary color of the neumorphism theme
        /// </summary>
        public SecondaryColor SecondaryColor
        {
            get => GetValue(SecondaryColorProperty);
            set => SetValue(SecondaryColorProperty, value);
        }



        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == PrimaryColorProperty)
            {
                Color primaryColor = SwatchHelper.Lookup[(MaterialColor)PrimaryColor];

                var primaryLight = primaryColor.Lighten();
                var primaryMid = primaryColor;
                var primaryDark = primaryColor.Darken();

                Application.Current!.Resources["PrimaryHueLightBrush"] = primaryLight;
                Application.Current!.Resources["PrimaryHueMidBrush"] = primaryMid;
                Application.Current!.Resources["PrimaryHueDarkBrush"] = primaryDark;

                // to finish !
                Application.Current!.Resources["PrimaryHueLightForegroundBrush"] = Color.FromRgb(255, 255, 255);
                Application.Current!.Resources["PrimaryHueMidForegroundBrush"] = Color.FromRgb(255, 255, 255);
                Application.Current!.Resources["PrimaryHueDarkForegroundBrush"] = Color.FromRgb(255, 255, 255);
            }
            else if (change.Property == SecondaryColorProperty)
            {
                Color secondaryColor = SwatchHelper.Lookup[(MaterialColor)SecondaryColor];

                var secondaryLight = secondaryColor.Lighten();
                var secondaryMid = secondaryColor;
                var secondaryDark = secondaryColor.Darken();

                Application.Current!.Resources["SecondaryHueLightBrush"] = secondaryLight;
                Application.Current!.Resources["SecondaryHueMidBrush"] = secondaryMid;
                Application.Current!.Resources["SecondaryHueDarkBrush"] = secondaryDark;

                // to finish !
                Application.Current!.Resources["SecondaryHueLightForegroundBrush"] = Color.FromRgb(255, 255, 255); 
                Application.Current!.Resources["SecondaryHueMidForegroundBrush"] = Color.FromRgb(255, 255, 255); 
                Application.Current!.Resources["SecondaryHueDarkForegroundBrush"] = Color.FromRgb(255, 255, 255); 
            }
            else if (change.Property == BaseThemeProperty)
            {
                if (BaseTheme == ApplicationTheme.Dark)
                {
                    Application.Current.SetValue(ThemeVariantScope.ActualThemeVariantProperty, ThemeVariant.Dark);
                }
                else
                {
                    Application.Current.SetValue(ThemeVariantScope.ActualThemeVariantProperty, ThemeVariant.Light);
                }
            }
        }
    }
}
