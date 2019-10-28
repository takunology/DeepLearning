using System;

namespace Perceptron_OR
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Perceptron OR Logic.");

                Console.Write("Input x1:");
                var x1 = double.Parse(Console.ReadLine());
                Console.Write("Input x2:");
                var x2 = double.Parse(Console.ReadLine());

                Console.WriteLine($"Output  :{OR(x1, x2)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static int OR(double x1, double x2)
        {
            //重みのパラメータ
            var w1 = 2;
            var w2 = 2;
            var threshold = 1; // 閾値
            var b = 1; //バイアス
            var tmp = b + (x1 * w1) + (x2 * w2); //積の和

            if (threshold < tmp) { return 1; } // 閾値を超えた場合
            else { return 0; } // 閾値以下の場合
        }
    }
}
