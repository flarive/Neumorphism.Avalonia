using Avalonia.Themes.Neumorphism.Dialogs.Bases;

namespace Avalonia.Themes.Neumorphism.Dialogs
{
    public sealed class TextFieldDialogBuilderParams : TwoFeedbackDialogBuilderParamsBase
    {
        /// <summary>
        /// Build text fields stack.
        /// </summary>
        public TextFieldBuilderParams[] TextFields = TextFieldBuilderParams.OneRegularTextField;
        //public DialogResult NegativeResult = new DialogResult(DialogHelper.DIALOG_RESULT_CANCEL);
    }
}