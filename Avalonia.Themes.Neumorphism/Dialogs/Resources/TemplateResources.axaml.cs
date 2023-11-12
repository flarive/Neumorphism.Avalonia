using System;
using Avalonia.Controls;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels.Elements;
using Avalonia.Themes.Neumorphism.Dialogs.ViewModels.Elements.Header.Icons;

namespace Avalonia.Themes.Neumorphism.Dialogs.Resources
{
    public sealed class TemplateResources : ResourceDictionary
    {
        private void DialogButtonTemplate_OnSelectTemplateKey(object sender, SelectTemplateEventArgs e)
        {
            e.TemplateKey = e.DataContext switch
            {
                ObsoleteDialogButtonViewModel _ => "ObsoleteButton",
                DialogButtonViewModel _ => "StandardButton",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void DialogHeaderIconTemplate_OnSelectTemplateKey(object sender, SelectTemplateEventArgs e)
        {
            e.TemplateKey = e.DataContext switch
            {
                DialogIconViewModel _ => "DialogIcon",
                ImageIconViewModel _ => "DialogImageIcon",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}