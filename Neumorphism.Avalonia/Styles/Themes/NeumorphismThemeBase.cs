using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using aaa=Avalonia;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using Avalonia.Threading;
using Neumorphism.Avalonia.Styles.Colors.ColorManipulation;
using Avalonia;

namespace Neumorphism.Avalonia.Styles.Themes
{
    public class NeumorphismThemeBase : aaa.AvaloniaObject, IStyle, IResourceProvider
    {
        private readonly IStyle _controlsStyles;
        private bool _isLoading;
        private IStyle? _loaded;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentTheme"/> class.
        /// </summary>
        /// <param name="baseUri">The base URL for the XAML context.</param>
        public NeumorphismThemeBase(Uri baseUri) {
            _controlsStyles = new StyleInclude(baseUri) {
                Source = new Uri("avares://Neumorphism.Avalonia/Neumorphism.Avalonia.Templates.xaml")
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentTheme"/> class.
        /// </summary>
        /// <param name="serviceProvider">The XAML service provider.</param>
        public NeumorphismThemeBase(IServiceProvider serviceProvider)
            : this(((IUriContext)serviceProvider.GetService(typeof(IUriContext))).BaseUri) { }

        private IResourceDictionary LoadedResourceDictionary => (Loaded as aaa.Styling.Styles)!.Resources;

        public static readonly aaa.DirectProperty<NeumorphismThemeBase, ITheme> CurrentThemeProperty =
            aaa.AvaloniaProperty.RegisterDirect<NeumorphismThemeBase, ITheme>(
                nameof(CurrentTheme),
                o => o.CurrentTheme,
                (o, v) => o.CurrentTheme = v);

        private ThemeStruct _currentTheme = new();

        /// <summary>
        /// Get or set current applied theme
        /// </summary>
        /// <returns>
        /// Returns a STRUCT implementing ITheme interface 
        /// </returns>
        public ITheme CurrentTheme {
            get => new ThemeStruct(_currentTheme);
            set {
                var oldTheme = _currentTheme;
                var newTheme = new ThemeStruct(value);

                if (EqualityComparer<ITheme>.Default.Equals(oldTheme, newTheme)) return;
                _currentTheme = newTheme;
                RaisePropertyChanged(CurrentThemeProperty, oldTheme, newTheme);
                StartUpdatingTheme(oldTheme, newTheme);
            }
        }

        public IObservable<ITheme> CurrentThemeChanged => this.GetObservable(CurrentThemeProperty);

        public IResourceHost? Owner => (Loaded as IResourceProvider)?.Owner;

        /// <summary>
        /// Gets the loaded style.
        /// </summary>
        public IStyle Loaded {
            get {
                if (_loaded == null) {
                    _isLoading = true;

                    _loaded = new aaa.Styling.Styles() { _controlsStyles };

                    _isLoading = false;
                }

                return _loaded!;
            }
        }

        bool IResourceNode.HasResources => (Loaded as IResourceProvider)?.HasResources ?? false;
        IReadOnlyList<IStyle> IStyle.Children => _loaded?.Children ?? Array.Empty<IStyle>();

        public event EventHandler OwnerChanged {
            add {
                if (Loaded is IResourceProvider rp) {
                    rp.OwnerChanged += value;
                }
            }
            remove {
                if (Loaded is IResourceProvider rp) {
                    rp.OwnerChanged -= value;
                }
            }
        }

        public SelectorMatchResult TryAttach(IStyleable target, IStyleHost? host) => Loaded.TryAttach(target, host);
        public bool TryGetResource(object key, out object? value)
        {
            if (!_isLoading && Loaded is IResourceProvider p)
            {
                return p.TryGetResource(key, out value);
            }

            value = null;
            return false;
        }

        void IResourceProvider.AddOwner(IResourceHost owner) => (Loaded as IResourceProvider)?.AddOwner(owner);
        void IResourceProvider.RemoveOwner(IResourceHost owner) => (Loaded as IResourceProvider)?.RemoveOwner(owner);

        private CancellationTokenSource? _currentCancellationTokenSource;
        private Task? _currentThemeUpdateTask;
        private void StartUpdatingTheme(ITheme oldTheme, ITheme newTheme) => Task.Run(async () => {
            _currentCancellationTokenSource?.Cancel();
            _currentCancellationTokenSource?.Dispose();

            var currentToken = new CancellationTokenSource();
            _currentCancellationTokenSource = currentToken;

            if (_currentThemeUpdateTask != null) await _currentThemeUpdateTask;
            if (!currentToken.IsCancellationRequested)
            {
                _currentThemeUpdateTask = UpdateThemeAsync(oldTheme, newTheme);
            }
        });

        private Task UpdateThemeAsync(ITheme? oldTheme, ITheme newTheme)
        {
            return Task.WhenAll(
                // Primary
                UpdateSolidColorBrush("PrimaryHueLightForegroundBrush", oldTheme?.PrimaryLight.ForegroundColor ?? oldTheme?.PrimaryLight.Color.ContrastingForegroundColor(), newTheme.PrimaryLight.ForegroundColor ?? newTheme.PrimaryLight.Color.ContrastingForegroundColor()),
                UpdateSolidColorBrush("PrimaryHueMidForegroundBrush", oldTheme?.PrimaryMid.ForegroundColor ?? oldTheme?.PrimaryMid.Color.ContrastingForegroundColor(), newTheme.PrimaryMid.ForegroundColor ?? newTheme.PrimaryMid.Color.ContrastingForegroundColor()),
                UpdateSolidColorBrush("PrimaryHueDarkForegroundBrush", oldTheme?.PrimaryDark.ForegroundColor ?? oldTheme?.PrimaryDark.Color.ContrastingForegroundColor(), newTheme.PrimaryDark.ForegroundColor ?? newTheme.PrimaryDark.Color.ContrastingForegroundColor()),
                UpdateSolidColorBrush("PrimaryHueLightBrush", oldTheme?.PrimaryLight.Color, newTheme.PrimaryLight.Color),
                UpdateSolidColorBrush("PrimaryHueMidBrush", oldTheme?.PrimaryMid.Color, newTheme.PrimaryMid.Color),
                UpdateSolidColorBrush("PrimaryHueDarkBrush", oldTheme?.PrimaryDark.Color, newTheme.PrimaryDark.Color),
                // Secondary
                UpdateSolidColorBrush("SecondaryHueLightForegroundBrush", oldTheme?.SecondaryLight.ForegroundColor ?? oldTheme?.SecondaryLight.Color.ContrastingForegroundColor(), newTheme.SecondaryLight.ForegroundColor ?? newTheme.SecondaryLight.Color.ContrastingForegroundColor()),
                UpdateSolidColorBrush("SecondaryHueMidForegroundBrush", oldTheme?.SecondaryMid.ForegroundColor ?? oldTheme?.SecondaryMid.Color.ContrastingForegroundColor(), newTheme.SecondaryMid.ForegroundColor ?? newTheme.SecondaryMid.Color.ContrastingForegroundColor()),
                UpdateSolidColorBrush("SecondaryHueDarkForegroundBrush", oldTheme?.SecondaryDark.ForegroundColor ?? oldTheme?.SecondaryDark.Color.ContrastingForegroundColor(), newTheme.SecondaryDark.ForegroundColor ?? newTheme.SecondaryDark.Color.ContrastingForegroundColor()),
                UpdateSolidColorBrush("SecondaryHueLightBrush", oldTheme?.SecondaryLight.Color, newTheme.SecondaryLight.Color),
                UpdateSolidColorBrush("SecondaryHueMidBrush", oldTheme?.SecondaryMid.Color, newTheme.SecondaryMid.Color),
                UpdateSolidColorBrush("SecondaryHueDarkBrush", oldTheme?.SecondaryDark.Color, newTheme.SecondaryDark.Color),
                // Other
                UpdateSolidColorBrush("ValidationErrorBrush", oldTheme?.ValidationError, newTheme.ValidationError),
                UpdateSolidColorBrush("MaterialDesignBackground", oldTheme?.Background, newTheme.Background),
                UpdateSolidColorBrush("MaterialDesignForeground", oldTheme?.Foreground, newTheme.Foreground),
                UpdateSolidColorBrush("MaterialDesignPaper", oldTheme?.Paper, newTheme.Paper),
                UpdateSolidColorBrush("MaterialDesignCardBackground", oldTheme?.CardBackground, newTheme.CardBackground),
                UpdateSolidColorBrush("MaterialDesignToolBarBackground", oldTheme?.ToolBarBackground, newTheme.ToolBarBackground),
                UpdateSolidColorBrush("MaterialDesignBody", oldTheme?.Body, newTheme.Body),
                UpdateSolidColorBrush("MaterialDesignBodyLight", oldTheme?.BodyLight, newTheme.BodyLight),
                UpdateSolidColorBrush("MaterialDesignColumnHeader", oldTheme?.ColumnHeader, newTheme.ColumnHeader),
                UpdateSolidColorBrush("MaterialDesignCheckBoxOff", oldTheme?.CheckBoxOff, newTheme.CheckBoxOff),
                UpdateSolidColorBrush("MaterialDesignCheckBoxDisabled", oldTheme?.CheckBoxDisabled, newTheme.CheckBoxDisabled),
                UpdateSolidColorBrush("MaterialDesignTextBoxBorder", oldTheme?.TextBoxBorder, newTheme.TextBoxBorder),
                UpdateSolidColorBrush("MaterialDesignDivider", oldTheme?.Divider, newTheme.Divider),
                UpdateSolidColorBrush("MaterialDesignSelection", oldTheme?.Selection, newTheme.Selection),
                UpdateSolidColorBrush("MaterialDesignToolForeground", oldTheme?.ToolForeground, newTheme.ToolForeground),
                UpdateSolidColorBrush("MaterialDesignToolBackground", oldTheme?.ToolBackground, newTheme.ToolBackground),
                UpdateSolidColorBrush("MaterialDesignFlatButtonClick", oldTheme?.FlatButtonClick, newTheme.FlatButtonClick),
                UpdateSolidColorBrush("MaterialDesignFlatButtonRipple", oldTheme?.FlatButtonRipple, newTheme.FlatButtonRipple),
                UpdateSolidColorBrush("MaterialDesignToolTipBackground", oldTheme?.ToolTipBackground, newTheme.ToolTipBackground),
                UpdateSolidColorBrush("MaterialDesignChipBackground", oldTheme?.ChipBackground, newTheme.ChipBackground),
                UpdateSolidColorBrush("MaterialDesignSnackbarBackground", oldTheme?.SnackbarBackground, newTheme.SnackbarBackground),
                UpdateSolidColorBrush("MaterialDesignSnackbarMouseOver", oldTheme?.SnackbarMouseOver, newTheme.SnackbarMouseOver),
                UpdateSolidColorBrush("MaterialDesignSnackbarRipple", oldTheme?.SnackbarRipple, newTheme.SnackbarRipple),
                UpdateSolidColorBrush("MaterialDesignTextFieldBoxBackground", oldTheme?.TextFieldBoxBackground, newTheme.TextFieldBoxBackground),
                UpdateSolidColorBrush("MaterialDesignTextFieldBoxHoverBackground", oldTheme?.TextFieldBoxHoverBackground, newTheme.TextFieldBoxHoverBackground),
                UpdateSolidColorBrush("MaterialDesignTextFieldBoxDisabledBackground", oldTheme?.TextFieldBoxDisabledBackground, newTheme.TextFieldBoxDisabledBackground),
                UpdateSolidColorBrush("MaterialDesignTextAreaBorder", oldTheme?.TextAreaBorder, newTheme.TextAreaBorder),
                UpdateSolidColorBrush("MaterialDesignTextAreaInactiveBorder", oldTheme?.TextAreaInactiveBorder, newTheme.TextAreaInactiveBorder),
                UpdateSolidColorBrush("MaterialDesignDataGridRowHoverBackground", oldTheme?.DataGridRowHoverBackground, newTheme.DataGridRowHoverBackground),
                UpdateSolidColorBrush("MaterialDesignShadowLightColor", oldTheme?.ShadowLightColor, newTheme.ShadowLightColor),
                UpdateSolidColorBrush("MaterialDesignShadowDarkColor", oldTheme?.ShadowDarkColor, newTheme.ShadowDarkColor),
                UpdateSolidColorBrush("MaterialDesignBorderShadowColor", oldTheme?.BorderShadowColor, newTheme.BorderShadowColor),
                UpdateSolidColorBrush("MaterialDesignDisabledNoTransparencyColor", oldTheme?.DisabledNoTransparencyColor, newTheme.DisabledNoTransparencyColor),
                UpdateLinearGradientBrush("MaterialDesignLinearGradient1", oldTheme?.TransparentColor, oldTheme?.SilverGrayColor, newTheme.TransparentColor, newTheme.SilverGrayColor)
            ); ;
        }

        private Task UpdateSolidColorBrush(string brushName, Color? oldColor, Color newColor)
        {
            if (oldColor == newColor) return Task.CompletedTask;

            return LoadedResourceDictionary.TryGetValue(brushName, out var b) && b is SolidColorBrush brush
                ? UpdateBrushAsync(brushName)
                : CreateBrushAsync(brushName);


            Task UpdateBrushAsync(string brushName)
                => Dispatcher.UIThread.InvokeAsync(() => {
                    brush.Color = newColor;
                });

            Task CreateBrushAsync(string brushName)
                => Dispatcher.UIThread.InvokeAsync(() => {
                    LoadedResourceDictionary[brushName] = new SolidColorBrush(newColor) {
                        Transitions = new Transitions {
                            new ColorTransition {
                                Duration = TimeSpan.FromSeconds(0.35),
                                Easing = new SineEaseOut(),
                                Property = SolidColorBrush.ColorProperty
                            }
                        }
                    };
                });
        }


        private Task UpdateLinearGradientBrush(string brushName, Color? oldFromColor, Color? oldToColor, Color newFromColor, Color newToColor)
        {
            if (oldFromColor == newFromColor && oldToColor == newToColor) return Task.CompletedTask;

            return LoadedResourceDictionary.TryGetValue(brushName, out var b) && b is LinearGradientBrush brush
                ? UpdateLinearGradientBrushAsync(brushName)
                : CreateLinearGradientBrushAsync(brushName);



            Task UpdateLinearGradientBrushAsync(string brushName)
                => Dispatcher.UIThread.InvokeAsync(() => {
                    brush.GradientStops[0].Color = newFromColor;
                    brush.GradientStops[1].Color = newToColor;
                });

            Task CreateLinearGradientBrushAsync(string brushName)
                => Dispatcher.UIThread.InvokeAsync(() => {
                    var l = new LinearGradientBrush();
                    l.StartPoint = new RelativePoint(0.0f, 0.4f, RelativeUnit.Relative);
                    l.EndPoint = new RelativePoint(0.0f, 1.0f, RelativeUnit.Relative);
                    l.GradientStops = new GradientStops();
                    l.GradientStops.Add(new GradientStop(newFromColor, 0.0f));
                    l.GradientStops.Add(new GradientStop(newToColor, 1.0f));

                    l.Transitions = new Transitions {
                            new ColorTransition {
                                Duration = TimeSpan.FromSeconds(0.35),
                                Easing = new SineEaseOut(),
                                Property = SolidColorBrush.ColorProperty
                            }
                        };

                    LoadedResourceDictionary[brushName] = l;


                });
        }
    }
}