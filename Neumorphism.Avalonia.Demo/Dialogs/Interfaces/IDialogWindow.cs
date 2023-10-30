using System.Threading.Tasks;
using Avalonia.Controls;

namespace Neumorphism.Avalonia.Demo.Dialogs.Interfaces
{
    public interface IDialogWindow<T>
    {
        Window GetWindow();

        Task<T> ShowDialog(Window ownerWindow);
        Task<T> Show();
        Task<T> Show(Window window);
    }
}