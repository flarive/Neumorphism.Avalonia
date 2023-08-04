using Neumorphism.Avalonia.Demo.ViewModels;

namespace Neumorphism.Avalonia.Demo.Models
{
    public sealed class SystemDetail : ViewModelBase
    {
        private string _key;
        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
                OnPropertyChanged("Key");
            }
        }

        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }


        public SystemDetail(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
