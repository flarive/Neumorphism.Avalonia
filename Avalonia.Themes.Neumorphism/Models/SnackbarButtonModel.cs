﻿using System;

namespace Avalonia.Themes.Neumorphism.Models
{
    public sealed class SnackbarButtonModel
    {
        public string Text { get; set; } = string.Empty;
        public Action Action { get; set; }

        public SnackbarButtonModel()
        {

        }

        public SnackbarButtonModel(string text, Action action)
        {
            Text = text;
            Action = action;
        }

        public override string ToString() => Text;
    }
}