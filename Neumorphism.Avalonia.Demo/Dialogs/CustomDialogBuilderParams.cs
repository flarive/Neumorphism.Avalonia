using Avalonia.Controls.Templates;
using Neumorphism.Avalonia.Demo.Dialogs.Bases;

namespace Neumorphism.Avalonia.Demo.Dialogs
{
    public sealed class CustomDialogBuilderParams : DialogWindowBuilderParamsBase
    {
        public object Content = null;
        public IDataTemplate ContentTemplate = null;
    }
}