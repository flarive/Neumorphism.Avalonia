
[nuget]: https://www.nuget.org/packages/Neumorphism.Avalonia/

# <img src="favicon.png" width="48" height="48" valign="bottom"> Neumorphism.Avalonia

Easy to use and customizable Neumorphism Design implementation for [AvaloniaUI](http://avaloniaui.net/) framework.



![Screenshot](Avalonia.Neumorphism.Demo.gif)

# <img src="favicon.png" width="32" height="32"> Expanders added in 0.11.0 !
- 3 different possible themes
- Can be customized

![Screenshot](Screenshots/expanders.png)

# <img src="favicon.png" width="32" height="32"> Tab navigation focus added in 0.10.0 !
- All controls now have a nice looking focus adorner

# <img src="favicon.png" width="32" height="32"> Dialogs added in 0.9.0 !
- DialogHost based fake child window dialogs
- Real child window based dialogs (with or without chrome)
- Dialog builder to help create dialogs easily
- A lot of dialogs examples (alert, warning, error, confirm, dialogs sequence, fully custom dialog....)

![Screenshot](Screenshots/dialogs.png)

# <img src="favicon.png" width="32" height="32"> Menus added in 0.8.0 !
- 6 different possible themes
- Icon support
- Multi level menu items
- Fully custom template possible for root menu

![Screenshot](Screenshots/menus.png)

# <img src="favicon.png" width="32" height="32"> DateTime pickers added in 0.7.0 !
- Calendar based date picker
- Time picker

![Screenshot](Screenshots/datetimepickers.png)

# <img src="favicon.png" width="32" height="32"> Tabs added in 0.6.0 !
- Tabs are now fully themed with different possible styles

![Screenshot](Screenshots/tabs.png)

# <img src="favicon.png" width="32" height="32"> Avalonia 11 support in 0.5.0 !
- Totally rewritten for Avalonia 0.11 !
- Support Avalonia 0.11 Control Themes
- Works with native AOT compilation
- ListBoxes now fully themed
- Drawings page added in demo project

# <img src="favicon.png" width="32" height="32"> Cards and use cases added in 0.4.0 !
- Cards are now fully themed with 2 differents styles : outset (default) and inset
- Added real life use cases samples (login, stopwatch, audio player, messages, sleep quality, user profile...)

![Screenshot](Screenshots/usecases.png)

# <img src="favicon.png" width="32" height="32"> Sliders added in 0.3.1 !
![Screenshot](Screenshots/sliders.png)

# <img src="favicon.png" width="32" height="32"> Progressbars added in 0.2.1 !
![Screenshot](Screenshots/progressbar.png)


# <img src="favicon.png" width="32" height="32"> Overview

This library is a collection of styles to help you build your Avalonia app with a ready to go Neumorphism Design theme.
(https://github.com/flarive/Neumorphism.Avalonia)



[![nuget](https://img.shields.io/nuget/v/Neumorphism.Avalonia?label=Nuget&style=flat-square)][nuget]
[![nuget](https://img.shields.io/nuget/dt/Neumorphism.Avalonia?color=blue&label=Downloads&style=flat-square)][nuget]




This Avalonia UI Neumorphic theme was inspired by another great Avalonia UI theme : [Material.Avalonia](https://github.com/AvaloniaCommunity/Material.Avalonia)

As neumorphism has no official specifications, this is my own personal interpretation of Neumorphism general guidelines i found on the web (mainly on [Dribble](https://dribbble.com/tags/neumorphism)).

It also uses some elements of Material Design such as :
- Primary and Secondary (Accent) color with light and dark variants
- A light theme and a dark theme (you can switch between them at runtime)
- Material Design Icons (must be installed separately)

For the moment only the following controls are fully themed :
- Buttons
- ToggleButtons
- RadioButtons
- Checkboxes
- Textboxes
- Comboboxes
- ProgressBars
- Sliders
- Cards
- ListBoxes
- Tabs
- DateTime pickers
- Menus
- Dialogs
- Expanders

More controls should be themed soon.





# <img src="favicon.png" width="32" height="32"> Technical info

- Single .net Standard Library DLL (Avalonia.Themes.Neumorphism.dll)
- Can be used with .net Core 3.x, .net5, .net6, .net7, .net8...
- Lightweight (DLL is 1.5Mo when compiled in release mode)
- Built upon the latest version of Avalonia UI
- .Net 8 demo application project
- Support Native AOT compilation (publish with dotnet publish -c release --framework net8.0 -r win-x64)


# <img src="favicon.png" width="32" height="32"> How to start ?

1. Add [Neumorphism.Avalonia][nuget] nuget package to your project :

       dotnet add package Neumorphism.Avalonia



2. Edit your Avalonia project `App.xaml` file:

      ```xaml
      <Application ...
          xmlns:themes="clr-namespace:Avalonia.Themes.Neumorphism;assembly=Avalonia.Themes.Neumorphism"
          ...>
          <Application.Styles>
              <themes:NeumorphismTheme BaseTheme="Light" PrimaryColor="Purple" SecondaryColor="Lime" />
          </Application.Styles>
      </Application>
      ```

# <img src="favicon.png" width="32" height="32"> Licence

Neumorphism.Avalonia is free to use in any non commercial project.

If you like this project and want to help to maintain it, you can sponsor it (thanks a lot !)

<a target="_blank" href="https://www.patreon.com/NeumorphismAvalonia"><img src="https://img.shields.io/badge/patreon-donate-green.svg"/></a>




