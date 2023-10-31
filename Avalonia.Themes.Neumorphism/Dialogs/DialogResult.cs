using Avalonia.Themes.Neumorphism.Dialogs.Interfaces;

namespace Avalonia.Themes.Neumorphism.Dialogs
{
    public class DialogResult : IDialogResult
    {
        /// <summary>
        /// Constant none result.
        /// </summary>
        public static DialogResult NoResult { get; private set; } = new DialogResult { result = "none" };


        public DialogResult()
        {
        }

        public DialogResult(string result)
        {
            this.result = result;
        }


        private string result;
        public virtual string GetResult => result;
    }
}