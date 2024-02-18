using System;
using System.Windows.Input;

namespace Avalonia.Themes.Neumorphism.Models
{
    public class SnackbarModel
    {
        #region Properties

        protected readonly object _content;
        public object Content => _content;

        protected SnackbarButtonModel _button;
        public SnackbarButtonModel Button
        {
            get { return _button; }
            set { _button = value; }
        }

        // Setting duration to TimeSpan.Zero, will make it stay forever/til you manually delete it 
        protected readonly TimeSpan _duration = TimeSpan.FromSeconds(5);
        public TimeSpan Duration => _duration;

        private double _width = 600;
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private double _height = 100;
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private bool _isAnimated;
        public bool IsAnimated
        {
            get { return _isAnimated; }
            set { _isAnimated = value; }
        }

        #endregion


        #region Commands

        private ICommand _buttonCommand;
        public ICommand Command
        {
            get => _buttonCommand;
            internal set => _buttonCommand = value;
        }

        #endregion


        public SnackbarModel()
        {
        }


        public SnackbarModel(object content)
        {
            _content = content;
        }

        public SnackbarModel(object content, double width, double height)
        {
            _content = content;
            _width = width;
            _height = height;
        }

        public SnackbarModel(object content, double width, double height, TimeSpan? duration) :
            this(content, duration)
        {
            _width = width;
            _height = height;
        }

        public SnackbarModel(object content, TimeSpan? duration) :
            this(content)
        {
            if (duration.HasValue)
                _duration = duration.Value;
        }

        public SnackbarModel(object content, TimeSpan? duration, SnackbarButtonModel button) :
            this(content, duration)
        {
            _button = button;
        }

        public SnackbarModel(object content, double width, double height, TimeSpan? duration, SnackbarButtonModel button) :
            this(content, width, height, duration)
        {
            _button = button;
        }
    }
}