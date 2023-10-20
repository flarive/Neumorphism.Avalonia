using Avalonia.Controls.Templates;
using Neumorphism.Avalonia.Demo.Dialogs.Views;

namespace Neumorphism.Avalonia.Demo.Dialogs.ViewModels
{
    public class CustomDialogViewModel : DialogWindowViewModel
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

        public CustomDialogViewModel(CustomDialog dialog) : base(dialog)
        {
        }
    }
}