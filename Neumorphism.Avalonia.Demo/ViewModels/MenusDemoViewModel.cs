using Avalonia.Themes.Neumorphism.Controls;
using Neumorphism.Avalonia.Demo.Models;
using System.Collections.ObjectModel;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class MenusDemoViewModel : ViewModelBase
    {
        #region Properties

        private ObservableCollection<CustomMenuItem> _menuItems;
        public ObservableCollection<CustomMenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                OnPropertyChanged(nameof(MenuItems));
            }
        }

        #endregion

        #region commands

        public void MenuItemClickCommand(string msg)
        {
            SnackbarHost.Post("You clicked on menu item " + msg);
        }

        #endregion

        public MenusDemoViewModel()
        {
            MenuItems = BuildMenuItems();
        }


        private ObservableCollection<CustomMenuItem> BuildMenuItems()
        {
            var menuItems = new ObservableCollection<CustomMenuItem>
            {
                new CustomMenuItem()
                {
                    Title = "File",
                    Items = new ObservableCollection<CustomMenuItem>()
                    {
                        new CustomMenuItem()
                        {
                            Title = "New",
                            Icon = "ButtonPointer",
                            Items = new ObservableCollection<CustomMenuItem>()
                            {
                                new CustomMenuItem()
                                {
                                    Title = "Image",
                                    Icon = "Image",
                                    Items = new ObservableCollection<CustomMenuItem>()
                                    {
                                        new CustomMenuItem() { Title = "GIF", Icon = "ImageArea" },
                                        new CustomMenuItem() { Title = "JPG", Icon = "ImageArea" },
                                        new CustomMenuItem() { Title = "PNG", Icon = "ImageArea" }
                                    }
                                },
                                new CustomMenuItem()
                                {
                                    Title = "Video",
                                    Icon = "Video",
                                    Items = new ObservableCollection<CustomMenuItem>()
                                    {
                                        new CustomMenuItem() { Title = "MP4", Icon = "VideoFilm" },
                                        new CustomMenuItem() { Title = "MKV", Icon = "VideoFilm" },
                                        new CustomMenuItem() { Title = "MOV", Icon = "VideoFilm" }
                                    }
                                },
                                new CustomMenuItem()
                                {
                                    Title = "Music",
                                    Icon = "Music",
                                    Items = new ObservableCollection<CustomMenuItem>()
                                    {
                                        new CustomMenuItem() { Title = "MP3", Icon = "MusicBox" },
                                        new CustomMenuItem() { Title = "FLAC", Icon = "MusicBox" },
                                        new CustomMenuItem() { Title = "WAV", Icon = "MusicBox" }
                                    }
                                }
                            }
                        },
                        new CustomMenuItem() { Title = "Open", Icon = "FileEditOutline" },
                        new CustomMenuItem() { Title = "Save", Icon = "FileRefreshOutline" },
                        new CustomMenuItem() { Title = "Delete", Icon = "FileRemoveOutline" }
                    }
                },
                new CustomMenuItem()
                {
                    Title = "Edit",
                    Items = new ObservableCollection<CustomMenuItem>()
                    {
                        new CustomMenuItem() { Title = "Copy", Icon = "ContentCopy" },
                        new CustomMenuItem() { Title = "Cut", Icon = "ContentCut" },
                        new CustomMenuItem() { Title = "Paste", Icon = "ContentPaste" },
                        // separator
                        new CustomMenuItem() { Title = "Undo", Icon = "Undo" },
                        new CustomMenuItem() { Title = "Redo", Icon = "Redo" }
                    }
                },
                new CustomMenuItem()
                {
                    Title = "Help",
                    Items = new ObservableCollection<CustomMenuItem>()
                    {
                        new CustomMenuItem() { Title = "About", Icon = "AboutOutline" }
                    }
                }
            };
            
            return menuItems;
        }
    }
}