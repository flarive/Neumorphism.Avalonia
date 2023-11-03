using System;
using Avalonia.Themes.Neumorphism.Dialogs.Enums;

namespace Avalonia.Themes.Neumorphism.Dialogs.Bases
{
    [Obsolete("Deprecated builder params.")]
    public class TwoFeedbackDialogBuilderParamsBase : DialogWindowBuilderParamsBase
    {
        /// <summary>
        /// Define a positive action button.
        /// </summary>
        [Obsolete(
            "Please use DialogButton.IsPositive instead. This API will be deprecated and removed on future updates.")]
        public DialogButton PositiveButton = DialogHelper.CreateSimpleDialogButtons(DialogButtonsEnum.Ok)[0];

        /// <summary>
        /// Define a negative action button.
        /// </summary>
        [Obsolete(
            "Please use DialogButton.IsPositive instead. This API will be deprecated and removed on future updates.")]
        public DialogButton NegativeButton =
            DialogHelper.CreateSimpleDialogButtons(DialogButtonsEnum.OkCancel)[0];
    }
}