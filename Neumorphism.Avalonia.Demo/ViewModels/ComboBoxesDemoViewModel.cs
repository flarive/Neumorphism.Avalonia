using Avalonia.Themes.Neumorphism.Controls;
using System.Collections.Generic;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class ComboBoxesDemoViewModel : ViewModelBase
    {
        private List<KeyValuePair<int, string>> _allBeatles;
        public List<KeyValuePair<int, string>> AllBeatles
        {
            get { return _allBeatles; }
            set
            {
                _allBeatles = value;
                OnPropertyChanged(nameof(AllBeatles));
            }
        }

        private KeyValuePair<int, string>? _myFavoriteBeatle1;
        public KeyValuePair<int, string>? MyFavoriteBeatle1
        {
            get { return _myFavoriteBeatle1; }
            set
            {
                _myFavoriteBeatle1 = value;
                OnPropertyChanged(nameof(MyFavoriteBeatle1));
            }
        }

        private KeyValuePair<int, string>? _myFavoriteBeatle2;
        public KeyValuePair<int, string>? MyFavoriteBeatle2
        {
            get { return _myFavoriteBeatle2; }
            set
            {
                _myFavoriteBeatle2 = value;
                OnPropertyChanged(nameof(MyFavoriteBeatle2));
            }
        }

        public ComboBoxesDemoViewModel()
        {
            AllBeatles =
            [
                new KeyValuePair<int, string>(0, "John"),
                new KeyValuePair<int, string>(1, "Paul"),
                new KeyValuePair<int, string>(2, "Ringo"),
                new KeyValuePair<int, string>(3, "Georges"),
                new KeyValuePair<int, string>(-1, "None of them"),
            ];
        }

        public void ButtonClick() => SnackbarHost.Post("You have clicked on the button !");

    }
}