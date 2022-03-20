using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Neumorphism.Styles.Converters
{
    public class ControlWidthToBoxShadowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = new BoxShadows();
            bool inset = parameter != null && parameter == "1";

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
                    main.Color = Color.Parse("#CCFFFFFF");

                    BoxShadow rest1 = new BoxShadow();
                    rest1.OffsetX = offset;
                    rest1.OffsetY = offset;
                    rest1.Blur = radius;
                    rest1.Color = Color.Parse("#33000000");

                    
                    if (inset)
                    {
                        main.IsInset = true;
                        rest1.IsInset = true;

                        main.OffsetX = offset / 2;
                        main.OffsetY = offset / 2;

                        rest1.OffsetX = -offset / 2;
                        rest1.OffsetY = -offset / 2;


                        // invert shadow colors
                        rest1.Color = Color.Parse("#CCFFFFFF");
                        main.Color = Color.Parse("#33000000"); 
                    }


                    List<BoxShadow> rest = new List<BoxShadow>() { rest1 };

                    b = new BoxShadows(main, rest.ToArray());
                    
                }
            }

            return b;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}
