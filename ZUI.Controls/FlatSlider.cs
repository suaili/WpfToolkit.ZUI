using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ZUI.Controls
{
    public class FlatSlider : Slider
    {
        public FlatSlider() : base()
        {
            //获取资源文件信息
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("/WpfToolkit.ZUI.Controls;component/Themes/SliderStyle.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(rd);

            this.Style = this.Resources.MergedDictionaries[0]["SliderStyle1"] as Style;
        }
    }
}
