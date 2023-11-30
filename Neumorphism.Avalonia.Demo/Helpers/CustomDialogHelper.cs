using Avalonia.Themes.Neumorphism.Dialogs;
using Avalonia.Themes.Neumorphism.Dialogs.Bases;
using Avalonia.Themes.Neumorphism.Dialogs.Interfaces;
using Neumorphism.Avalonia.Demo.Windows.Dialogs;
using Neumorphism.Avalonia.Demo.Windows.ViewModels.Dialogs;

namespace Neumorphism.Avalonia.Demo.Helpers
{
    public class CustomDialogHelper : DialogHelper
    {
        /// <summary>
        /// Create an dialog with custom content or dummy dialog.
        /// </summary>
        /// <param name="params">Parameters of building dialog</param>
        /// <returns>Instance of dialog.</returns>
        public static IDialogWindow<DialogResult> CreateCustomFormDialog(CustomFormDialogBuilderParams @params)
        {
            var window = new CustomFormDialog();
            var context = new CustomFormDialogViewModel(window)
            {
            };

            ApplyBaseParams(context, @params);

            window.DataContext = context;
            SetupWindowParameters(window, @params);
            return new DialogWindowBase<CustomFormDialog, DialogResult>(window);
        }


        /// <summary>
        /// Create an dialog with custom content or dummy dialog.
        /// </summary>
        /// <param name="params">Parameters of building dialog</param>
        /// <returns>Instance of dialog.</returns>
        public static IDialogWindow<DialogResult> CreateCustomSettingsDialog(CustomSettingsDialogBuilderParams @params)
        {
            var window = new CustomSettingsDialog();
            var context = new CustomSettingsDialogViewModel(window)
            {
            };

            ApplyBaseParams(context, @params);

            window.DataContext = context;
            SetupWindowParameters(window, @params);
            return new DialogWindowBase<CustomSettingsDialog, DialogResult>(window);
        }
    }
}