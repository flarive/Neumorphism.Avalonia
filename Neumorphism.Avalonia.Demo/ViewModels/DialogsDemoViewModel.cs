using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Themes.Neumorphism.Dialogs;
using Avalonia.Themes.Neumorphism.Dialogs.Enums;
using Avalonia.Themes.Neumorphism.Models.Dialogs;
using Neumorphism.Avalonia.Demo.Windows;
using Neumorphism.Avalonia.Demo.Windows.ViewModels;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class DialogsDemoViewModel : ViewModelBase
    {
        private TimeSpan _previousTimePickerResult = TimeSpan.Zero;
        private DateTime _previousDatePickerResult = DateTime.Now;
        private readonly MainWindow _window;

        private ApplicationModelBase _appModelBase;



        public DialogViewModel AlertDialog { get; }
        public DialogViewModel ConfirmDialog { get; }
        public DialogViewModel ConfirmSequenceDialog { get; }
        public DialogViewModel ImageDialog { get; }
        public DialogViewModel LoginDialog { get; }
        public DialogViewModel FolderNameDialog { get; }






        public DialogsDemoViewModel(Window window)
        {
            _window = window as MainWindow;

            if (_window != null)
            {
                // PART_DialogDarkOverlay
                _appModelBase = _window.DataContext as ApplicationModelBase;
            }

            AlertDialog = new DialogViewModel("Alert dialog", CreateAlertDialog);
            ConfirmDialog = new DialogViewModel("Confirm dialog", CreateConfirmDialog);
            ConfirmSequenceDialog = new DialogViewModel("Confirm dialog sequence", CreateConfirmSequenceDialog);
            ImageDialog = new DialogViewModel("Image dialog", CreateImageDialog);
            LoginDialog = new DialogViewModel("Login dialog", CreateLoginDialog);
            FolderNameDialog = new DialogViewModel("Create folder name dialog", CreateFolderNameDialog);
        }




        private async IAsyncEnumerable<string> CreateAlertDialog()
        {
            var dialog = DialogHelper.CreateAlertDialog(new AlertDialogBuilderParams
            {
                ContentHeader = "Welcome to use Material.Avalonia",
                SupportingText = "Enjoy Material Design in AvaloniaUI!",
                WindowTitle = "Alert dialog",
                StartupLocation = WindowStartupLocation.CenterOwner
            });


            _appModelBase.IsDialogOpened = true;
            
            var result = await dialog.ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result.GetResult}";
        }

        private async IAsyncEnumerable<string> CreateConfirmDialog()
        {
            _appModelBase.IsDialogOpened = true;

            var result = await DialogHelper.CreateAlertDialog(new AlertDialogBuilderParams()
            {
                ContentHeader = "Confirm action",
                SupportingText = "Are you sure to perform this action ?",
                WindowTitle = "Confirm dialog",
                StartupLocation = WindowStartupLocation.CenterOwner,
                NegativeResult = new DialogResult("cancel"),
                DialogHeaderIcon = DialogIconKind.Help,
                Width = 480,
                DialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "CANCEL",
                        Result = "cancel"
                    },
                    new DialogButton
                    {
                        Content = "DELETE",
                        Result = "delete"
                    }
                }
            }).ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result.GetResult}";
        }

        private async IAsyncEnumerable<string> CreateConfirmSequenceDialog()
        {
            _appModelBase.IsDialogOpened = true;

            var result = await DialogHelper.CreateAlertDialog(new AlertDialogBuilderParams
            {
                ContentHeader = "Confirm action",
                SupportingText = "Are you sure you want to do that ?",
                WindowTitle = "Confirm dialog",
                DialogHeaderIcon = DialogIconKind.Help,
                StartupLocation = WindowStartupLocation.CenterOwner,
                NegativeResult = new DialogResult("cancel"),
                Borderless = true,
                Width = 480,
                DialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "CANCEL",
                        Result = "cancel"
                    },
                    new DialogButton
                    {
                        Content = "DELETE",
                        Result = "delete"
                    }
                }
            }).ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result.GetResult}";

            if (result.GetResult == "delete")
            {
                _appModelBase.IsDialogOpened = true;

                await DialogHelper.CreateAlertDialog(new AlertDialogBuilderParams
                {
                    ContentHeader = "Result",
                    SupportingText = "You have done it ! Congrats !",
                    StartupLocation = WindowStartupLocation.CenterOwner,
                    DialogHeaderIcon = DialogIconKind.Success,
                    Borderless = true,
                }).ShowDialog(_window);

                _appModelBase.IsDialogOpened = false;
            }
        }

        private async IAsyncEnumerable<string> CreateImageDialog()
        {
            // Open asset stream using assets.Open method.
            await using var icon = AssetLoader.Open(new Uri("avares://Neumorphism.Avalonia.Demo/Assets/avalonia-logo.png"));

            _appModelBase.IsDialogOpened = true;

            var dialog = DialogHelper.CreateAlertDialog(new AlertDialogBuilderParams
            {
                ContentHeader = "Welcome to use Material.Avalonia",
                SupportingText = "Enjoy Material Design in AvaloniaUI!",
                StartupLocation = WindowStartupLocation.CenterOwner,
                Borderless = true,
                // Create Image control
                DialogIcon = new Bitmap(icon),
                NeutralDialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "READ MORE...",
                        Result = "read_more"
                    }
                }
            });
            var result = await dialog.ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result.GetResult}";
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
                        Classes = "outline",
                        Label = "Account",
                        MaxCountChars = 24,
                        Validater = ValidateAccount,
                    },
                    new TextFieldBuilderParams
                    {
                        HelperText = "* Required",
                        Classes = "outline",
                        Label = "Password",
                        MaxCountChars = 64,
                        FieldKind = TextFieldKind.Masked,
                        Validater = ValidatePassword
                    }
                },
                DialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "CANCEL",
                        Result = "cancel",
                        IsNegative = true
                    },
                    new DialogButton
                    {
                        Content = "LOGIN",
                        Result = "login",
                        IsPositive = true
                    }
                }
            }).ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result.GetResult}";

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
                        Validater = ValidatePassword,
                        DefaultText = "Folder1",
                        HelperText = "* Required"
                    }
                },
                DialogButtons = new[]
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

            yield return $"Result: {result.GetResult}";

            if (result.GetResult == "rename")
            {
                yield return $"Folder name: {result.GetFieldsResult()[0].Text}";
            }
        }

        private async IAsyncEnumerable<string> TimePickerDialog()
        {
            _appModelBase.IsDialogOpened = true;

            var result = await DialogHelper.CreateTimePicker(new TimePickerDialogBuilderParams
            {
                Borderless = true,
                StartupLocation = WindowStartupLocation.CenterOwner,
                ImplicitValue = _previousTimePickerResult,
                DialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "CONFIRM",
                        Result = "confirm",
                        IsPositive = true
                    }
                }
            }).ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result.GetResult}";

            if (result.GetResult != "confirm")
                yield break;

            var r = result.GetTimeSpan();
            yield return $"TimeSpan: {r.ToString()}";
            _previousTimePickerResult = r;
        }

        private async IAsyncEnumerable<string> DatePickerDialog()
        {
            _appModelBase.IsDialogOpened = true;

            var result = await DialogHelper.CreateDatePicker(new DatePickerDialogBuilderParams
            {
                Borderless = true,
                StartupLocation = WindowStartupLocation.CenterOwner,
                ImplicitValue = _previousDatePickerResult,
                DialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "CONFIRM",
                        Result = "confirm",
                        IsPositive = true
                    }
                }
            }).ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result.GetResult}";

            if (result.GetResult != "confirm")
                yield break;

            var r = result.GetDate();
            // ReSharper disable once SimplifyStringInterpolation
            yield return $"TimeSpan: {r.ToString("d")}";
            _previousDatePickerResult = r;
        }
    }
}