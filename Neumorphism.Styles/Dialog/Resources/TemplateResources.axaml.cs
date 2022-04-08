using System;
using Avalonia.Controls;
using Neumorphism.Styles.Dialog.ViewModels.Elements;
using Neumorphism.Styles.Dialog.ViewModels.Elements.Header.Icons;

namespace Neumorphism.Styles.Dialog.Resources
{
    // ReSharper disable once UnusedType.Global
    public class TemplateResources : ResourceDictionary
    {
        // ReSharper disable UnusedMember.Local
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
        
        // ReSharper restore UnusedMember.Local
    }
}