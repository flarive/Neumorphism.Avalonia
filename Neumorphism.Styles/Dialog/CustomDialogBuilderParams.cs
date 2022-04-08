using Avalonia.Controls.Templates;
using Neumorphism.Styles.Dialog.Bases;

namespace Neumorphism.Styles.Dialog
{
    public class CustomDialogBuilderParams : DialogWindowBuilderParamsBase
    {
        public object Content = null;
        public IDataTemplate ContentTemplate = null;
    }
}