using System.Threading.Tasks;
using Avalonia.Controls;

namespace Avalonia.Themes.Neumorphism.Dialogs.Interfaces
{
    public interface IDialogWindow<T>
    {
        Window GetWindow();

        Task<T> ShowDialog(Window ownerWindow);
        Task<T> Show();
        Task<T> Show(Window window);
    }
}