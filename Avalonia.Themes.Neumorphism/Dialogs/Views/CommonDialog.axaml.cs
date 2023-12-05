using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Themes.Neumorphism.Dialogs.Interfaces;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels;

namespace Avalonia.Themes.Neumorphism.Dialogs.Views
{
    public partial class CommonDialog : Window, IDialogWindowResult<DialogResult>, IHasNegativeResult
    {
        public CommonDialog()
        {
            InitializeComponent();

            RenderOptions.SetBitmapInterpolationMode(this, BitmapInterpolationMode.HighQuality);
        }

        public DialogResult GetResult() => (DataContext as CommonDialogViewModel)?.DialogResult;

        public void SetNegativeResult(DialogResult result)
        {
            if (DataContext is CommonDialogViewModel viewModel)
                viewModel.DialogResult = result;
        }
    }
}
