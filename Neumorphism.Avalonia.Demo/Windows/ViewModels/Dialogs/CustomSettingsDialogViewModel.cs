using Avalonia.Controls;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels.Elements;
using Neumorphism.Avalonia.Demo.Windows.Dialogs;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Neumorphism.Avalonia.Demo.Windows.ViewModels.Dialogs
{
    public sealed class CustomSettingsDialogViewModel : DialogWindowViewModel
    {

        #region Commands

        public void OnCloseDialog(Window window)
        {
            SaveAppSettings();

            ApplyTheme();
            ApplyCulture();

            if (window != null)
            {
                window.Close(0);
            }
        }

        #endregion

        #region Properties

        private List<KeyValuePair<string, string>> _availableLanguageslines;
        public List<KeyValuePair<string, string>> AvailableLanguages
        {
            get => _availableLanguageslines;
            set
            {
                _availableLanguageslines = value;
                OnPropertyChanged(nameof(AvailableLanguages));
            }
        }



        private KeyValuePair<string, string> _selectedLanguage;
        public KeyValuePair<string, string> SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged(nameof(SelectedLanguage));
            }
        }



        private bool _useDarkTheme = true;
        public bool UseDarkTheme
        {
            get => _useDarkTheme;
            set
            {
                _useDarkTheme = value;
                OnPropertyChanged(nameof(UseDarkTheme));
            }
        }

        #endregion


        private ResultBasedDialogButtonViewModel _buttonOk;
        public ResultBasedDialogButtonViewModel ButtonOk
        {
            get { return _buttonOk; }
            set
            {
                _buttonOk = value;
                OnPropertyChanged(nameof(ButtonOk));
            }
        }

        private ResultBasedDialogButtonViewModel _buttonCancel;
        public ResultBasedDialogButtonViewModel ButtonCancel
        {
            get { return _buttonCancel; }
            set
            {
                _buttonCancel = value;
                OnPropertyChanged(nameof(ButtonCancel));
            }
        }



        public CustomSettingsDialogViewModel(CustomSettingsDialog dialog) : base(dialog)
        {
            AvailableLanguages =
            [
                new KeyValuePair<string, string>("en-US", "English"),
                new KeyValuePair<string, string>("fr-FR", "French")
            ];

            ButtonOk = new ResultBasedDialogButtonViewModel(this, "OK", "ok");
            ButtonCancel = new ResultBasedDialogButtonViewModel(this, "Cancel", "cancel");

            LoadAppSettings();
        }

        private void ApplyCulture()
        {
            if (!string.IsNullOrEmpty(SelectedLanguage.Key))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(SelectedLanguage.Key);
            }
        }

        private void ApplyTheme()
        {

        }

        private void LoadAppSettings()
        {

        }

        private void SaveAppSettings()
        {

        }
    }
}