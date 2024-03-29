﻿using System.Windows.Input;

namespace Avalonia.Themes.Neumorphism.Dialogs.ViewModels.Elements
{
    public class DialogButtonViewModel : DialogViewModelBase
    {
        private readonly DialogWindowViewModel _parent;

        public DialogWindowViewModel Parent => _parent;


        public DialogButtonViewModel(DialogWindowViewModel parent, object content)
        {
            _parent = parent;
            _content = content;
        }

        public DialogButtonViewModel(DialogWindowViewModel parent, object content, ICommand command)
        {
            _parent = parent;
            _content = content;
            _command = command;
        }



        


        private bool _isPositiveButton;

        public bool IsPositiveButton
        {
            get => _isPositiveButton;
            set
            {
                _isPositiveButton = value;
                OnPropertyChanged();
            }
        }

        private object _content;

        public object Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        private ICommand _command;

        public ICommand Command
        {
            get => _command;
            set
            {
                _command = value;
                OnPropertyChanged();
            }
        }

        private DialogButtonStyle _dialogButtonStyle;

        public DialogButtonStyle DialogButtonStyle
        {
            get => _dialogButtonStyle;
            set
            {
                _dialogButtonStyle = value;
                OnPropertyChanged();
            }
        }
    }
}