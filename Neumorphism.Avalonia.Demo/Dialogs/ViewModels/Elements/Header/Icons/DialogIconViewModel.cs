using Neumorphism.Avalonia.Demo.Dialogs.Icons;

namespace Neumorphism.Avalonia.Demo.Dialogs.ViewModels.Elements.Header.Icons
{
    public class DialogIconViewModel : IconViewModelBase
    {
        private DialogIconKind _kind;

        public DialogIconKind Kind
        {
            get => _kind;
            set
            {
                _kind = value;
                OnPropertyChanged();
            }
        }
    }
}