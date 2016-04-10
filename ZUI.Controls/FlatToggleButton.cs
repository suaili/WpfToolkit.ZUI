using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace ZUI.Controls
{
    public class FlatToggleButton : ToggleButton
    {
        public enum FlatToggleButtonSkin
        {
            ToggleButtonStyle1,
            ToggleButtonWithWordStyle1
        }

        #region 依赖属性
        public static readonly DependencyProperty IsCheckedTextProperty = DependencyProperty.Register("IsCheckedText"
            , typeof(string), typeof(FlatToggleButton), new FrameworkPropertyMetadata("开启"));
        /// <summary>
        /// 选中时的文字
        /// </summary>
        public string IsCheckedText
        {
            get { return (string)GetValue(IsCheckedTextProperty); }
            set { SetValue(IsCheckedTextProperty, value); }
        }

        public static readonly DependencyProperty UnCheckedTextProperty = DependencyProperty.Register("UnCheckedText"
            , typeof(string), typeof(FlatToggleButton), new FrameworkPropertyMetadata("关闭"));
        /// <summary>
        /// 未选中时的文字
        /// </summary>
        public string UnCheckedText
        {
            get { return (string)GetValue(UnCheckedTextProperty); }
            set { SetValue(UnCheckedTextProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedColorProperty = DependencyProperty.Register("IsCheckedColor"
            , typeof(Brush), typeof(FlatToggleButton), new FrameworkPropertyMetadata(default(Brush)));
        /// <summary>
        /// 未选中时的文字
        /// </summary>
        public Brush IsCheckedColor
        {
            get { return (Brush)GetValue(IsCheckedColorProperty); }
            set { SetValue(IsCheckedColorProperty, value); }
        }

        public static readonly DependencyProperty UnCheckedColorProperty = DependencyProperty.Register("UnCheckedColor"
            , typeof(Brush), typeof(FlatToggleButton), new FrameworkPropertyMetadata(default(Brush)));
        /// <summary>
        /// 未选中时的文字
        /// </summary>
        public Brush UnCheckedColor
        {
            get { return (Brush)GetValue(UnCheckedColorProperty); }
            set { SetValue(UnCheckedColorProperty, value); }
        }

        public static readonly DependencyProperty SkinProperty = DependencyProperty.Register("Skin"
            , typeof(FlatToggleButtonSkin), typeof(FlatToggleButton));
        /// <summary>
        /// 按钮皮肤
        /// </summary>
        public FlatToggleButtonSkin Skin
        {
            get { return (FlatToggleButtonSkin)GetValue(SkinProperty); }
            set { SetValue(SkinProperty, value); }
        }
        #endregion

        public FlatToggleButton() : base()
        {
            //获取资源文件信息
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("/WpfToolkit.ZUI.Controls;component/Themes/ToggleButtonStyle.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(rd);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            switch (Skin)
            {
                case FlatToggleButtonSkin.ToggleButtonStyle1:
                    this.Style = this.Resources.MergedDictionaries[0]["ToggleButtonStyle1"] as Style;
                    break;
                case FlatToggleButtonSkin.ToggleButtonWithWordStyle1:
                    this.Style = this.Resources.MergedDictionaries[0]["ToggleButtonWithWordStyle1"] as Style;
                    break;
                default:
                    break;
            }
        }
    }
}
