using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ZUI.Controls
{
    /// <summary>
    /// 水平进度条
    /// </summary>
    [TemplatePart(Name = "PART_Track", Type = typeof(Rectangle))]
    [TemplatePart(Name = "PART_Indicator", Type = typeof(Grid))]
    [TemplatePart(Name = "PART_StackPanel", Type = typeof(StackPanel))]
    public class FlatProgressBar : ProgressBar
    {
        public enum ControkSkin
        {
            /// <summary>
            /// 条纹样式1
            /// </summary>
            Style1,
            /// <summary>
            /// 条纹样式1
            /// </summary>
            Style2,
            /// <summary>
            /// 条纹样式1
            /// </summary>
            Style3,
            /// <summary>
            /// 不带条纹的样式
            /// </summary>
            NoStripeStyle,
        }
        #region
        public static readonly DependencyProperty SkinProperty = DependencyProperty.Register("Skin"
            , typeof(ControkSkin), typeof(FlatProgressBar));
        /// <summary>
        /// 皮肤
        /// </summary>
        public ControkSkin Skin
        {
            get { return (ControkSkin)GetValue(SkinProperty); }
            set { SetValue(SkinProperty, value); }
        }
        #endregion

        public FlatProgressBar() : base()
        {
            //获取资源文件信息
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("/WpfToolkit.ZUI.Controls;component/Themes/ProgressBarStyle.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(rd);

            if (Skin != ControkSkin.NoStripeStyle)
            {
                this.Style = this.Resources.MergedDictionaries[0]["ProgressBarStyle1"] as Style;
            }

            this.Loaded += FlatProgressBar_Loaded;
        }

        private void FlatProgressBar_Loaded(object sender, RoutedEventArgs e)
        {
            //StackPanel PART_StackPanel = Utils.VisualHelper.FindVisualChild<StackPanel>(this);
            //StartStoryboard(PART_StackPanel);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if(Skin != ControkSkin.NoStripeStyle)
            {
                CreateRectangle();
                Grid grid = Utils.VisualHelper.FindVisualElement<Grid>(this, "PART_Indicator");
                grid.SizeChanged += Grid_SizeChanged;
            }
            else
            {
                this.Style = this.Resources.MergedDictionaries[0]["NoStripeProgressBarStyle"] as Style;
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CreateRectangle();
        }

        /// <summary>
        /// 创建倾斜的Rectangle，即条纹
        /// </summary>
        private void CreateRectangle()
        {
            double PART_Indicator = (this.Value / 100d) * this.Width;
            StackPanel PART_StackPanel = Utils.VisualHelper.FindVisualChild<StackPanel>(this);
            PART_StackPanel.Children.Clear();

            for (int i = 0; i < PART_Indicator / 10 + 5; i++)
            {
                var tempRect = new Rectangle
                {
                    Width = 10,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    RenderTransform = new SkewTransform(30, 0)
                };
                switch (Skin)
                {
                    case ControkSkin.Style1:
                        tempRect.Fill = new SolidColorBrush(i % 2 == 0 ? Color.FromArgb(255, 255, 90, 90) : Color.FromArgb(255, 255, 153, 37));
                        break;
                    case ControkSkin.Style2:
                        tempRect.Fill = new SolidColorBrush(i % 2 == 0 ? Color.FromArgb(255, 131, 167, 207) : Color.FromArgb(255, 147, 179, 214));
                        break;
                    case ControkSkin.Style3:
                        tempRect.Fill = new SolidColorBrush(Color.FromArgb(255, 131, 167, 207));
                        break;
                    default:
                        break;
                }

                PART_StackPanel.Children.Add(tempRect);
            }
        }

        private void StartStoryboard(StackPanel PART_StackPanel)
        {
            Storyboard storyBoard = new Storyboard();

            ThicknessAnimation animation = new ThicknessAnimation();
            animation.From = new Thickness(-30, 0, 0, 0);
            animation.To = new Thickness(-10, 0, 0, 0);
            animation.Duration = new Duration(new TimeSpan(1000));

            storyBoard.Children.Add(animation);
            storyBoard.RepeatBehavior = RepeatBehavior.Forever;
            Storyboard.SetTargetName(animation, PART_StackPanel.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(StackPanel.MarginProperty));

            PART_StackPanel.BeginStoryboard(storyBoard);
        }
    }
}
