using Avalonia.Data;
using System;

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



        private TimeSpan? _currentTime;
        public TimeSpan? CurrentTime
        {
            get { return _currentTime; }
            set
            {
                if (value.HasValue)
                {
                    if (value < new TimeSpan(12, 0, 0))
                    {
                        _currentTime = value;
                        OnPropertyChanged(nameof(CurrentTime));
                    }
                    else
                    {
                        throw new DataValidationException("Invalid time !");
                    }
                }
            }
        }
    }
}