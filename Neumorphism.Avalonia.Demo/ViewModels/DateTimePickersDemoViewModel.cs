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
                    if (value < DateTime.Today)
                    {
                        _birthDate = value;
                        OnPropertyChanged(nameof(BirthDate));
                    }
                    else
                    {
                        throw new DataValidationException("Invalid birth date !");
                    }
                }
                else
                {
                    throw new DataValidationException("This field is required");
                }
            }
        }



        private DateTime _displayBirthDate;
        public DateTime DisplayBirthDate
        {
            get { return _displayBirthDate; }
            set
            {
                _displayBirthDate = value;
                OnPropertyChanged(nameof(DisplayBirthDate));
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
                if (!string.IsNullOrWhiteSpace(value) && !Regex.IsMatch(value, @"([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))"))
                {
                    throw new DataValidationException("Invalid date");
                }

                _dates = value;
                OnPropertyChanged();
            }
        }


        public DateTimePickersDemoViewModel()
        {
            DisplayBirthDate = DateTime.Today;
        }
    }
}
