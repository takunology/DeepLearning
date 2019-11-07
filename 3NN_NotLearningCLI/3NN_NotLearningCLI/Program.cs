using System;
using System.Diagnostics;

namespace _3NN_NotLearningCLI
{
    public class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("3 Level NeuralNetwork Forward only.");
            
            NeuralNetwork NN = new NeuralNetwork();

#if DEBUG
            var sw = new Stopwatch();
#endif            
            NN.InputLayer(); //入力層
            int input = NN.y;
#if DEBUG
            sw.Start();
#endif
            NN.FirstHideLayer(); //隠れ層第一層
            int first = NN.y;
#if DEBUG
            sw.Stop();
            TimeSpan first_ts = sw.Elapsed;
            TimeSpan ts_sum = sw.Elapsed;

            sw.Restart(); //リセット
            sw.Start();
#endif
            NN.SecondHideLayer(); //隠れ層第二層
            int second = NN.y;
#if DEBUG
            sw.Stop();
            TimeSpan second_ts = sw.Elapsed;
            ts_sum += sw.Elapsed;

            sw.Restart();
            sw.Start();
#endif
            NN.OutputLayer(); //出力層
#if DEBUG
            sw.Stop();
            TimeSpan out_ts = sw.Elapsed;
            ts_sum += sw.Elapsed;

            Console.WriteLine("\n-------------- result ----------------");
            Console.WriteLine($"入力層のニューロン数 {input}");
            Console.WriteLine($"第一層のニューロン数 {first}");
            Console.WriteLine($"第二層のニューロン数 {second}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"第一層にかかった時間 {first_ts}");
            Console.WriteLine($"第二層にかかった時間 {second_ts}");
            Console.WriteLine($"出力層にかかった時間 {out_ts}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"合計処理時間 {ts_sum}");
#endif
        }
    }
}
