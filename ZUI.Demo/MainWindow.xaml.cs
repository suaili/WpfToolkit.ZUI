using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZUI.Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer mTimer;
        public MainWindow()
        {
            InitializeComponent();
            mTimer = new Timer();
            mTimer.Interval = 100;
            mTimer.Elapsed += MTimer_Elapsed;
        }

        private void MTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(()=> {

                this.progressBar.Value += 1;
                if (this.progressBar.Value == this.progressBar.Maximum)
                {
                    mTimer.Enabled = false;
                }
            }));
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.progressBar.Value = 0;
            this.mTimer.Enabled = true;
        }
    }
}
