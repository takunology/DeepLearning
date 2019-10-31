using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2NN_NotLearning
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        bool flag = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Format(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            double[] value = new double[8]; 
            for(int i = 0; i < value.Length; i++)
            {
                value[i] = rnd.Next(0, 4000);
                value[i] = (value[i] - 2000) / 1000;
            }
            Display_x1.Text = value[0].ToString();
            Display_x2.Text = value[1].ToString();
            Display_w11.Text = value[2].ToString();
            Display_w12.Text = value[3].ToString();
            Display_w21.Text = value[4].ToString();
            Display_w22.Text = value[5].ToString();
            Display_w1.Text = value[6].ToString();
            Display_w2.Text = value[7].ToString();

            flag = true;
        }

        private void Button_FormatW(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            double[] value = new double[8];
            for (int i = 0; i < value.Length; i++)
            {
                value[i] = rnd.Next(0, 4000);
                value[i] = (value[i] - 2000) / 1000;
            }
            if(Input_x1.Text == "" || Input_x2.Text == "")
            {
                MessageBox.Show("入力値を入力してください", "エラー" ,MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Display_x1.Text = Input_x1.Text;
            Display_x2.Text = Input_x2.Text;
            Display_w11.Text = value[2].ToString();
            Display_w12.Text = value[3].ToString();
            Display_w21.Text = value[4].ToString();
            Display_w22.Text = value[5].ToString();
            Display_w1.Text = value[6].ToString();
            Display_w2.Text = value[7].ToString();

            flag = true;
        }

        private void Button_Run(object sender, RoutedEventArgs e)
        {
            if(flag == false)
            {
                MessageBox.Show("値がセットされていません", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                Display_S1.Text = Hide1().ToString();
                Display_S2.Text = Hide2().ToString();
                Display_y.Text = Out().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Set(object sender, RoutedEventArgs e)
        {
            Display_S1.Text = "S1";
            Display_S2.Text = "S2";
            Display_y.Text = "y";

            Display_x1.Text = Input_x1.Text; ;
            Display_x2.Text = Input_x2.Text;
            Display_w11.Text = Input_w11.Text;
            Display_w12.Text = Input_w12.Text;
            Display_w21.Text = Input_w21.Text;
            Display_w22.Text = Input_w22.Text;
            Display_w1.Text = Input_w1.Text;
            Display_w2.Text = Input_w2.Text;

            flag = true;
        }

        public double Hide1() //ReLU関数仕様
        {
            //入力値
            var x1 = double.Parse(Display_x1.Text);
            var x2 = double.Parse(Display_x2.Text);
            //重み
            var w11 = double.Parse(Display_w11.Text);
            var w12 = double.Parse(Display_w12.Text);
            var threshold = 0; // 閾値
            var tmp = (x1 * w11) + (x2 * w12); //積の和

            if (threshold < tmp) { return tmp; } // 閾値を超えた場合そのまま出力
            else { return 0; } // 閾値以下の場合は0
        }

        public double Hide2()
        {
            //入力値
            var x1 = double.Parse(Display_x1.Text);
            var x2 = double.Parse(Display_x2.Text);
            //重み
            var w21 = double.Parse(Display_w21.Text);
            var w22 = double.Parse(Display_w22.Text);
            var threshold = 0; // 閾値
            var tmp = (x1 * w21) + (x2 * w22); //積の和

            if (threshold < tmp) { return tmp; } // 閾値を超えた場合そのまま出力
            else { return 0; } // 閾値以下の場合は0
        }

        public double Out() //出力層
        {
            //入力値
            var x1 = double.Parse(Display_S1.Text); //S1の値
            var x2 = double.Parse(Display_S2.Text); //S2の値
            //重み
            var w1 = double.Parse(Display_w1.Text);
            var w2 = double.Parse(Display_w2.Text);
            var threshold = 0; // 閾値
            var tmp = (x1 * w1) + (x2 * w2); //積の和

            if (threshold < tmp) { return tmp; } // 閾値を超えた場合そのまま出力
            else { return 0; } // 閾値以下の場合は0
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
