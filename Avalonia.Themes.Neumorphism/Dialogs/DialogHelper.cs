using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Themes.Neumorphism.Dialogs.Bases;
using Avalonia.Themes.Neumorphism.Dialogs.Enums;
using Avalonia.Themes.Neumorphism.Dialogs.Interfaces;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels.Elements;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels.Elements.Header.Icons;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels.Elements.TextField;
using Avalonia.Themes.Neumorphism.Dialogs.Views;

namespace Avalonia.Themes.Neumorphism.Dialogs
{
    public class DialogHelper
    {
        public const string DIALOG_RESULT_OK = "ok";
        public const string DIALOG_RESULT_CANCEL = "cancel";
        public const string DIALOG_RESULT_YES = "yes";
        public const string DIALOG_RESULT_NO = "no";
        public const string DIALOG_RESULT_ABORT = "abort";

        private static bool _disableTransitions;

        public static bool DisableTransitions
        {
            get => _disableTransitions;
            set => _disableTransitions = value;
        }

        /// <summary>
        /// Create some dialog buttons for use.
        /// </summary>
        /// <param name="cases">Which dialog buttons group case you need.</param> 
        public static DialogButton[] CreateSimpleDialogButtons(DialogButtons cases)
        {
            switch (cases)
            {
                default:
                case DialogButtons.Ok:
                    return new[]
                    {
                        new DialogButton {Result = DIALOG_RESULT_OK, Content = "OK"}
                    };
                case DialogButtons.OkAbort:
                    return new[]
                    {
                        new DialogButton {Result = DIALOG_RESULT_ABORT, Content = "ABORT"},
                        new DialogButton {Result = DIALOG_RESULT_OK, Content = "OK"}
                    };
                case DialogButtons.OkCancel:
                    return new[]
                    {
                        new DialogButton {Result = DIALOG_RESULT_CANCEL, Content = "CANCEL"},
                        new DialogButton {Result = DIALOG_RESULT_OK, Content = "OK"}
                    };
                case DialogButtons.YesNo:
                    return new[]
                    {
                        new DialogButton {Result = DIALOG_RESULT_NO, Content = "NO"},
                        new DialogButton {Result = DIALOG_RESULT_YES, Content = "YES"}
                    };
                case DialogButtons.YesNoAbort:
                    return new[]
                    {
                        new DialogButton {Result = DIALOG_RESULT_ABORT, Content = "ABORT"},
                        new DialogButton {Result = DIALOG_RESULT_NO, Content = "NO"},
                        new DialogButton {Result = DIALOG_RESULT_YES, Content = "YES"}
                    };
                case DialogButtons.YesNoCancel:
                    return new[]
                    {
                        new DialogButton {Result = DIALOG_RESULT_CANCEL, Content = "CANCEL"},
                        new DialogButton {Result = DIALOG_RESULT_NO, Content = "NO"},
                        new DialogButton {Result = DIALOG_RESULT_YES, Content = "YES"}
                    };
            }
        }

        /// <summary>
        /// Most common dialog template containing a title with an icon and a subtitle, then the custom content
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        public static IDialogWindow<DialogResult> CreateCommonDialog(CommonDialogBuilderParams @params)
        {
            var window = new CommonDialog();
            var context = new CommonDialogViewModel(window);

            ApplyBaseParams(context, @params);

            if ((@params.LeftDialogButtons == null || @params.LeftDialogButtons.Length == 0)
                && (@params.CenterDialogButtons == null || @params.CenterDialogButtons.Length == 0)
                && (@params.RightDialogButtons == null || @params.RightDialogButtons.Length == 0))
            {
                context.CenterDialogButtons = new ObservableCollection<DialogButtonViewModel>(
                    CreateObsoleteButtonArray(context, CreateSimpleDialogButtons(DialogButtons.Ok)));
            }


            window.DataContext = context;
            SetupWindowParameters(window, @params);
            return new DialogWindowBase<CommonDialog, DialogResult>(window);
        }

        /// <summary>
        /// Dialog template for info, alert, error dialogs with a big icon, a title, a subtitle then the content
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        public static IDialogWindow<DialogResult> CreateAlertDialog(AlertDialogBuilderParams @params)
        {
            var window = new AlertDialog();
            var context = new AlertDialogViewModel(window);

            ApplyBaseParams(context, @params);

            if ((@params.LeftDialogButtons == null || @params.LeftDialogButtons.Length == 0) 
                && (@params.CenterDialogButtons == null || @params.CenterDialogButtons.Length == 0)
                && (@params.RightDialogButtons == null || @params.RightDialogButtons.Length == 0))
            {
                context.CenterDialogButtons = new ObservableCollection<DialogButtonViewModel>(
                    CreateObsoleteButtonArray(context, CreateSimpleDialogButtons(DialogButtons.Ok)));
            }


            window.DataContext = context;
            SetupWindowParameters(window, @params);
            return new DialogWindowBase<AlertDialog, DialogResult>(window);
        }

