using Material.Icons;
using Neumorphism.Avalonia.Demo.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class TabsDemoViewModel : ViewModelBase
    {
        #region Properties

        private ObservableCollection<CustomTabItem> _tabItems = default;
        public ObservableCollection<CustomTabItem> TabItems
        {
            get { return _tabItems; }
            set
            {
                _tabItems = value;
                OnPropertyChanged(nameof(TabItems));
            }
        }

        private CustomTabItem _selectedTabItemTop;
        public CustomTabItem SelectedTabItemTop
        {
            get { return _selectedTabItemTop; }
            set
            {
                _selectedTabItemTop = value;
                OnPropertyChanged(nameof(SelectedTabItemTop));
            }
        }

        private CustomTabItem _selectedTabItemBottom;
        public CustomTabItem SelectedTabItemBottom
        {
            get { return _selectedTabItemBottom; }
            set
            {
                _selectedTabItemBottom = value;
                OnPropertyChanged(nameof(SelectedTabItemBottom));
            }
        }

        private CustomTabItem _selectedTabItemLeft;
        public CustomTabItem SelectedTabItemLeft
        {
            get { return _selectedTabItemLeft; }
            set
            {
                _selectedTabItemLeft = value;
                OnPropertyChanged(nameof(SelectedTabItemLeft));
            }
        }

        private CustomTabItem _selectedTabItemRight;
        public CustomTabItem SelectedTabItemRight
        {
            get { return _selectedTabItemRight; }
            set
            {
                _selectedTabItemRight = value;
                OnPropertyChanged(nameof(SelectedTabItemRight));
            }
        }

        #endregion


        public TabsDemoViewModel()
        {
            TabItems = BuildTabItems();

            SelectedTabItemTop = TabItems.First();
            SelectedTabItemBottom = TabItems.First();
        }

        private ObservableCollection<CustomTabItem> BuildTabItems()
        {
            var menuItems = new ObservableCollection<CustomTabItem>
            {
                new CustomTabItem()
                {
                    Header = "TAB 1",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    Icon = MaterialIconKind.UserAccessControl
                },
                new CustomTabItem()
                {
                    Header = "TAB 2",
                    Text = "At erat pellentesque adipiscing commodo elit at imperdiet dui accumsan. Dolor sit amet consectetur adipiscing. Mauris vitae ultricies leo integer malesuada. Mus mauris vitae ultricies leo integer malesuada nunc. Bibendum arcu vitae elementum curabitur vitae nunc.",
                    Icon = MaterialIconKind.Database
                },
                new CustomTabItem()
                {
                    Header = "TAB 3",
                    Text = "Risus viverra adipiscing at in tellus integer feugiat. Feugiat pretium nibh ipsum consequat nisl vel pretium lectus quam. Molestie at elementum eu facilisis. Faucibus nisl tincidunt eget nullam non nisi. Sit amet nisl suscipit adipiscing bibendum est ultricies integer quis.",
                    Icon = MaterialIconKind.FileAccount,
                    Enabled = false
                }
            };

            return menuItems;
        }
    }
}