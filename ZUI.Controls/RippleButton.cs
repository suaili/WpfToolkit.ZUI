using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ZUI.Controls
{
    public enum RippleButtonSkin
    {
        DefaultButton,
        LightButton,
        DarkButton,
    }

    /// <summary>
    /// 带有水波纹点击效果的Button
    /// </summary>
    public class RippleButton : Button
    {
        #region 依赖属性

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius"
            , typeof(CornerRadius), typeof(RippleButton));
        /// <summary>
        /// 按钮四周圆角
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty RippleColorProperty = DependencyProperty.Register("RippleColor"
            , typeof(string), typeof(RippleButton), new PropertyMetadata("#FF000000"));
        /// <summary>
        /// 按钮点击时的水波纹颜色
        /// </summary>
        public string RippleColor
        {
            get { return (string)GetValue(RippleColorProperty); }
            set { SetValue(RippleColorProperty, value); }
        }

        public static readonly DependencyProperty MouseOverColorProperty = DependencyProperty.Register("MouseOverColor"
            , typeof(string), typeof(RippleButton), new FrameworkPropertyMetadata("#FF656D78"));
        /// <summary>
        /// 鼠标悬浮时按钮的背景色
        /// </summary>
        public string MouseOverColor
        {
            get { return (string)GetValue(MouseOverColorProperty); }
            set { SetValue(MouseOverColorProperty, value); }
        }

        public static readonly DependencyProperty SkinProperty = DependencyProperty.Register("Skin"
            , typeof(RippleButtonSkin), typeof(RippleButton));
        /// <summary>
        /// 按钮皮肤
        /// </summary>
        public RippleButtonSkin Skin
        {
            get { return (RippleButtonSkin)GetValue(SkinProperty); }
            set { SetValue(SkinProperty, value); }
        }

        #endregion

        public RippleButton() : base()
        {
            //获取资源文件信息
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("/WpfToolkit.ZUI.Controls;component/Themes/RippleButton.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(rd);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            switch (Skin)
            {
                case RippleButtonSkin.DefaultButton:
                    this.Style = this.Resources.MergedDictionaries[0]["DefaultButtonStyle"] as Style;
                    break;
                case RippleButtonSkin.LightButton:
                    this.Style = this.Resources.MergedDictionaries[0]["LightButtonStyle"] as Style;
                    break;
                case RippleButtonSkin.DarkButton:
                    this.Style = this.Resources.MergedDictionaries[0]["DarkButtonStyle"] as Style;
                    break;
                default:
                    break;
            }
        }
    }
}
