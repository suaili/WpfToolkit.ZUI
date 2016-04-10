using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ZUI.Controls
{
    /// <summary>
    /// 圆形进度条
    /// </summary>
    public class CircularProgressBar : ProgressBar
    {
        #region 依赖属性
        public static readonly DependencyProperty ProgressColorProperty = DependencyProperty.Register("ProgressColor"
            , typeof(Brush), typeof(CircularProgressBar), new FrameworkPropertyMetadata(default(Brush)));
        /// <summary>
        /// 进度条颜色
        /// </summary>
        public Brush ProgressColor
        {
            get { return (Brush)GetValue(ProgressColorProperty); }
            set { SetValue(ProgressColorProperty, value); }
        }

        public static readonly DependencyProperty ArcThicknessProperty = DependencyProperty.Register("ArcThickness"
            , typeof(double), typeof(CircularProgressBar), new PropertyMetadata(2d));
        /// <summary>
        /// 进度条宽度
        /// </summary>
        public double ArcThickness
        {
            get { return (double)GetValue(ArcThicknessProperty); }
            set { SetValue(ArcThicknessProperty, value); }
        }
        #endregion

        public CircularProgressBar() : base()
        {
            //获取资源文件信息
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("/WpfToolkit.ZUI.Controls;component/Themes/CircularProgressBarStyle.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(rd);

            this.Style = this.Resources.MergedDictionaries[0]["ProgressBarStyle1"] as Style;
        }
    }
}
