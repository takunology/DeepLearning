using System;

namespace MLP_XOR
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("MultiLayer Perceptron XOR Logic.");

                Console.Write("Input x1:");
                var x1 = double.Parse(Console.ReadLine());
                Console.Write("Input x2:");
                var x2 = double.Parse(Console.ReadLine());

                Console.WriteLine($"Output  :{MLP(x1, x2)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static int MLP(double x1, double x2)
        {
            // NAND と OR の AND (MLP)
            return AND(NAND(x1, x2), OR(x1, x2));            
        }

        public static int AND(double x1, double x2)
        {
            //重みのパラメータ
            var w1 = 1;
            var w2 = 1;
            var threshold = 1; // 閾値
            var tmp = (x1 * w1) + (x2 * w2); //積の和

            if (threshold < tmp) { return 1; } // 閾値を超えた場合
            else { return 0; } // 閾値以下の場合
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
