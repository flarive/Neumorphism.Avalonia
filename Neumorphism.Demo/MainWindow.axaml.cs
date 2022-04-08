using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls; 
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Neumorphism.Avalonia.Styles;
using Neumorphism.Avalonia.Styles.Assists;
using Neumorphism.Avalonia.Styles.Models;

namespace Neumorphism.Demo
{
    public class MainWindow : Window
    {
         
        #region Control fields
        private ToggleButton NavDrawerSwitch;
        private ListBox DrawerList;
        private Carousel PageCarousel;
        private ScrollViewer mainScroller;
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            this.AttachDevTools(KeyGesture.Parse("Shift+F12"));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            #region Control getter and event binding
            NavDrawerSwitch = this.Get<ToggleButton>(nameof(NavDrawerSwitch));

            DrawerList = this.Get<ListBox>(nameof(DrawerList));
            DrawerList.PointerReleased += DrawerSelectionChanged;
            DrawerList.KeyUp += DrawerList_KeyUp;

            PageCarousel = this.Get<Carousel>(nameof(PageCarousel));

            mainScroller = this.Get<ScrollViewer>(nameof(mainScroller));
            #endregion
        }

        private void DrawerList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.Enter)
                DrawerSelectionChanged(sender, null);
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
                mainScroller.VerticalScrollBarVisibility =
                    listBox.SelectedIndex == 5 ? ScrollBarVisibility.Disabled : ScrollBarVisibility.Auto;
                
            }
            catch
            {
            }
            NavDrawerSwitch.IsChecked = false;
        }

        private void TemplatedControl_OnTemplateApplied(object sender, TemplateAppliedEventArgs e)
        {
            SnackbarHost.Post("Welcome to demo of Neumorphism.Avalonia!");
        }

        private List<SnackbarModel> helloSnackBars = new List<SnackbarModel>();

        private void HelloButtonMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var helloSnackBar = new SnackbarModel("Hello, user!", TimeSpan.Zero);
            SnackbarHost.Post(helloSnackBar);
            helloSnackBars.Add(helloSnackBar);
        }

        private void GoodbyeButtonMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var snackbarModel in helloSnackBars)
            {
                SnackbarHost.Remove(snackbarModel);
            }
            
            SnackbarHost.Post("See ya next time, user!");
        }

        public void SwitchUITheme(object sender)
        {
            var toggleButton = sender as ToggleButton;
            if (toggleButton != null)
            {
                if (toggleButton.IsChecked.HasValue && toggleButton.IsChecked.Value)
                {
                    GlobalCommand.UseMaterialUIDarkTheme();
                }
                else
                {
                    GlobalCommand.UseMaterialUILightTheme();
                }
            }

            DirtyControlsRedrawFix();
        }

        /// <summary>
        /// Dirty hack to force redraw box shadow when theme is changed !!!!
        /// </summary>
        private void DirtyControlsRedrawFix()
        {
            var controls = this.GetVisualDescendants().OfType<InputElement>();
            foreach (InputElement ctrl in controls)
            {
                if (ctrl != null)
                {
                    if (ctrl is CheckBox || ctrl is RadioButton)
                    {
                        double h = ctrl.GetValue<double>(SelectionControlAssist.SizeProperty);
                        ctrl.SetValue(SelectionControlAssist.SizeProperty, h - 1);
                        ctrl.SetValue(SelectionControlAssist.SizeProperty, h + 1);
                    }
                    
                    if (ctrl.Height > 0)
                    {
                        ctrl.Height = ctrl.Height - 1;
                        ctrl.Height = ctrl.Height + 1;
                    }
                    else if (ctrl.Height is double.NaN)
                    {
                        ctrl.Height = 0;
                        ctrl.Height = double.NaN;
                    }
                }
            }
        }
    }
}