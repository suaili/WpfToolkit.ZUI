using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ZUI.Controls
{
    public class FlatTextBox : TextBox
    {
        public enum ControlSkin
        {
            TextBoxBaseStyle,
            TitleTextBoxBaseStyle,
        }

        #region 依赖属性

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title"
            , typeof(string), typeof(FlatTextBox));
        /// <summary>
        /// TextBox前面的标签，比如用户信息
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register("Watermark"
            , typeof(string), typeof(FlatTextBox));
        /// <summary>
        /// 文本框内的水印提示
        /// </summary>
        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        //public static readonly DependencyProperty WatermarkForegroundProperty = DependencyProperty.Register("WatermarkForeground"
        //    , typeof(Brush), typeof(FlatTextBox));
        ///// <summary>
        ///// TextBox前面的标签，比如用户信息
        ///// </summary>
        //public Brush WatermarkForeground
        //{
        //    get { return (Brush)GetValue(WatermarkForegroundProperty); }
        //    set { SetValue(WatermarkForegroundProperty, value); }
        //}

        public static readonly DependencyProperty TitleWidthProperty = DependencyProperty.Register("TitleWidth"
            , typeof(double), typeof(FlatTextBox));
        /// <summary>
        /// 按钮皮肤
        /// </summary>
        public double TitleWidth
        {
            get { return (double)GetValue(TitleWidthProperty); }
            set { SetValue(TitleWidthProperty, value); }
        }

        public static readonly DependencyProperty TitleHorizontalAlignmentProperty = DependencyProperty.Register("TitleHorizontalAlignment"
            , typeof(HorizontalAlignment), typeof(FlatTextBox), new FrameworkPropertyMetadata(HorizontalAlignment.Left));
        /// <summary>
        /// 按钮皮肤
        /// </summary>
        public HorizontalAlignment TitleHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(TitleHorizontalAlignmentProperty); }
            set { SetValue(TitleHorizontalAlignmentProperty, value); }
        }

        public static readonly DependencyProperty SkinProperty = DependencyProperty.Register("Skin"
            , typeof(ControlSkin), typeof(FlatTextBox));
        /// <summary>
        /// 按钮皮肤
        /// </summary>
        public ControlSkin Skin
        {
            get { return (ControlSkin)GetValue(SkinProperty); }
            set { SetValue(SkinProperty, value); }
        }

        #endregion

        public FlatTextBox() : base()
        {
            //获取资源文件信息
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("/WpfToolkit.ZUI.Controls;component/Themes/TextBoxStyle.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(rd);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            try
            {
                switch (Skin)
                {
                    case ControlSkin.TextBoxBaseStyle:
                        this.Style = this.Resources.MergedDictionaries[0]["TextBoxStyle1"] as Style;
                        break;
                    case ControlSkin.TitleTextBoxBaseStyle:
                        if(TitleWidth <= 0)
                        {
                            TitleWidth = Title.Length * 10 + 10;
                        }
                        this.Style = this.Resources.MergedDictionaries[0]["TitleTextBoxStyle"] as Style;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
