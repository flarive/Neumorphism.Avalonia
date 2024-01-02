using Avalonia.Themes.Neumorphism.Dialogs.Enums;

namespace Avalonia.Themes.Neumorphism.Dialogs
{
    public sealed class DialogButton
    {
        public string Result = "None";
        public object Content = "Action";
        public bool IsPositive = false;
        public bool IsNegative = false;

        public DialogButtonStyle DialogButtonStyle;

        public DialogButton()
        {
            DialogButtonStyle = new DialogButtonStyle(DialogButtonBackgroundColor.Default, DialogButtonForegroundColor.Default);
        }
    }
}