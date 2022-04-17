

# <img src="/favicon.png" width="48" height="48" valign="bottom"> Neumorphism.Avalonia

Easy to use and customizable Neumorphism Design implementation for [AvaloniaUI](http://avaloniaui.net/) framework.



![Screenshot](Avalonia.Neumorphism.Demo.gif)


# <img src="/favicon.png" width="32" height="32"> Overview

This library is a collection of styles to help you build your Avalonia app with a ready to go Neumorphism Design theme.
(https://github.com/flarive/Neumorphism.Avalonia)

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

More controls should be themed soon.



# <img src="/favicon.png" width="32" height="32"> Technical info

- Single .net Standard Library DLL (Neumorphism.Avalonia.dll)
- Should be used with .net Core 3.x, .net5, .net6...
- Lightweight (DLL is 1.5Mo when compiled in release mode)
- Built upon the latest version of Avalonia UI (0.10.13)
- .Net 5 demo application project


# <img src="/favicon.png" width="32" height="32"> How to start ?

1. Add [Neumorphism.Avalonia][nuget] nuget package to your project (should be available soon !) :

       dotnet add package Neumorphism.Avalonia

2. Edit your Avalonia project `App.xaml` file:

      ```xaml
      <Application ...
          xmlns:themes="clr-namespace:Neumorphism.Avalonia.Styles.Themes;assembly=Neumorphism.Avalonia"
          ...>
          <Application.Styles>
              <themes:NeumorphismTheme BaseTheme="Dark" PrimaryColor="Purple" SecondaryColor="Lime" />
          </Application.Styles>
      </Application>
      ```

# <img src="/favicon.png" width="32" height="32"> Licence

Neumorphism.Avalonia is free to use in any non commercial project.

