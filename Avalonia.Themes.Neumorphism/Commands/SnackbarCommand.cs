﻿using Avalonia.Themes.Neumorphism.Controls;
using Avalonia.Themes.Neumorphism.Models;
using System;
using System.Windows.Input;

namespace Avalonia.Themes.Neumorphism.Commands
{
    /// <summary>
    /// This class used for snackbar button. 
    /// </summary>
    internal class SnackbarCommand : ICommand
    {
        private readonly SnackbarHost _host;
        private readonly SnackbarModel _model;
        
        public SnackbarCommand(SnackbarHost host, SnackbarModel model)
        {
            _host = host;
            _model = model;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            try
            {
                _model.Button?.Action?.Invoke(parameter);
                _host.SnackbarModels.Remove(_model);
            }
            catch
            {
                // ignored
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}