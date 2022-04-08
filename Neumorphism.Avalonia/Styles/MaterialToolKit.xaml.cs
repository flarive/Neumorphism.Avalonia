using aaa=Avalonia;
using Avalonia.Animation;
using Avalonia.Markup.Xaml;
using Neumorphism.Avalonia.Styles.Additional;

namespace Neumorphism.Avalonia.Styles {
    public class MaterialToolKit : aaa.Styling.Styles {
        public MaterialToolKit() {
            AvaloniaXamlLoader.Load(this);
            Animation.RegisterAnimator<RelativePointAnimator>(property => typeof(aaa.RelativePoint).IsAssignableFrom(property.PropertyType));
        }
    }
}