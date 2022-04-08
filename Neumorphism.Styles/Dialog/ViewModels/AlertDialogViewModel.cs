using Neumorphism.Styles.Dialog.Views;

namespace Neumorphism.Styles.Dialog.ViewModels
{
    public class AlertDialogViewModel : DialogWindowViewModel
    {
        public AlertDialogViewModel(AlertDialog dialog)
        {
            _window = dialog;
        }
    }
}