        /// <summary>
        /// Dialog template for textboxes based dialogs
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        public static IDialogWindow<TextFieldDialogResult> CreateTextFieldDialog(TextFieldDialogBuilderParams @params)
        {
            var window = new TextFieldDialog();
            var context = new TextFieldDialogViewModel(window);

            context.TextFields = new ObservableCollection<TextFieldViewModel>(TextFieldsBuilder(context, @params.TextFields));

            ApplyBaseParams(context, @params);

            var positiveButtonApplied = false;
            var buttons = CreateObsoleteButtonArray(context, @params.RightDialogButtons);

            foreach (var button in buttons)
            {
                if (!button.IsPositiveButton)
                    continue;

                button.Command = context.SubmitCommand;
                positiveButtonApplied = true;
            }

            context.RightDialogButtons = new ObservableCollection<DialogButtonViewModel>(buttons);

            // TODO: Remove compatibility API with PositiveButton and NegativeButton on future update.
            if (!positiveButtonApplied)
            {
                var positiveButton = @params.PositiveButton;
                if (positiveButton != null)
                {
                    context.RightDialogButtons.Add(
                        new ResultBasedDialogButtonViewModel(context, positiveButton.Content, positiveButton.Result)
                        {
                            Command = context.SubmitCommand
                        });
                }
            }

            context.BindValidateHandler();
            window.DataContext = context;
            SetupWindowParameters(window, @params);
            return new DialogWindowBase<TextFieldDialog, TextFieldDialogResult>(window);
        }

        public static void ApplyBaseParams<T>(T input, DialogWindowBuilderParamsBase @params)
            where T : DialogWindowViewModel
        {
            input.MaxWidth = @params.MaxWidth;
            input.WindowTitle = @params.WindowTitle;
            input.Width = @params.Width;
            input.ContentHeader = @params.ContentHeader;
            input.ContentMessage = @params.SupportingText;
            input.Borderless = @params.Borderless;
            input.ShowInTaskbar = @params.ShowInTaskbar;
            input.WindowStartupLocation = @params.StartupLocation;
            input.DialogShadowKind = (int)@params.ShadowKind;

            switch (@params.DialogIcon)
            {
                case Bitmap bitmap:
                {
                    input.DialogIcon = new ImageIconViewModel
                    {
                        Bitmap = bitmap
                    };
                }
                    break;

                case Image _:
                    throw new ArgumentException("Do not wrap Bitmap object with Image control for now.");

                case Control _:
                    throw new ArgumentException("Custom view icon feature is currently unavailable.");

                case DialogIconKind kind:
                {
                    if (@params.DialogHeaderIcon != null)
                    {
                        input.DialogIcon = new DialogIconViewModel
                        {
                            Kind = kind
                        };
                    }
                }
                    break;

                case null:
                    break;

                default:
                    throw new ArgumentException($"{@params.DialogIcon.GetType()} is a unknown or unsupported type.");
            }

            // Rollback API Compatibility
            if (@params.DialogHeaderIcon != null)
            {
                if (input.DialogIcon == null && @params.DialogHeaderIcon != null)
                {
                    input.DialogIcon = new DialogIconViewModel
                    {
                        Kind = @params.DialogHeaderIcon.Value
                    };
                }
            }

            if (@params.RightDialogButtons != null)
                input.RightDialogButtons =
                    new ObservableCollection<DialogButtonViewModel>(
                        CreateObsoleteButtonArray(input, @params.RightDialogButtons));

            if (@params.CenterDialogButtons != null)
                input.CenterDialogButtons =
                    new ObservableCollection<DialogButtonViewModel>(
                        CreateObsoleteButtonArray(input, @params.CenterDialogButtons));

            if (@params.LeftDialogButtons != null)
                input.LeftDialogButtons =
                    new ObservableCollection<DialogButtonViewModel>(
                        CreateObsoleteButtonArray(input, @params.LeftDialogButtons));

            input.ButtonsStackOrientation = @params.ButtonsOrientation;
        }

        public static void SetupWindowParameters(Window window, DialogWindowBuilderParamsBase @params)
        {
            window.SystemDecorations = @params.Borderless ? SystemDecorations.None : SystemDecorations.Full;
            window.ShowInTaskbar = @params.ShowInTaskbar;
            (window as IHasNegativeResult)?.SetNegativeResult(@params.NegativeResult);
        }

        private static DialogButtonViewModel[] CreateObsoleteButtonArray(DialogWindowViewModel parent, params DialogButton[] buttons)
        {
            var len = buttons.Length;
            var result = new DialogButtonViewModel[buttons.Length];

            for (var i = 0; i < len; i++)
            {
                var button = buttons[i];

                if (button is null)
                    continue;


                result[i] = new ResultBasedDialogButtonViewModel(parent, button.Content, button.Result)
                {
                    IsPositiveButton = button.IsPositive,
                    DialogButtonStyle = button.DialogButtonStyle
                };
            }

            return result;
        }

        private static TextFieldViewModel[] TextFieldsBuilder(TextFieldDialogViewModel parent, params TextFieldBuilderParams[] @params)
        {
            var len = @params.Length;
            var result = new TextFieldViewModel[len];
            for (var i = 0; i < len; i++)
            {
                var param = @params[i];

                try
                {
                    var model = new TextFieldViewModel(parent, param.DefaultText, param.Validator)
                    {
                        // but... I implemented an setter to TextFieldDialog for apply classes when showing dialog.
                        // Currently AvaloniaUI are not supported to binding classes.
                        Classes = param.Classes,
                        PlaceholderText = param.PlaceholderText,
                        MaxCountChars = param.MaxCountChars,
                        Label = param.Label,
                        AssistiveText = param.HelperText
                    };

                    switch (param.FieldKind)
                    {
                        case TextFieldKind.Masked:
                            model.MaskChar = param.MaskChar;
                            model.Classes += " revealPasswordButton";
                            break;
                        case TextFieldKind.WithClear:
                            model.Classes += " clearButton";
                            break;
                        case TextFieldKind.Normal:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    result[i] = model;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    // ignored
                }
            }

            return result;
        }
    }
}