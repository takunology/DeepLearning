using System;

namespace Softmax
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input Element：");
            int element = int.Parse(Console.ReadLine());
            
            double[] val = new double[element];
            double sum = 0;
            double FinelSum = 0;

            for(int i = 0; i < val.GetLength(0); i++)
            {
                val[i] = double.Parse(Console.ReadLine());
                sum += Math.Exp(val[i]);
            }

            //sum = element;

            Console.WriteLine($"sum = {sum}\n");

            for (int i = 0; i < val.GetLength(0); i++)
            {
                Console.WriteLine($"Softmax = {Softmax(sum, val[i])}");
                FinelSum += Softmax(sum, val[i]);
            }
            Console.WriteLine($"\nOutput : {FinelSum}");
        }

        static double Softmax(double sum, double input)
        {
            //sum = 5;
            return Math.Exp(input) / sum;
        }
    }
}
