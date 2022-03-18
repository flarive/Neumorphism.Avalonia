using Avalonia.Controls.Templates;
using Neumorphism.Dialog.Bases;

namespace Neumorphism.Dialog
{
    public class CustomDialogBuilderParams : DialogWindowBuilderParamsBase
    {
        public object Content = null;
        public IDataTemplate ContentTemplate = null;
    }
}