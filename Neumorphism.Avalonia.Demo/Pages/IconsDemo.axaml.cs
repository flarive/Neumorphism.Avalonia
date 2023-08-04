using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Themes.Neumorphism.Controls;
using Avalonia.Threading;
using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public partial class IconsDemo : UserControl
    {
        public IconsDemo()
        {
            InitializeComponent();

            DataContext = new IconsDemoViewModel();
        }

        private void Search_OnKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender!;
            if (e.Key == Key.Enter)
                this.Get<Button>("SearchButton").Command.Execute(textBox.Text);
        }

        private void TextBox_OnGotFocus(object sender, GotFocusEventArgs e)
        {
            var textBox = (TextBox)sender!;
            Dispatcher.UIThread.Post(textBox.SelectAll);
        }

        private void CopyToClipboardAsync(object sender, RoutedEventArgs args)
        {
            Button button = sender as Button;
            
            var topLevel = TopLevel.GetTopLevel(sender as Control);
            if (topLevel != null && topLevel.Clipboard != null && !string.IsNullOrEmpty(button.Tag?.ToString()))
            {
                topLevel.Clipboard.SetTextAsync(button.Tag.ToString());

                SnackbarHost.Post("Added to clipboard !");
            }
        }
    }
}