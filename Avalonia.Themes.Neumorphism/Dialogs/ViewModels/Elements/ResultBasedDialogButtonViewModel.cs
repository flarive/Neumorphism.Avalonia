using Avalonia.Themes.Neumorphism.Dialogs.Commands;

namespace Avalonia.Themes.Neumorphism.Dialogs.ViewModels.Elements
{
    public class ResultBasedDialogButtonViewModel : DialogButtonViewModel
    {
        public ResultBasedDialogButtonViewModel(DialogWindowViewModel parent, object content, string result)
            : base(parent, content)
        {
            _result = result;
            Command = new MaterialDialogRelayCommand(OnExecuteCommandHandler, CanExecuteCommandHandler);
        }

        private bool CanExecuteCommandHandler(object arg)
        {
            return true;
        }

        private void OnExecuteCommandHandler(object obj)
        {
            if (Parent is null)
                return;

            if (obj is ResultBasedDialogButtonViewModel vm)
            {
                Parent.DialogResult = new DialogResult(vm.Result);
            }

            Parent.CloseWindow();
        }

        private string _result;

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }
    }
}