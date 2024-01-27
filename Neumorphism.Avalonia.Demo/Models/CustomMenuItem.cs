using Avalonia.Themes.Neumorphism.Models;
using Material.Icons.Avalonia;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Neumorphism.Avalonia.Demo.Models
{
    public class CustomMenuItem : ModelBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private MaterialIcon _icon;
        public MaterialIcon Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        private ICommand _command;
        public ICommand Command
        {
            get { return _command; }
            set
            {
                _command = value;
                OnPropertyChanged(nameof(Command));
            }
        }

        private string _commandParameter;
        public string CommandParameter
        {
            get { return _commandParameter; }
            set
            {
                _commandParameter = value;
                OnPropertyChanged(nameof(CommandParameter));
            }
        }

        private bool _enabled = true;
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                OnPropertyChanged(nameof(Enabled));
            }
        }


        private ObservableCollection<CustomMenuItem> _items;
        public ObservableCollection<CustomMenuItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
    }
}