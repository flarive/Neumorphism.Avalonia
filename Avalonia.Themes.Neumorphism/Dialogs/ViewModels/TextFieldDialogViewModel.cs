﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Themes.Neumorphism.Dialogs.Commands;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels.Elements;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels.Elements.TextField;
using Avalonia.Themes.Neumorphism.Dialogs.Views;
using Avalonia.Threading;

namespace Avalonia.Themes.Neumorphism.Dialogs.ViewModels
{
    public sealed class TextFieldDialogViewModel : DialogWindowViewModel
    {
        private ObservableCollection<TextFieldViewModel> _textFields;

        public ObservableCollection<TextFieldViewModel> TextFields
        {
            get => _textFields;
            internal set
            {
                _textFields = value;
                OnPropertyChanged();
            }
        }

        /*private DialogResultButton _positiveButton;

        public DialogResultButton PositiveButton
        {
            get => _positiveButton;
            internal set => _positiveButton = value;
        }

        private DialogResultButton _negativeButton;

        public DialogResultButton NegativeButton
        {
            get => _negativeButton;
            internal set => _negativeButton = value;
        }*/

        public TextFieldDialogViewModel(TextFieldDialog dialog) : base(dialog)
        {
            SubmitCommand = new MaterialDialogRelayCommand(OnPressButton, CanPressButton);
        }

        public void BindValidateHandler()
        {
            foreach (var item in TextFields)
            {
                if (item != null)
                    item.OnValidateRequired += Field_OnValidateRequired;
            }
        }

        public void UnbindValidateHandler()
        {
            foreach (var item in TextFields)
            {
                if (item != null)
                    item.OnValidateRequired -= Field_OnValidateRequired;
            }
        }

        public bool ValidateFields()
        {
            foreach (var field in TextFields)
            {
                if (!field.IsValid)
                    return false;
            }

            return true;
        }

        private void Field_OnValidateRequired(object sender, bool e)
        {
            SubmitCommand.RaiseCanExecute();
        }

        public MaterialDialogRelayCommand SubmitCommand { get; }

        private bool CanPressButton(object args)
        {
            return ValidateFields();
        }

        private async void OnPressButton(object args)
        {
            if (!(args is DialogButtonViewModel button))
                return;

            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                var resultButtonId = "submit";
                if (args is ResultBasedDialogButtonViewModel vm)
                    resultButtonId = vm.Result;

                var result = new TextFieldDialogResult
                {
                    result = resultButtonId
                };

                var fields = new List<TextFieldResult>();

                foreach (var item in TextFields)
                    fields.Add(new TextFieldResult {Text = item.Text});

                result.fieldsResult = fields.ToArray();
                button.Parent.DialogResult = result;

                Window.Close();
                UnbindValidateHandler();
            });
        }
    }
}