using Neumorphism.Avalonia.Demo.Models;
using System.Collections.ObjectModel;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class ListsDemoViewModel : ViewModelBase
    {
        #region Properties

        private ObservableCollection<CustomListItem> _listItems;
        public ObservableCollection<CustomListItem> ListItems
        {
            get { return _listItems; }
            set
            {
                _listItems = value;
                OnPropertyChanged(nameof(ListItems));
            }
        }

        #endregion


        public ListsDemoViewModel()
        {
            ListItems = BuildListItems();
        }


        private ObservableCollection<CustomListItem> BuildListItems()
        {
            var listItems = new ObservableCollection<CustomListItem>
            {
                new CustomListItem() { Title = "List Item 1" },
                new CustomListItem() { Title = "List Item 2" },
                new CustomListItem() { Title = "List Item 3" },
                new CustomListItem() { Title = "List Item 4" }
            };

            return listItems;
        }
    }
}
