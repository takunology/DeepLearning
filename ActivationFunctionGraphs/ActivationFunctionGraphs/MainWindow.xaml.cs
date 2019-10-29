using System;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.Integration;

namespace ActivationFunctionGraphs
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        int min = -10; //グラフの最小値
        int max = 10; //グラフの最大値
        double interval = 2; //グラフの感覚

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Step(object sender, RoutedEventArgs e)
        {
            var windowsFormsHost = (WindowsFormsHost)GraphArea.Children[0];
            var graph = (Chart)windowsFormsHost.Child;
            graph.ChartAreas.Clear();

            // ChartArea追加
            graph.ChartAreas.Add("Graph1");
            // Seriesの作成と値の追加
            Series seriesStep = new Series();
            seriesStep.ChartType = SeriesChartType.Line;
            graph.ChartAreas[0].AxisX.Maximum = max; //そのグラフの最小値
            graph.ChartAreas[0].AxisX.Minimum = min; //そのグラフの最大値
            graph.ChartAreas[0].AxisX.Interval = interval; //目盛りの間隔（最大値と最小値の設定が必要）

            int y = 0; //ステップ関数の初期値
            for (double x = min; x <= max; x = x + 0.001)
            {
                if(x > 0)
                {
                    y = 1;  //0を超えたら1を出力
                }
                seriesStep.Points.AddXY(x, y);
                seriesStep.BorderWidth = 3;
            }
            graph.Series.Add(seriesStep);
        }

        private void Button_Sigmoid(object sender, RoutedEventArgs e)
        {
            var windowsFormsHost = (WindowsFormsHost)GraphArea.Children[0];
            var graph = (Chart)windowsFormsHost.Child;
            graph.ChartAreas.Clear();

            // ChartArea追加
            graph.ChartAreas.Add("Graph1");
            // Seriesの作成と値の追加
            Series seriesStep = new Series();
            seriesStep.ChartType = SeriesChartType.Line;
            graph.ChartAreas[0].AxisX.Maximum = max; //そのグラフの最小値
            graph.ChartAreas[0].AxisX.Minimum = min; //そのグラフの最大値
            graph.ChartAreas[0].AxisX.Interval = interval; //目盛りの間隔（最大値と最小値の設定が必要）

            double y = 0; //ステップ関数の初期値
            for (double x = min; x <= max; x = x + 0.001)
            {
                y = 1 / (1 + Math.Exp(-x)); //シグモイド関数
                seriesStep.Points.AddXY(x, y);
                seriesStep.BorderWidth = 3;
            }
            graph.Series.Add(seriesStep);
        }

        private void Button_Relu(object sender, RoutedEventArgs e)
        {
            var windowsFormsHost = (WindowsFormsHost)GraphArea.Children[0];
            var graph = (Chart)windowsFormsHost.Child;
            graph.ChartAreas.Clear();

            // ChartArea追加
            graph.ChartAreas.Add("Graph1");
            // Seriesの作成と値の追加
            Series seriesStep = new Series();
            seriesStep.ChartType = SeriesChartType.Line;
            graph.ChartAreas[0].AxisX.Maximum = max; //そのグラフの最小値
            graph.ChartAreas[0].AxisX.Minimum = min; //そのグラフの最大値
            graph.ChartAreas[0].AxisX.Interval = interval; //目盛りの間隔（最大値と最小値の設定が必要）

            double y = 0; //ステップ関数の初期値
            for (double x = min; x <= max; x = x + 0.001)
            {
                if (x > 0)
                {
                    y = x;  //0を超えたらxを出力
                }
                else
                {
                    y = 0; //0未満は0を出力
                }
                seriesStep.Points.AddXY(x, y);
                seriesStep.BorderWidth = 3;
            }
            graph.Series.Add(seriesStep);
        }
    }
}