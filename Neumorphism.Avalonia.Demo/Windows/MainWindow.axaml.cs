using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Avalonia.Themes.Neumorphism.Controls;
using Neumorphism.Avalonia.Demo.Interfaces;
using Neumorphism.Avalonia.Demo.Windows.ViewModels;

namespace Neumorphism.Avalonia.Demo.Windows
{
    public sealed partial class MainWindow : Window, IMainWindow
    {
        private readonly Application _app = App.Current;

        #region Control fields

        private ToggleButton NavDrawerSwitch => this.GetControl<ToggleButton>("NavDrawerSwitch2");
        private ListBox DrawerList => this.GetControl<ListBox>("DrawerList2");
        private Carousel PageCarousel => this.GetControl<Carousel>("PageCarousel2");
        private ScrollViewer mainScroller => this.GetControl<ScrollViewer>("mainScroller2");

        #endregion


        public MainWindow() : this(default) { }
        public MainWindow(IMainWindow window)
        {
            InitializeComponent(window);
        }


        


        IThemeSwitch IMainWindow.ThemeSwitch => (IThemeSwitch)this._app!;
        IMainWindowState IMainWindow.Model => (IMainWindowState)this.DataContext;
        PixelPoint IMainWindow.Position => Utilities.GetWindowPosition(this);
        Size IMainWindow.ClientSize => this.ClientSize;
        Size? IMainWindow.FrameSize => this.FrameSize;
        WindowState IMainWindow.State => this.WindowState;

        private void InitializeComponent(IMainWindow window)
        {
            AvaloniaXamlLoader.Load(this);

            var vm = new MainViewModel<MainWindow>(this);
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "DarkThemeEnabled")
                {
                    if (vm.DarkThemeEnabled)
                    {
                        Application.Current.SetValue(ThemeVariantScope.ActualThemeVariantProperty, ThemeVariant.Dark);
                    }
                    else
                    {
                        Application.Current.SetValue(ThemeVariantScope.ActualThemeVariantProperty, ThemeVariant.Light);
                    }
                }
            };

            DataContext = vm;

            if (window is not null)
            {
                this.WindowStartupLocation = WindowStartupLocation.Manual;
                this.PageCarousel.SelectedIndex = window.Model != null ? window.Model.CurrentPageIndex : 0;
                this.WindowState = window.State;
                this.Position = window.Position;
                this.FrameSize = window.FrameSize;
                this.ClientSize = window.ClientSize;
            }


            #region Control getter and event binding

            DrawerList.PointerReleased += DrawerSelectionChanged;
            DrawerList.KeyUp += DrawerList_KeyUp;

            #endregion
        }

        private void TemplatedControl_OnTemplateApplied(object sender, TemplateAppliedEventArgs e)
        {
            SnackbarHost.Post("Welcome to\r\nNeumorphism.Avalonia demo !");
        }


        private void DrawerList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.Enter)
            {
                DrawerSelectionChanged(sender, null);
            }
        }

        public void DrawerSelectionChanged(object sender, RoutedEventArgs args)
        {
            var listBox = sender as ListBox;
            if (!listBox.IsFocused && !listBox.IsKeyboardFocusWithin)
                return;
            try
            {
                PageCarousel.SelectedIndex = listBox.SelectedIndex;
                mainScroller.Offset = Vector.Zero;
                mainScroller.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                ((IMainWindowState)this.DataContext).CurrentPageIndex = listBox.SelectedIndex;
            }
            catch
            {
            }

            NavDrawerSwitch.IsChecked = false;
        }
    }
}
