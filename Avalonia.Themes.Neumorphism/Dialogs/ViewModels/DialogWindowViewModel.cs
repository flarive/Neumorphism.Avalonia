using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels.Elements;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels.Elements.Header.Icons;
using Avalonia.Threading;

namespace Avalonia.Themes.Neumorphism.Dialogs.ViewModels
{
    public abstract class DialogWindowViewModel : DialogViewModelBase
    {
        public DialogWindowViewModel(Window window)
        {
            Window = window;
        }

        private Window _window;

        protected Window Window
        {
            get => _window;
            private set => _window = value;
        }

        #region Base Properties

        private string _windowTitle;

        public string WindowTitle
        {
            get => _windowTitle;
            set
            {
                _windowTitle = value;
                OnPropertyChanged();
            }
        }

        private string _contentHeader;

        public string ContentHeader
        {
            get => _contentHeader;
            set
            {
                _contentHeader = value;
                OnPropertyChanged();
            }
        }

        private string _contentMessage;

        public string ContentMessage
        {
            get => _contentMessage;
            set
            {
                _contentMessage = value;
                OnPropertyChanged();
            }
        }

        private bool _borderless;

        public bool Borderless
        {
            get => _borderless;
            set
            {
                _borderless = value;
                OnPropertyChanged();
            }
        }

        private double? _maxWidth;

        public double? MaxWidth
        {
            get => _maxWidth;
            set
            {
                _maxWidth = value;
                OnPropertyChanged();
            }
        }

        private double? _width;

        public double? Width
        {
            get => _width;
            set
            {
                _width = value;
                OnPropertyChanged();
            }
        }

        private WindowStartupLocation _windowStartupLocation;

        public WindowStartupLocation WindowStartupLocation
        {
            get => _windowStartupLocation;
            set
            {
                _windowStartupLocation = value;
                OnPropertyChanged();
            }
        }

        private IconViewModelBase _dialogIcon;

        public IconViewModelBase DialogIcon
        {
            get => _dialogIcon;
            set
            {
                _dialogIcon = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private ObservableCollection<DialogButtonViewModel> _leftDialogButtons;

        public ObservableCollection<DialogButtonViewModel> LeftDialogButtons
        {
            get => _leftDialogButtons;
            internal set
            {
                _leftDialogButtons = value;
                OnPropertyChanged();
            }
        }



        private ObservableCollection<DialogButtonViewModel> _centerDialogButtons;

        public ObservableCollection<DialogButtonViewModel> CenterDialogButtons
        {
            get => _centerDialogButtons;
            internal set
            {
                _centerDialogButtons = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<DialogButtonViewModel> _rightDialogButtons;

        public ObservableCollection<DialogButtonViewModel> RightDialogButtons
        {
            get => _rightDialogButtons;
            internal set
            {
                _rightDialogButtons = value;
                OnPropertyChanged();
            }
        }
       

        private Orientation _buttonsStackOrientation;

        public Orientation ButtonsStackOrientation
        {
            get => _buttonsStackOrientation;
            internal set
            {
                _buttonsStackOrientation = value;
                OnPropertyChanged();
            }
        }

        private DialogResult _dialogResult;

        public DialogResult DialogResult
        {
            get => _dialogResult;
            internal set
            {
                _dialogResult = value;
                OnPropertyChanged();
            }
        }

        public async void CloseWindow()
        {
            await Dispatcher.UIThread.InvokeAsync(() => { _window.Close(); });
        }
    }
}