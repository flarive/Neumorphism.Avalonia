using Avalonia.Themes.Neumorphism.Controls;
using Material.Icons;
using Neumorphism.Avalonia.Demo.Models;
using System.Collections.ObjectModel;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class ListsDemoViewModel : ViewModelBase
    {
        #region Properties

        private ObservableCollection<CustomListItem> _listItems1;
        public ObservableCollection<CustomListItem> ListItems1
        {
            get { return _listItems1; }
            set
            {
                _listItems1 = value;
                OnPropertyChanged(nameof(ListItems1));
            }
        }

        private ObservableCollection<CustomListItem> _listItems2;
        public ObservableCollection<CustomListItem> ListItems2
        {
            get { return _listItems2; }
            set
            {
                _listItems2 = value;
                OnPropertyChanged(nameof(ListItems2));
            }
        }

        #endregion

        #region Commands

        public void ListItemClickCommand(CustomListItem item)
        {
            SnackbarHost.Post("You clicked on list item " + item?.Title);
        }

        #endregion


        public ListsDemoViewModel()
        {
            ListItems1 = BuildListItems1();
            ListItems2 = BuildListItems2();
        }


        private ObservableCollection<CustomListItem> BuildListItems1()
        {
            var listItems = new ObservableCollection<CustomListItem>
            {
                new CustomListItem() { Title = "List Item 1", Icon = MaterialIconKind.Heart },
                new CustomListItem() { Title = "List Item 2", Icon = MaterialIconKind.Heart },
                new CustomListItem() { Title = "List Item 3", Icon = MaterialIconKind.Heart },
                new CustomListItem() { Title = "List Item 4", Icon = MaterialIconKind.Heart }
            };

            return listItems;
        }

        private ObservableCollection<CustomListItem> BuildListItems2()
        {
            var listItems = new ObservableCollection<CustomListItem>
            {
                new CustomListItem() { Title = "List Item 1", Icon = MaterialIconKind.TooltipOutline },
                new CustomListItem() { Title = "List Item 2", Icon = MaterialIconKind.TooltipOutline },
                new CustomListItem() { Title = "List Item 3", Icon = MaterialIconKind.TooltipOutline },
                new CustomListItem() { Title = "List Item 4", Icon = MaterialIconKind.TooltipOutline },
                new CustomListItem() { Title = "List Item 5", Icon = MaterialIconKind.TooltipOutline },
                new CustomListItem() { Title = "List Item 6", Icon = MaterialIconKind.TooltipOutline }
            };

            return listItems;
        }


    }
}
