using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Themes.Neumorphism.Dialogs.Enums;

namespace Avalonia.Themes.Neumorphism.Dialogs.Bases
{
    public class DialogWindowBuilderParamsBase
    {
        public string WindowTitle = "Warning";
        public double? MaxWidth = null;
        public double? Width = null;
        public string ContentHeader = null;
        public string SupportingText = null;
        public bool Borderless = false;
        public WindowStartupLocation StartupLocation = WindowStartupLocation.CenterScreen;

        /// <summary>
        /// Specify kind of internal dialog icon. <br/>
        /// This property will not applied if <see cref="DialogIcon"/> had value already.
        /// </summary>
        public DialogIconKind? DialogHeaderIcon = null;

        // TODO: Support custom control
        /// <summary>
        /// Specify <see cref="Avalonia.Media.Imaging.Bitmap"/>, <see cref="Avalonia.Controls.Control"/> or <see cref="DialogIconKind"/> for dialog header icon.
        /// </summary>
        public object DialogIcon = null;

        /// <summary>
        /// Build dialog buttons stack (left side). 
        /// <br/>You can use <seealso cref="DialogHelper.CreateSimpleDialogButtons(Enums.DialogButtonsEnum)"/> for create buttons stack in easy way.
        /// </summary>
        public DialogButton[] LeftDialogButtons;

        /// <summary>
        /// Build dialog buttons stack (middle).
        /// <br/>You can use <seealso cref="DialogHelper.CreateSimpleDialogButtons(Enums.DialogButtonsEnum)"/> for create buttons stack in easy way.
        /// </summary>
        public DialogButton[] CenterDialogButtons;

        /// <summary>
        /// Build dialog buttons stack (right side).
        /// <br/>You can use <seealso cref="DialogHelper.CreateSimpleDialogButtons(Enums.DialogButtonsEnum)"/> for create buttons stack in easy way.
        /// </summary>
        public DialogButton[] RightDialogButtons;

        /// <summary>
        /// Define result after close the dialog not from buttons
        /// <br/> (could be from Alt + F4 or window close button).
        /// </summary>
        public DialogResult NegativeResult = DialogResult.NoResult;

        /// <summary>
        /// Define buttons stack orientation.
        /// </summary>
        public Orientation ButtonsOrientation = Orientation.Horizontal;
    }
}