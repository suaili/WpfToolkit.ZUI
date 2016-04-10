using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ZUI.Controls.Converters
{
    public class TitleWidthToWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string title = System.Convert.ToString(value);
            double titleWidth = 0d;
            
            if(titleWidth <= 0)
            {
                //new FormattedText(title, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, )
                return 20;
            }
            else
            {
                return titleWidth;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
