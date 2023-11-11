using Avalonia.Themes.Neumorphism.Dialogs.ViewModels;
using Neumorphism.Avalonia.Demo.Windows.Dialogs;

namespace Neumorphism.Avalonia.Demo.Windows.ViewModels.Dialogs
{
    public sealed class SampleCustomDialogViewModel : DialogWindowViewModel
    {
        private int? _number = 0;
        public int? Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        public SampleCustomDialogViewModel(SampleCustomDialog dialog) : base(dialog)
        {
        }
    }
}