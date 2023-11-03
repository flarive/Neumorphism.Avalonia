using Avalonia.Controls.Templates;
using Avalonia.Themes.Neumorphism.Dialogs.Bases;

namespace Avalonia.Themes.Neumorphism.Dialogs
{
    public sealed class CustomDialogBuilderParams : DialogWindowBuilderParamsBase
    {
        public object Content = null;
        public IDataTemplate ContentTemplate = null;
    }
}