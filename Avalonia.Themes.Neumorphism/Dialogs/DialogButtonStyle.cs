using Avalonia.Themes.Neumorphism.Dialogs.Enums;

namespace Avalonia.Themes.Neumorphism.Dialogs
{
    public class DialogButtonStyle
    {
        private DialogButtonBackgroundColor _backgroundButtonColor = DialogButtonBackgroundColor.Default;

        public DialogButtonBackgroundColor BackgroundButtonColor
        {
            get { return _backgroundButtonColor; }
            set { _backgroundButtonColor = value; }
        }

        private DialogButtonForegroundColor _foregroundButtonColor = DialogButtonForegroundColor.Default;

        public DialogButtonForegroundColor ForegroundButtonColor
        {
            get { return _foregroundButtonColor; }
            set { _foregroundButtonColor = value; }
        }



        public DialogButtonStyle(DialogButtonBackgroundColor backgroundColor, DialogButtonForegroundColor foregroundColor)
        {
            BackgroundButtonColor = backgroundColor;
            ForegroundButtonColor = foregroundColor;
        }
    }
}