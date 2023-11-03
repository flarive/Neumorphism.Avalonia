using Avalonia.Themes.Neumorphism.Dialogs.Enums;

namespace Avalonia.Themes.Neumorphism.Dialogs.ViewModels.Elements.Header.Icons
{
    public sealed class DialogIconViewModel : IconViewModelBase
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