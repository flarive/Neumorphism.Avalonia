namespace Avalonia.Themes.Neumorphism.Dialogs
{
    public sealed class TextFieldDialogResult : DialogResult
    {
        public TextFieldDialogResult()
        {
        }

        public TextFieldDialogResult(string result, TextFieldResult[] fieldsResult)
        {
            this.result = result;
            this.fieldsResult = fieldsResult;
        }

        internal string result;
        public new string GetResult => result;

        internal TextFieldResult[] fieldsResult;
        public TextFieldResult[] GetFieldsResult() => fieldsResult;
    }
}