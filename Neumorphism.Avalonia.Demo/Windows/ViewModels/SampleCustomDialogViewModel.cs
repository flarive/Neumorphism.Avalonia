using Avalonia.Controls.Templates;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels;

namespace Neumorphism.Avalonia.Demo.Windows.ViewModels
{
    public sealed class SampleCustomDialogViewModel : DialogWindowViewModel
    {
        private object _content;

        public object Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        private IDataTemplate _contentTemplate;

        public IDataTemplate ContentTemplate
        {
            get => _contentTemplate;
            set
            {
                _contentTemplate = value;
                OnPropertyChanged();
            }
        }

        public SampleCustomDialogViewModel(SampleCustomDialog dialog) : base(dialog)
        {
        }
    }
}