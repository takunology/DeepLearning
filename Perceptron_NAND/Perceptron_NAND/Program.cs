using System;

namespace Perceptron_NAND
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Perceptron NAND Logic.");

                Console.Write("Input x1:");
                var x1 = double.Parse(Console.ReadLine());
                Console.Write("Input x2:");
                var x2 = double.Parse(Console.ReadLine());

                Console.WriteLine($"Output  :{NAND(x1, x2)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static int NAND(double x1, double x2)
        {
            //重みのパラメータ
            var w1 = -1;
            var w2 = -1;
            var threshold = -1.5; // 閾値
            var tmp = (x1 * w1) + (x2 * w2); //積の和

            if (threshold < tmp) { return 1; } // 閾値を超えた場合
            else { return 0; } // 閾値以下の場合
        }
    }
}
