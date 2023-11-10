using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
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

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class DialogsDemoViewModel : ViewModelBase
    {
        private TimeSpan _previousTimePickerResult = TimeSpan.Zero;
        private DateTime _previousDatePickerResult = DateTime.Now;
        private readonly MainWindow _window;

        private ApplicationModelBase _appModelBase;



        public DialogViewModel InfoDialog { get; }
        public DialogViewModel ConfirmDialog { get; }
        public DialogViewModel ConfirmSequenceDialog { get; }
        public DialogViewModel ImageDialog { get; }
        public DialogViewModel LoginDialog { get; }
        public DialogViewModel FolderNameDialog { get; }
        public DialogViewModel CustomDialog { get; }



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

            InfoDialog = new DialogViewModel("Alert dialog", CreateInfoDialog);
            ConfirmDialog = new DialogViewModel("Confirm dialog", CreateConfirmDialog);
            ConfirmSequenceDialog = new DialogViewModel("Confirm dialog sequence", CreateConfirmSequenceDialog);
            ImageDialog = new DialogViewModel("Image dialog", CreateImageDialog);
            LoginDialog = new DialogViewModel("Login dialog", CreateLoginDialog);
            FolderNameDialog = new DialogViewModel("Create folder name dialog", CreateFolderNameDialog);
            CustomDialog = new DialogViewModel("Custom dialog", CreateCustomDialog);
        }




        private async IAsyncEnumerable<string> CreateInfoDialog()
        {
            var dialog = DialogHelper.CreateAlertDialog(new AlertDialogBuilderParams
            {
                ContentHeader = "Welcome to Neumorphism design !",
                SupportingText = "Enjoy Neumorphism Design in AvaloniaUI !",
                WindowTitle = "Info dialog",
                DialogHeaderIcon = DialogIconKind.Info,
                DialogIcon = DialogIconKind.Info,
                StartupLocation = WindowStartupLocation.CenterOwner,
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
                RightDialogButtons = new[]
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
                RightDialogButtons = new[]
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


        private async IAsyncEnumerable<string> CreateCustomDialog()
        {
            var dialog = CustomDialogHelper.CreateCustomDialog(new SampleCustomDialogBuilderParams
            {
                ContentHeader = "Welcome to this custom dialog !",
                SupportingText = "Following content is coming from a custom template...",
                WindowTitle = "Info dialog",
                DialogHeaderIcon = DialogIconKind.Info,
                DialogIcon = DialogIconKind.Info,
                //Content = _window.Resources["TestCustomWindow"],
                ContentTemplate = _window.Resources["TestCustomWindow"] as DataTemplate,
                Width = 880,
                Borderless = true,
                CenterDialogButtons = new[]
                {
                    new DialogButton
                    {
                        Content = "OK",
                        Result = "ok"
                    }
                }
            });



            _appModelBase.IsDialogOpened = true;

            var result = await dialog.ShowDialog(_window);

            _appModelBase.IsDialogOpened = false;

            yield return $"Result: {result.GetResult}";
        }


    }
}