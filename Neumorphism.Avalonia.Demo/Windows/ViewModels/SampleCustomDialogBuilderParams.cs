using Avalonia.Controls.Templates;
using Avalonia.Themes.Neumorphism.Dialogs.Bases;

namespace Neumorphism.Avalonia.Demo.Windows.ViewModels
{
    public sealed class SampleCustomDialogBuilderParams : DialogWindowBuilderParamsBase
    {
        public object Content = null;
        public IDataTemplate ContentTemplate = null;
    }
}