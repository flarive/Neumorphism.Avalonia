using Avalonia.Data;
using Neumorphism.Avalonia.Demo.Models;
using System;
using System.Globalization;
using System.Threading;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public class DateTimePickersDemoViewModel : ViewModelBase
    {
        private TestCultureEnum _selectedCulture;
        public TestCultureEnum SelectedCulture
        {
            get { return _selectedCulture; }
            set
            {
                _selectedCulture = value;

                if (SelectedCulture == TestCultureEnum.System)
                {
                    // OS current culture
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InstalledUICulture;
                }
                else if (SelectedCulture == TestCultureEnum.English)
                {
                    // english USA
                    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                }
                else if (SelectedCulture == TestCultureEnum.French)
                {
                    CultureInfo c = (CultureInfo)CultureInfo.GetCultureInfo("fr-FR").Clone();
                    c.DateTimeFormat.AMDesignator = "AM";
                    c.DateTimeFormat.PMDesignator = "PM";

                    // french France
                    Thread.CurrentThread.CurrentCulture = c;
                }
                else if (SelectedCulture == TestCultureEnum.Invariant)
                {
                    // invariant culture
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                }

                OnPropertyChanged(nameof(SelectedCulture));
                OnPropertyChanged(nameof(CurrentCultureName));

                ForceDateBindingsRefresh();
                ForceTimeBindingsRefresh();
            }
        }


        public string CurrentCultureName
        {
            get
            {
                return CultureInfo.CurrentCulture.Name;
            }
        }


        #region date

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
                        throw new DataValidationException("Invalid birth date");
                    }
                }
            }
        }

        private DateTime? _testDate1;
        public DateTime? TestDate1
        {
            get { return _testDate1; }
            set
            {
                _testDate1 = value;
                OnPropertyChanged(nameof(TestDate1));
            }
        }

        private DateTime? _testDate2;
        public DateTime? TestDate2
        {
            get { return _testDate2; }
            set
            {
                _testDate2 = value;
                OnPropertyChanged(nameof(TestDate2));
            }
        }



        private DateTime? _holidaysDateStart;
        public DateTime? HolidaysDateStart
        {
            get { return _holidaysDateStart; }
            set
            {
                if (value.HasValue)
                {
                    if (!HolidaysDateEnd.HasValue || (HolidaysDateEnd.HasValue && value < HolidaysDateEnd.Value))
                    {
                        _holidaysDateStart = value;
                        OnPropertyChanged(nameof(HolidaysDateStart));
                    }
                    else
                    {
                        throw new DataValidationException("Invalid start date");
                    }
                }
            }
        }

        private DateTime? _holidaysDateEnd;
        public DateTime? HolidaysDateEnd
        {
            get { return _holidaysDateEnd; }
            set
            {
                if (value.HasValue)
                {
                    if (!HolidaysDateStart.HasValue || (HolidaysDateStart.HasValue && value > HolidaysDateStart.Value))
                    {
                        _holidaysDateEnd = value;
                        OnPropertyChanged(nameof(HolidaysDateEnd));
                    }
                    else
                    {
                        throw new DataValidationException("Invalid end date");
                    }
                }
            }
        }

        private DateTime? _unsetHolidaysDateStart;
        public DateTime? UnsetHolidaysDateStart
        {
            get { return _unsetHolidaysDateStart; }
            set
            {
                if (value.HasValue)
                {
                    if (!UnsetHolidaysDateEnd.HasValue || (UnsetHolidaysDateEnd.HasValue && value < UnsetHolidaysDateEnd.Value))
                    {
                        _unsetHolidaysDateStart = value;
                        OnPropertyChanged(nameof(UnsetHolidaysDateStart));
                    }
                    else
                    {
                        throw new DataValidationException("Invalid start date");
                    }
                }
            }
        }

        private DateTime? _unsetHolidaysDateEnd;
        public DateTime? UnsetHolidaysDateEnd
        {
            get { return _unsetHolidaysDateEnd; }
            set
            {
                if (value.HasValue)
                {
                    if (!UnsetHolidaysDateStart.HasValue || (UnsetHolidaysDateStart.HasValue && value > UnsetHolidaysDateStart.Value))
                    {
                        _unsetHolidaysDateEnd = value;
                        OnPropertyChanged(nameof(UnsetHolidaysDateEnd));
                    }
                    else
                    {
                        throw new DataValidationException("Invalid end date");
                    }
                }
            }
        }




        

        #endregion



        #region time

        private TimeSpan? _unsetMeetingTime;
        public TimeSpan? UnsetMeetingTime
        {
            get { return _unsetMeetingTime; }
            set
            {
                if (value.HasValue)
                {
                    if (value >= new TimeSpan(9, 0, 0) && value <= new TimeSpan(18, 0, 0))
                    {
                        _unsetMeetingTime = value;
                        OnPropertyChanged(nameof(UnsetMeetingTime));
                    }
                    else
                    {
                        throw new DataValidationException("Invalid meeting time");
                    }
                }
            }
        }


        private TimeSpan? _meetingTime;
        public TimeSpan? MeetingTime
        {
            get { return _meetingTime; }
            set
            {
                if (value.HasValue)
                {
                    if (value >= new TimeSpan(9, 0, 0) && value <= new TimeSpan(18, 0, 0))
                    {
                        _meetingTime = value;
                        OnPropertyChanged(nameof(MeetingTime));
                    }
                    else
                    {
                        throw new DataValidationException("Invalid meeting time");
                    }
                }
            }
        }


        private TimeSpan? _unsetMeetingTimeStart;
        public TimeSpan? UnsetMeetingTimeStart
        {
            get { return _unsetMeetingTimeStart; }
            set
            {
                if (value.HasValue)
                {
                    if (!UnsetMeetingTimeEnd.HasValue || (UnsetMeetingTimeEnd.HasValue && value < UnsetMeetingTimeEnd.Value))
                    {
                        _unsetMeetingTimeStart = value;
                        OnPropertyChanged(nameof(UnsetMeetingTimeStart));
                    }
                    else
                    {
                        throw new DataValidationException("Invalid start time");
                    }
                }
            }
        }

        private TimeSpan? _unsetMeetingTimeEnd;
        public TimeSpan? UnsetMeetingTimeEnd
        {
            get { return _unsetMeetingTimeEnd; }
            set
            {
                if (value.HasValue)
                {
                    if (!UnsetMeetingTimeStart.HasValue || (UnsetMeetingTimeStart.HasValue && value > UnsetMeetingTimeStart.Value))
                    {
                        _unsetMeetingTimeEnd = value;
                        OnPropertyChanged(nameof(UnsetMeetingTimeEnd));
                    }
                    else
                    {
                        throw new DataValidationException("Invalid end time");
                    }
                }
            }
        }





        private TimeSpan? _meetingTimeStart;
        public TimeSpan? MeetingTimeStart
        {
            get { return _meetingTimeStart; }
            set
            {
                if (value.HasValue)
                {
                    if (!MeetingTimeEnd.HasValue || (MeetingTimeEnd.HasValue && value < MeetingTimeEnd.Value))
                    {
                        _meetingTimeStart = value;
                        OnPropertyChanged(nameof(MeetingTimeStart));
                    }
                    else
                    {
                        throw new DataValidationException("Invalid start time");
                    }
                }
            }
        }

        private TimeSpan? _meetingTimeEnd;
        public TimeSpan? MeetingTimeEnd
        {
            get { return _meetingTimeEnd; }
            set
            {
                if (value.HasValue)
                {
                    if (!MeetingTimeStart.HasValue || (MeetingTimeStart.HasValue && value > MeetingTimeStart.Value))
                    {
                        _meetingTimeEnd = value;
                        OnPropertyChanged(nameof(MeetingTimeEnd));
                    }
                    else
                    {
                        throw new DataValidationException("Invalid end time");
                    }
                }
            }
        }

        #endregion



        /// <summary>
        /// Dirty hack to force binding refresh
        /// </summary>
        private void ForceDateBindingsRefresh()
        {
            if (BirthDate.HasValue)
            {
                BirthDate = new DateTime(BirthDate.Value.Year - 1, BirthDate.Value.Month, BirthDate.Value.Day);
                BirthDate = new DateTime(BirthDate.Value.Year + 1, BirthDate.Value.Month, BirthDate.Value.Day);
            }

            if (TestDate1.HasValue)
            {
                TestDate1 = new DateTime(TestDate1.Value.Year - 1, TestDate1.Value.Month, TestDate1.Value.Day);
                TestDate1 = new DateTime(TestDate1.Value.Year + 1, TestDate1.Value.Month, TestDate1.Value.Day);
            }

            if (TestDate2.HasValue)
            {
                TestDate2 = new DateTime(TestDate2.Value.Year - 1, TestDate2.Value.Month, TestDate2.Value.Day);
                TestDate2 = new DateTime(TestDate2.Value.Year + 1, TestDate2.Value.Month, TestDate2.Value.Day);
            }

            if (HolidaysDateStart.HasValue)
            {
                HolidaysDateStart = new DateTime(HolidaysDateStart.Value.Year, HolidaysDateStart.Value.Month, HolidaysDateStart.Value.Day + 1);
                HolidaysDateStart = new DateTime(HolidaysDateStart.Value.Year, HolidaysDateStart.Value.Month, HolidaysDateStart.Value.Day - 1);
            }

            if (HolidaysDateEnd.HasValue)
            {
                HolidaysDateEnd = new DateTime(HolidaysDateEnd.Value.Year, HolidaysDateEnd.Value.Month, HolidaysDateEnd.Value.Day + 1);
                HolidaysDateEnd = new DateTime(HolidaysDateEnd.Value.Year, HolidaysDateEnd.Value.Month, HolidaysDateEnd.Value.Day - 1);
            }

            if (UnsetHolidaysDateStart.HasValue)
            {
                UnsetHolidaysDateStart = new DateTime(UnsetHolidaysDateStart.Value.Year, UnsetHolidaysDateStart.Value.Month, UnsetHolidaysDateStart.Value.Day + 1);
                UnsetHolidaysDateStart = new DateTime(UnsetHolidaysDateStart.Value.Year, UnsetHolidaysDateStart.Value.Month, UnsetHolidaysDateStart.Value.Day - 1);
            }

            if (UnsetHolidaysDateEnd.HasValue)
            {
                UnsetHolidaysDateEnd = new DateTime(UnsetHolidaysDateEnd.Value.Year, UnsetHolidaysDateEnd.Value.Month, UnsetHolidaysDateEnd.Value.Day + 1);
                UnsetHolidaysDateEnd = new DateTime(UnsetHolidaysDateEnd.Value.Year, UnsetHolidaysDateEnd.Value.Month, UnsetHolidaysDateEnd.Value.Day - 1);
            }
        }


        /// <summary>
        /// Dirty hack to force binding refresh
        /// </summary>
        private void ForceTimeBindingsRefresh()
        {
            if (UnsetMeetingTime.HasValue)
            {
                UnsetMeetingTime = new TimeSpan(UnsetMeetingTime.Value.Hours, UnsetMeetingTime.Value.Minutes, UnsetMeetingTime.Value.Seconds + 1);
                UnsetMeetingTime = new TimeSpan(UnsetMeetingTime.Value.Hours, UnsetMeetingTime.Value.Minutes, UnsetMeetingTime.Value.Seconds - 1);
            }

            if (MeetingTime.HasValue)
            {
                MeetingTime = new TimeSpan(MeetingTime.Value.Hours, MeetingTime.Value.Minutes, MeetingTime.Value.Seconds + 1);
                MeetingTime = new TimeSpan(MeetingTime.Value.Hours, MeetingTime.Value.Minutes, MeetingTime.Value.Seconds - 1);
            }

            if (UnsetMeetingTimeStart.HasValue)
            {
                UnsetMeetingTimeStart = new TimeSpan(UnsetMeetingTimeStart.Value.Hours, UnsetMeetingTimeStart.Value.Minutes, UnsetMeetingTimeStart.Value.Seconds + 1);
                UnsetMeetingTimeStart = new TimeSpan(UnsetMeetingTimeStart.Value.Hours, UnsetMeetingTimeStart.Value.Minutes, UnsetMeetingTimeStart.Value.Seconds - 1);
            }

            if (UnsetMeetingTimeEnd.HasValue)
            {
                UnsetMeetingTimeEnd = new TimeSpan(UnsetMeetingTimeEnd.Value.Hours, UnsetMeetingTimeEnd.Value.Minutes, UnsetMeetingTimeEnd.Value.Seconds + 1);
                UnsetMeetingTimeEnd = new TimeSpan(UnsetMeetingTimeEnd.Value.Hours, UnsetMeetingTimeEnd.Value.Minutes, UnsetMeetingTimeEnd.Value.Seconds - 1);
            }
        }





        public DateTimePickersDemoViewModel()
        {
            HolidaysDateStart = new DateTime(DateTime.Today.Year, 8, 1);
            HolidaysDateEnd = new DateTime(DateTime.Today.Year, 8, 20);

            MeetingTimeStart = new TimeSpan(9,0,0);
            MeetingTimeEnd = new TimeSpan(17,0,0);


            TestDate1 = new DateTime(1980, 12, 25);


            MeetingTime = new TimeSpan(15,0,0);

            // retreive current os/system culture
            //CultureInfo culture = CultureInfo.CurrentCulture;
        }

    }
}