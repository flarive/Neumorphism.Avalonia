using Neumorphism.Dialog.Views;

namespace Neumorphism.Dialog.ViewModels
{
    public class AlertDialogViewModel : DialogWindowViewModel
    {
        public AlertDialogViewModel(AlertDialog dialog)
        {
            _window = dialog;
        }
    }
}
