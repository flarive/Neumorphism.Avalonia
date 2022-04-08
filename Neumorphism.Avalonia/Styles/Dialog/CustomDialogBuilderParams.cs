using Avalonia.Controls.Templates;
using Neumorphism.Avalonia.Styles.Dialog.Bases;

namespace Neumorphism.Avalonia.Styles.Dialog
{
    public class CustomDialogBuilderParams : DialogWindowBuilderParamsBase
    {
        public object Content = null;
        public IDataTemplate ContentTemplate = null;
    }
}