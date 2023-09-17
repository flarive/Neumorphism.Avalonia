using Avalonia.Data;
using System.Text.RegularExpressions;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public class DateTimePickersDemoViewModel : ViewModelBase
    {
        private string _dates;
        public string Dates
        {
            get => _dates;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && !Regex.IsMatch(value, @"^\d+([A-Za-z-+.']\d+)*$"))
                {
                    throw new DataValidationException("Invalid date");
                }

                _dates = value;
                OnPropertyChanged();
            }
        }
    }
}
