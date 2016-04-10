using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ZUI.Controls.Converters
{
    /// <summary>
    /// 根据Value计算圆形进度条的角度
    /// </summary>
    public class ValueToAngleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double value = System.Convert.ToDouble(values[0]);
            double maxinum = System.Convert.ToDouble(values[1]);

            double angle = value / maxinum * 360;

            return angle;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
