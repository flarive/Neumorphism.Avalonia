using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Neumorphism.Styles.Themes;

namespace Neumorphism.Styles.Converters
{
    public class ControlWidthToBoxShadowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = new BoxShadows();
            bool inset = parameter != null && parameter.Equals("1");



            var theme = Application.Current!.LocateMaterialTheme<MaterialTheme>();

            //if (theme.CurrentTheme.Paper.R == 44)
            //{
            //    Debug.WriteLine("dark");
            //}
            //else
            //{
            //    Debug.WriteLine("light");
            //}




            //bool gen = Gen();


            if (value is double)
            {
                double height = (double)value;
                if (height > 0)
                {
                    // for a 300x300 button shadow radius must be 60 (300/5);
                    double radius = (double)(height / 5);

                    // for a 300x300 button shadow offset must be 20 (300/15);
                    double offset = (double)(height / 15);


                    

                    


                    //-20 -20 60 #CCFFFFFF,20 20 60 #33000000
                    BoxShadow main = new BoxShadow();
                    main.OffsetX = -offset;
                    main.OffsetY = -offset;
                    main.Blur = radius;
                    //main.Color = gen ? Color.Parse("#22FFFFFF") : Color.Parse("#CCFFFFFF");
                    main.Color = theme.CurrentTheme.ShadowLightColor;


                    BoxShadow rest1 = new BoxShadow();
                    rest1.OffsetX = offset;
                    rest1.OffsetY = offset;
                    rest1.Blur = radius;
                    //rest1.Color = gen ? Color.Parse("#33000000") : Color.Parse("#33000000");
                    rest1.Color = theme.CurrentTheme.ShadowDarkColor;


                    //Debug.WriteLine(theme.CurrentTheme.Paper.ToString());


                    if (inset)
                    {
                        main.IsInset = true;
                        rest1.IsInset = true;

                        main.OffsetX = offset / 2;
                        main.OffsetY = offset / 2;

                        rest1.OffsetX = -offset / 2;
                        rest1.OffsetY = -offset / 2;

                        

                        // invert shadow colors
                        //rest1.Color = (theme.BaseTheme == Themes.Base.BaseThemeMode.Dark) ? Color.Parse("#22FFFFFF") : Color.Parse("#CCFFFFFF");
                        rest1.Color = theme.CurrentTheme.ShadowLightColor;

                        //main.Color = (theme.BaseTheme == Themes.Base.BaseThemeMode.Dark) ? Color.Parse("#33000000") : Color.Parse("#33000000");
                        main.Color = theme.CurrentTheme.ShadowDarkColor;

                        
                    }


                    List<BoxShadow> rest = new List<BoxShadow>() { rest1 };
                    b = new BoxShadows(main, rest.ToArray());
                }
            }

            return b;
        }

        //private bool Gen()
        //{
        //    Random gen = new Random(Guid.NewGuid().GetHashCode());
        //    int prob = gen.Next(100);
        //    return prob <= 20;
        //}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}