using Avalonia.Data;
using System;
using System.Text.RegularExpressions;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public class DateTimePickersDemoViewModel : ViewModelBase
    {
        private DateTime? _birthDate;
        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (value.HasValue)
                {
                    if (value > DateTime.MinValue && value < DateTime.MaxValue)
                    {
                        _birthDate = value;
                        OnPropertyChanged(nameof(BirthDate));
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(BirthDate), "Invalid date !");
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(BirthDate), "This field is required");
                }
                
                
            }
        }

        private DateTime? _dateStart;
        public DateTime? DateStart
        {
            get { return _dateStart; }
            set
            {
                _dateStart = value;
                OnPropertyChanged(nameof(DateStart));
            }
        }

        private DateTime? _dateEnd;
        public DateTime? DateEnd
        {
            get { return _dateEnd; }
            set
            {
                _dateEnd = value;
                OnPropertyChanged(nameof(DateEnd));
            }
        }


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
