using Avalonia.Themes.Neumorphism.Models;
using System.Collections.ObjectModel;

namespace Neumorphism.Avalonia.Demo.Models
{
    public class CustomListItem : ModelBase
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

        private string _icon;
        public string Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
    }
}