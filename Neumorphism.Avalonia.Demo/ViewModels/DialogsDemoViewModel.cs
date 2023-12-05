using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Themes.Neumorphism.Dialogs;
using Avalonia.Themes.Neumorphism.Dialogs.Enums;
using Avalonia.Themes.Neumorphism.Models.Dialogs;
using DialogHostAvalonia;
using Neumorphism.Avalonia.Demo.Helpers;
using Neumorphism.Avalonia.Demo.Models;
using Neumorphism.Avalonia.Demo.Windows;
using Neumorphism.Avalonia.Demo.Windows.ViewModels;
using Neumorphism.Avalonia.Demo.Windows.ViewModels.Dialogs;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class DialogsDemoViewModel : ViewModelBase
    {
        private readonly MainWindow _window;

        private ApplicationModelBase _appModelBase;



        public DialogViewModel InfoDialog { get; }
        public DialogViewModel WarningDialog { get; }
        public DialogViewModel ErrorDialog { get; }

        public DialogViewModel ConfirmDialog { get; }
        public DialogViewModel ConfirmSequenceDialog { get; }

        public DialogViewModel ImageDialog { get; }
        public DialogViewModel LoginDialog { get; }
        public DialogViewModel FolderNameDialog { get; }
        public DialogViewModel CustomFormDialog { get; }
        public DialogViewModel CustomSettingsDialog { get; }




        private string _openDialogWithViewResult;
        public string OpenDialogWithViewResult
        {
            get { return _openDialogWithViewResult; }
            set
            {
                _openDialogWithViewResult = value;
                OnPropertyChanged(nameof(OpenDialogWithViewResult));
            }
        }

        private string _openDialogWithModelResult;
        public string OpenDialogWithModelResult
        {
            get { return _openDialogWithModelResult; }
            set
            {
                _openDialogWithModelResult = value;
                OnPropertyChanged(nameof(OpenDialogWithModelResult));
            }
        }






        public DialogsDemoViewModel(Window window)
        {
            _window = window as MainWindow;

            if (_window != null)
            {
                // PART_DialogDarkOverlay
                _appModelBase = _window.DataContext as ApplicationModelBase;
            }

            InfoDialog = new DialogViewModel("Info dialog", CreateInfoDialog);
            WarningDialog = new DialogViewModel("Warning dialog", CreateWarningDialog);
            ErrorDialog = new DialogViewModel("Error dialog", CreateErrorDialog);

            ConfirmDialog = new DialogViewModel("Confirm dialog", CreateConfirmDialog);
            ConfirmSequenceDialog = new DialogViewModel("Confirm dialog sequence", CreateConfirmSequenceDialog);

            ImageDialog = new DialogViewModel("Image dialog", CreateImageDialog);
            LoginDialog = new DialogViewModel("Login dialog", CreateLoginDialog);
            FolderNameDialog = new DialogViewModel("Create folder name dialog", CreateFolderNameDialog);
            CustomFormDialog = new DialogViewModel("Custom form dialog", CreateCustomFormDialog);
            CustomSettingsDialog = new DialogViewModel("Custom settings dialog", CreateCustomSettingsDialog);
        }




        private async IAsyncEnumerable<string> CreateInfoDialog()
        {
            var dialog = DialogHelper.CreateAlertDialog(new AlertDialogBuilderParams
            {
                ContentHeader = "Welcome !",
                SupportingText = "This just a warm welcome info message !",
                WindowTitle = "Info dialog",
                DialogHeaderIcon = DialogIconKind.Info,
                DialogIcon = DialogIconKind.Info,
                StartupLocation = WindowStartupLocation.CenterOwner,
                Width = 480
            });


            _appModelBase.IsDialogOpened = true;
            
            var result = await dialog.ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result?.GetResult}";
        }


        private async IAsyncEnumerable<string> CreateWarningDialog()
        {
            var dialog = DialogHelper.CreateAlertDialog(new AlertDialogBuilderParams
            {
                ContentHeader = "Warning !",
                SupportingText = "You are about to do a quite dangerous action !",
                WindowTitle = "Warning dialog",
                DialogHeaderIcon = DialogIconKind.Warning,
                DialogIcon = DialogIconKind.Warning,
                StartupLocation = WindowStartupLocation.CenterOwner,
                Width = 480
            });


            _appModelBase.IsDialogOpened = true;

            var result = await dialog.ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result?.GetResult}";
        }

        private async IAsyncEnumerable<string> CreateErrorDialog()
        {
            var dialog = DialogHelper.CreateAlertDialog(new AlertDialogBuilderParams
            {
                ContentHeader = "Error !",
                SupportingText = "A strange unexpected error occured !",
                WindowTitle = "Error dialog",
                DialogHeaderIcon = DialogIconKind.Error,
                DialogIcon = DialogIconKind.Error,
                StartupLocation = WindowStartupLocation.CenterOwner,
                Width = 480
            });


            _appModelBase.IsDialogOpened = true;

            var result = await dialog.ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result?.GetResult}";
        }

        private async IAsyncEnumerable<string> CreateConfirmDialog()
        {
            _appModelBase.IsDialogOpened = true;

            var result = await DialogHelper.CreateCommonDialog(new CommonDialogBuilderParams()
            {
                ContentHeader = "Confirm action",
                SupportingText = "Are you sure to perform this action ?",
                WindowTitle = "Confirm dialog",
                StartupLocation = WindowStartupLocation.CenterOwner,
                NegativeResult = new DialogResult("cancel"),
                DialogHeaderIcon = DialogIconKind.Help,
                Width = 480,
                LeftDialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "CANCEL",
                        Result = "cancel"
                    }
                },
                RightDialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "DELETE",
                        Result = "delete"
                    }
                }
            }).ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result?.GetResult}";
        }

        private async IAsyncEnumerable<string> CreateConfirmSequenceDialog()
        {
            _appModelBase.IsDialogOpened = true;

            var result = await DialogHelper.CreateCommonDialog(new CommonDialogBuilderParams
            {
                ContentHeader = "Confirm action",
                SupportingText = "Are you sure you want to do that ?",
                WindowTitle = "Confirm dialog",
                DialogHeaderIcon = DialogIconKind.Help,
                StartupLocation = WindowStartupLocation.CenterOwner,
                NegativeResult = new DialogResult("cancel"),
                Borderless = true,
                Width = 480,
                LeftDialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "CANCEL",
                        Result = "cancel"
                    }
                },
                RightDialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "DELETE",
                        Result = "delete"
                    }
                }
            }).ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result?.GetResult}";

            if (result?.GetResult == "delete")
            {
                _appModelBase.IsDialogOpened = true;

                await DialogHelper.CreateCommonDialog(new CommonDialogBuilderParams
                {
                    ContentHeader = "Result",
                    SupportingText = "You have done it ! Congrats !",
                    StartupLocation = WindowStartupLocation.CenterOwner,
                    DialogHeaderIcon = DialogIconKind.Success,
                    Borderless = true,
                    Width = 480,
                }).ShowDialog(_window);

                _appModelBase.IsDialogOpened = false;
            }
        }

        private async IAsyncEnumerable<string> CreateImageDialog()
        {
            // Open asset stream using assets.Open method.
            await using var icon = AssetLoader.Open(new Uri("avares://Neumorphism.Avalonia.Demo/Assets/avalonia-logo.png"));

            _appModelBase.IsDialogOpened = true;

            var dialog = DialogHelper.CreateCommonDialog(new CommonDialogBuilderParams
            {
                ContentHeader = "Welcome to use Material.Avalonia",
                SupportingText = "Enjoy Material Design in AvaloniaUI!",
                StartupLocation = WindowStartupLocation.CenterOwner,
                Borderless = true,
                DialogIcon = new Bitmap(icon),
                CenterDialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "READ MORE",
                        Result = "read_more"
                    }
                }
            });
            var result = await dialog.ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result?.GetResult}";
        }

        private async IAsyncEnumerable<string> CreateLoginDialog()
        {
            _appModelBase.IsDialogOpened = true;

            var result = await DialogHelper.CreateTextFieldDialog(new TextFieldDialogBuilderParams
            {
                ContentHeader = "Authentication required.",
                SupportingText = "Please login before any action.",
                StartupLocation = WindowStartupLocation.CenterOwner,
                DialogHeaderIcon = DialogIconKind.Blocked,
                Borderless = true,
                Width = 400,
                TextFields = new[]
                {
                    new TextFieldBuilderParams
                    {
                        HelperText = "* Required",
                        Label = "Account",
                        MaxCountChars = 24,
                        Validator = ValidateAccount,
                    },
                    new TextFieldBuilderParams
                    {
                        HelperText = "* Required",
                        Label = "Password",
                        MaxCountChars = 64,
                        FieldKind = TextFieldKind.Masked,
                        Validator = ValidatePassword
                    }
                },
                LeftDialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "CANCEL",
                        Result = "cancel",
                        IsNegative = true
                    }
                },
                RightDialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "LOGIN",
                        Result = "login",
                        IsPositive = true
                    }
                }
            }).ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result?.GetResult}";

            if (result.GetResult != "login")
                yield break;

            yield return $"Account: {result.GetFieldsResult()[0].Text}";
            yield return $"Password: {result.GetFieldsResult()[1].Text}";
        }

        private Tuple<bool, string> ValidateAccount(string text)
        {
            var result = text.Length > 5;
            return new Tuple<bool, string>(result, result ? "" : "Too few account name.");
        }

        private Tuple<bool, string> ValidatePassword(string text)
        {
            var result = text.Length >= 1;
            return new Tuple<bool, string>(result, result ? "" : "Field should be filled.");
        }


        private async IAsyncEnumerable<string> CreateFolderNameDialog()
        {
            _appModelBase.IsDialogOpened = true;

            var result = await DialogHelper.CreateTextFieldDialog(new TextFieldDialogBuilderParams()
            {
                ContentHeader = "Rename folder",
                StartupLocation = WindowStartupLocation.CenterOwner,
                Borderless = true,
                Width = 400,
                TextFields = new TextFieldBuilderParams[]
                {
                    new()
                    {
                        Label = "Folder name",
                        MaxCountChars = 256,
                        Validator = ValidatePassword,
                        DefaultText = "Folder1",
                        HelperText = "* Required"
                    }
                },
                RightDialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "CANCEL",
                        Result = "cancel",
                        IsNegative = true
                    },
                    new DialogButton
                    {
                        Content = "RENAME",
                        Result = "rename",
                        IsPositive = true
                    }
                },
            }).ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result?.GetResult}";

            if (result.GetResult == "rename")
            {
                yield return $"Folder name: {result.GetFieldsResult()[0].Text}";
            }
        }


        private async IAsyncEnumerable<string> CreateCustomFormDialog()
        {
            var dialog = CustomDialogHelper.CreateCustomFormDialog(new CustomFormDialogBuilderParams
            {
                ContentHeader = "Welcome to this custom dialog !",
                SupportingText = "Following content is coming from a fully custom dialog...",
                WindowTitle = "Info dialog",
                DialogHeaderIcon = DialogIconKind.Info,
                DialogIcon = DialogIconKind.Info,
                Width = 520,
                Borderless = true
            });


            _appModelBase.IsDialogOpened = true;

            var context = dialog.GetWindow().DataContext as CustomFormDialogViewModel;

            DialogResult result = await dialog.ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result?.GetResult} / {context?.Civility.Value} {context?.FirstName} {context?.LastName}";
        }

        private async IAsyncEnumerable<string> CreateCustomSettingsDialog()
        {
            var dialog = CustomDialogHelper.CreateCustomSettingsDialog(new CustomSettingsDialogBuilderParams
            {
                ContentHeader = "Welcome to this custom dialog !",
                SupportingText = "Following content is coming from a fully custom dialog...",
                WindowTitle = "Info dialog",
                DialogHeaderIcon = DialogIconKind.Info,
                DialogIcon = DialogIconKind.Info,
                Width = 520,
                Borderless = true
            });


            _appModelBase.IsDialogOpened = true;

            var context = dialog.GetWindow().DataContext as CustomSettingsDialogViewModel;

            DialogResult result = await dialog.ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result?.GetResult} / {context?.SelectedLanguage}";
        }


        public void OpenDialogWithViewCommand()
        {
            // View DialogSampleView is defined in <UserControl.Resources> in DialogsDemo.axaml
            var view = _window.Resources["DialogSampleView"]!;
            if (view != null)
            {
                DialogHost.Show(view, "MainDialogHost", OpenDialogWithViewClose);
            }
        }

        private void OpenDialogWithViewClose(object sender, DialogClosingEventArgs eventArgs)
        {
            OpenDialogWithViewResult = $"Result: {eventArgs.Parameter}";
        }


        public void OpenDialogWithModelCommand()
        {
            // View that associated with this model defined in <Window.DataTemplates> in MainWindow.axaml
            var model = new DialogSampleModel(new Random().Next(0, 100));
            DialogHost.Show(model, "MainDialogHost", OpenDialogWithModelClose);
        }

        private void OpenDialogWithModelClose(object sender, DialogClosingEventArgs eventArgs)
        {
            var model = ((DialogHost)sender).DialogContent as DialogSampleModel;
            if (model != null)
            {
                OpenDialogWithModelResult = $"Result: {eventArgs.Parameter} / {model.Number}";
            }
        }
    }
}