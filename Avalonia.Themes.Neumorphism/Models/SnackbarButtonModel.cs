using System;

namespace Avalonia.Themes.Neumorphism.Models
{
    public sealed class SnackbarButtonModel
    {
        public string Text { get; set; } = string.Empty;
        public Action Action { get; set; }

        public override string ToString() => Text;
    }
}