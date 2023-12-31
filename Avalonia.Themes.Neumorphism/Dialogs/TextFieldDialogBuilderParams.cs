using Avalonia.Themes.Neumorphism.Dialogs.Bases;
using Avalonia.Themes.Neumorphism.Dialogs.Enums;

namespace Avalonia.Themes.Neumorphism.Dialogs
{
    public sealed class TextFieldDialogBuilderParams : DialogWindowBuilderParamsBase
    {
        /// <summary>
        /// Build text fields stack.
        /// </summary>
        public TextFieldBuilderParams[] TextFields = TextFieldBuilderParams.OneRegularTextField;
        //public DialogResult NegativeResult = new DialogResult(DialogHelper.DIALOG_RESULT_CANCEL);

        /// <summary>
        /// Define a positive action button.
        /// </summary>
        public DialogButton PositiveButton = DialogHelper.CreateSimpleDialogButtons(DialogButtons.Ok)[0];

        /// <summary>
        /// Define a negative action button.
        /// </summary>
        public DialogButton NegativeButton = DialogHelper.CreateSimpleDialogButtons(DialogButtons.OkCancel)[0];
    }
}