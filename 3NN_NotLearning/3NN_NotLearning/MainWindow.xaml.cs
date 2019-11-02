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

namespace _3NN_NotLearning //アプリ版
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rand_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            double[] value = new double[16];
            TextBlock[] weight = new TextBlock[] { //重み
                this.Display_1w11,
                this.Display_1w12,
                this.Display_1w21,
                this.Display_1w22,
                this.Display_1w31,
                this.Display_1w32,
                this.Display_2w11,
                this.Display_2w12,
                this.Display_2w13,
                this.Display_2w21,
                this.Display_2w22,
                this.Display_2w23,
                this.Display_3w1,
                this.Display_3w2
            };

            for(int i = 0; i < value.Length; i++)
            {
                value[i] = rnd.Next(0, 20000);
                value[i] = (value[i] - 10000) / 10000;
            }

            for(int i = 0; i < weight.Length; i++)
            {
                weight[i].Text = value[i].ToString();
            }

        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            double[] InputValue = new double[] { double.Parse(this.Display_x1.Text.ToString()), double.Parse(this.Display_x2.Text.ToString()) };
            int InputX = 1, InputY = 2;
            double[,] InputMatrix = new double[InputX, InputY];
            for(int i = 0; i < InputX; i++)
            {
                for(int j = 0; j < InputY; j++)
                {
                    InputMatrix[i, j] = InputValue[j];
                }
            }

            double[] Hide1Value = new double[] //隠れ層1の重み
            {
                double.Parse(this.Display_1w11.Text),
                double.Parse(this.Display_1w12.Text),
                double.Parse(this.Display_1w21.Text),
                double.Parse(this.Display_1w22.Text),
                double.Parse(this.Display_1w31.Text),
                double.Parse(this.Display_1w32.Text)
            };

            int Hide1X = 2, Hide1Y = 3; //隠れ層 1
            double[,] HideMatrix1 = new double[Hide1X,Hide1Y];
            for(int i = 0; i < Hide1X; i++)
            {
                for(int j = 0; j < Hide1Y; j++)
                {
                    HideMatrix1[i, j] = Hide1Value[i];
                }
            }

        }



    }
}
