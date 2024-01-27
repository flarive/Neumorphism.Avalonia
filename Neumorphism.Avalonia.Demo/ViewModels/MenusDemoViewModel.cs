using Avalonia.Themes.Neumorphism.Controls;
using Avalonia.Themes.Neumorphism.Models;
using Material.Icons;
using Material.Icons.Avalonia;
using Neumorphism.Avalonia.Demo.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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
                            Icon = new MaterialIcon() {Kind = MaterialIconKind.FilePlusOutline},
                            Items = new ObservableCollection<CustomMenuItem>()
                            {
                                new CustomMenuItem()
                                {
                                    Title = "Image",
                                    Icon = new MaterialIcon() {Kind = MaterialIconKind.Image},
                                    Items = new ObservableCollection<CustomMenuItem>()
                                    {
                                        new CustomMenuItem() { Title = "GIF", Icon = new MaterialIcon() { Kind = MaterialIconKind.ImageArea }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "new_image_GIF" },
                                        new CustomMenuItem() { Title = "JPG", Icon = new MaterialIcon() { Kind = MaterialIconKind.ImageArea }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "new_image_JPG" },
                                        new CustomMenuItem() { Title = "PNG", Icon = new MaterialIcon() { Kind = MaterialIconKind.ImageArea }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "new_image_PNG" }
                                    }
                                },
                                new CustomMenuItem()
                                {
                                    Title = "Video",
                                    Icon = new MaterialIcon() { Kind = MaterialIconKind.Video },
                                    Items = new ObservableCollection<CustomMenuItem>()
                                    {
                                        new CustomMenuItem() { Title = "MP4", Icon = new MaterialIcon() { Kind = MaterialIconKind.VideoFilm }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "new_video_MP4" },
                                        new CustomMenuItem() { Title = "MKV", Icon = new MaterialIcon() { Kind = MaterialIconKind.VideoFilm }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "new_video_MKV" },
                                        new CustomMenuItem() { Title = "MOV", Icon = new MaterialIcon() { Kind = MaterialIconKind.VideoFilm }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "new_video_MOV" }
                                    }
                                },
                                new CustomMenuItem()
                                {
                                    Title = "Music",
                                    Icon = new MaterialIcon() { Kind = MaterialIconKind.Music },
                                    Items = new ObservableCollection<CustomMenuItem>()
                                    {
                                        new CustomMenuItem() { Title = "MP3", Icon = new MaterialIcon() { Kind = MaterialIconKind.MusicBox }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "new_music_MP3" },
                                        new CustomMenuItem() { Title = "FLAC", Icon = new MaterialIcon() { Kind = MaterialIconKind.MusicBox }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "new_music_FLAC" },
                                        new CustomMenuItem() { Title = "WAV", Icon = new MaterialIcon() { Kind = MaterialIconKind.MusicBox }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "new_music_WAV" }
                                    }
                                }
                            }
                        },
                        new CustomMenuItem() { Title = "Open", Icon = new MaterialIcon() { Kind = MaterialIconKind.FileEditOutline }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "open" },
                        new CustomMenuItem() { Title = "Save", Icon = new MaterialIcon() { Kind = MaterialIconKind.FileRefreshOutline }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "save" },
                        new CustomMenuItem() { Title = "Delete", Icon = new MaterialIcon() { Kind = MaterialIconKind.FileRemoveOutline }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "delete" }
                    }
                },
                new CustomMenuItem()
                {
                    Title = "Edit",
                    Items = new ObservableCollection<CustomMenuItem>()
                    {
                        new CustomMenuItem() { Title = "Copy", Icon = new MaterialIcon() { Kind = MaterialIconKind.ContentCopy }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "copy" },
                        new CustomMenuItem() { Title = "Cut", Icon = new MaterialIcon() { Kind = MaterialIconKind.ContentCut }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "cut" },
                        new CustomMenuItem() { Title = "Paste", Icon = new MaterialIcon() { Kind = MaterialIconKind.ContentPaste }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "paste" },
                        new CustomMenuItem() { Title = "-"}, // Separator
                        new CustomMenuItem() { Title = "Undo", Icon = new MaterialIcon() { Kind = MaterialIconKind.Undo }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "undo", Enabled = false },
                        new CustomMenuItem() { Title = "Redo", Icon = new MaterialIcon() { Kind = MaterialIconKind.Redo }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "redo", Enabled = false }
                    }
                },
                new CustomMenuItem()
                {
                    Title = "Help",
                    Items = new ObservableCollection<CustomMenuItem>()
                    {
                        new CustomMenuItem() { Title = "About", Icon = new MaterialIcon() { Kind = MaterialIconKind.AboutOutline }, Command = new RelayCommand(OnMenuItemClickCommandHandler), CommandParameter = "about" }
                    }
                }
            };
            
            return menuItems;
        }

        private async void OnMenuItemClickCommandHandler(object arg)
        {
            string commandParameter = arg as string;
            if (!string.IsNullOrEmpty(commandParameter))
            {
                MenuItemClickCommand(commandParameter);
            }
            
            await Task.Delay(10);
        }
    }
}