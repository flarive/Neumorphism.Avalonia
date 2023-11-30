﻿using Avalonia.Themes.Neumorphism.Dialogs;
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
        public static IDialogWindow<DialogResult> CreateCustomFormDialog(SampleCustomDialogBuilderParams @params)
        {
            var window = new SampleCustomDialog();
            var context = new SampleCustomDialogViewModel(window)
            {
            };

            ApplyBaseParams(context, @params);

            window.DataContext = context;
            SetupWindowParameters(window, @params);
            return new DialogWindowBase<SampleCustomDialog, DialogResult>(window);
        }


        /// <summary>
        /// Create an dialog with custom content or dummy dialog.
        /// </summary>
        /// <param name="params">Parameters of building dialog</param>
        /// <returns>Instance of dialog.</returns>
        public static IDialogWindow<DialogResult> CreateCustomSettingsDialog(SampleCustomDialogBuilderParams @params)
        {
            var window = new SampleCustomDialog();
            var context = new SampleCustomDialogViewModel(window)
            {
            };

            ApplyBaseParams(context, @params);

            window.DataContext = context;
            SetupWindowParameters(window, @params);
            return new DialogWindowBase<SampleCustomDialog, DialogResult>(window);
        }
    }
}