using Avalonia.Data;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels;
using Neumorphism.Avalonia.Demo.Windows.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Neumorphism.Avalonia.Demo.Windows.ViewModels.Dialogs
{
    public sealed class SampleCustomDialogViewModel : DialogWindowViewModel
    {
        private int? _number = 0;
        public int? Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }


        private List<KeyValuePair<int, string>> _civilities;
        public List<KeyValuePair<int, string>> Civilities
        {
            get { return _civilities; }
            set
            {
                _civilities = value;
                OnPropertyChanged(nameof(Civilities));
            }
        }

        private KeyValuePair<int, string> _civility;
        public KeyValuePair<int, string> Civility
        {
            get { return _civility; }
            set
            {
                _civility = value;
                OnPropertyChanged(nameof(Civility));
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }


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


        public SampleCustomDialogViewModel(SampleCustomDialog dialog) : base(dialog)
        {
            Civilities =
            [
                new KeyValuePair<int, string>(1, "Mr"),
                new KeyValuePair<int, string>(2, "Mme"),
                new KeyValuePair<int, string>(3, "Melle"),
            ];
        }
    }
}