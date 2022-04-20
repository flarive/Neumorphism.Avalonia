using Avalonia.Controls;
using Avalonia.Dialogs;
using Avalonia.Markup.Xaml;
using Neumorphism.Avalonia.Demo.Models;
using Neumorphism.Avalonia.Styles.Assists;
using System.Collections.ObjectModel;
using Neumorphism.Avalonia.Styles.Dialog;
using static Neumorphism.Avalonia.Demo.Models.StatusEnum;
using Avalonia.VisualTree;
using System.Linq;
using Neumorphism.Avalonia.Styles;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public class Home : UserControl
    { 
        public Home()
        {
            Features = new ObservableCollection<FeatureStatusModels> {
            new FeatureStatusModels{ FeatureName = "Button (Standard)", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Button (Floating)", IsReady = Yes, IsAnimated = NotFully},
            new FeatureStatusModels{ FeatureName = "Button (Tool / Flat)", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Toggle button", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "CheckBox", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Slider (Classic)", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Slider (Modern)", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Slider (Discrete)", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Snack bar system", IsReady = NotFully, IsAnimated = No},
            new FeatureStatusModels{ FeatureName = "Popup", IsReady = NotFully, IsAnimated = No},
            new FeatureStatusModels{ FeatureName = "Dialog (DialogHost)", IsReady = No, IsAnimated = NA},
            new FeatureStatusModels{ FeatureName = "Dialog (External, in remaster progress)", IsReady = No, IsAnimated = No},
            new FeatureStatusModels{ FeatureName = "DataGrid", IsReady = NotFully, IsAnimated = NA},
            new FeatureStatusModels{ FeatureName = "Standard Fields (TextBox)", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Filled Fields (TextBox)", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Outline Fields (TextBox)", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Header Fields (TextBox)", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Standard ComboBox", IsReady = NotFully, IsAnimated = No},
            new FeatureStatusModels{ FeatureName = "Filled ComboBox", IsReady = NotFully, IsAnimated = No},
            new FeatureStatusModels{ FeatureName = "Outline ComboBox", IsReady = NotFully, IsAnimated = No},
            new FeatureStatusModels{ FeatureName = "Linear Progress Indicator", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Circular Progress Indicator", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Modern ScrollBar", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Mini ScrollBar", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Card", IsReady = Yes, IsAnimated = No},
            new FeatureStatusModels{ FeatureName = "Navigation Drawer", IsReady = Yes, IsAnimated = Yes},
            new FeatureStatusModels{ FeatureName = "Context Menu", IsReady = NotFully, IsAnimated = NotFully},
            new FeatureStatusModels{ FeatureName = "Icons (Excluded, via Material.Icons.Avalonia)", IsReady = Yes, IsAnimated = NA},
            new FeatureStatusModels{ FeatureName = "Appbar (Top)", IsReady = No, IsAnimated = NA},
            new FeatureStatusModels{ FeatureName = "Appbar (Bottom)", IsReady = No, IsAnimated = NA},
            };

            InitializeComponent();
            DataContext = this;
        }

        
        
        
        public ObservableCollection<FeatureStatusModels> Features { get; private set; }

        public void OpenLeftDrawer()
        {
            var ancestors = this.GetVisualAncestors();
            if (ancestors != null)
            {
                var navDrawer = ancestors.SingleOrDefault(p => p.GetType() == typeof(NavigationDrawer));
                if (navDrawer != null)
                {
                    ((NavigationDrawer)navDrawer).LeftDrawerOpened = true;
                }
            }
        }

        public void OpenProjectRepoLink() => GlobalCommand.OpenProjectRepoLink();

        public void OpenAvaloniaWebsiteLink() => GlobalCommand.OpenAvaloniaWebsiteLink();

        public void SwitchTransition()
        {
            var state = !TransitionAssist.GetDisableTransitions(Program.MainWindow);
            TransitionAssist.SetDisableTransitions(Program.MainWindow, state);
            DialogHelper.DisableTransitions = state;
        }

        public void ShowAboutAvaloniaUI() => new AboutAvaloniaDialog().ShowDialog(Program.MainWindow);

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Dirty hack to force redraw box shadow when theme is changed !!!!
        /// </summary>
        //private void DirtyControlsRedrawFix()
        //{
        //    var zz = this.Parent;
            
        //    var controls = this.GetVisualDescendants().OfType<InputElement>();
        //    foreach (InputElement ctrl in controls)
        //    {
        //        if (ctrl != null)
        //        {
        //            if (ctrl is CheckBox || ctrl is RadioButton)
        //            {
        //                double h = ctrl.GetValue<double>(SelectionControlAssist.SizeProperty);
        //                ctrl.SetValue(SelectionControlAssist.SizeProperty, h - 1);
        //                ctrl.SetValue(SelectionControlAssist.SizeProperty, h + 1);
        //            }

        //            if (ctrl.Height > 0)
        //            {
        //                ctrl.Height = ctrl.Height - 1;
        //                ctrl.Height = ctrl.Height + 1;
        //            }
        //            else if (ctrl.Height is double.NaN)
        //            {
        //                ctrl.Height = 0;
        //                ctrl.Height = double.NaN;
        //            }
        //        }
        //    }
        //}
    }
}
