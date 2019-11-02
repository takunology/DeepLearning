using System;

namespace _3NN_NotLearningCLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            Console.WriteLine("3 Level NeuralNetwork");

            Input(); //入力層への入力
            //matrix.MatrixCalc();
            //matrix.MatrixCalcShow();
            //matrix.show();
        }

        public static void Input()
        {
            int x, y;
            Matrix matrix = new Matrix();         

            Console.Write("行列Aの行数：");
            x = int.Parse(Console.ReadLine());
            Console.Write("行列Aの列数：");
            y = int.Parse(Console.ReadLine());
            matrix.InputMatrixA(x, y);

            Console.Write("行列Bの行数：");
            x = int.Parse(Console.ReadLine());
            Console.Write("行列Bの列数：");
            y = int.Parse(Console.ReadLine());
            matrix.InputMatrixB(x, y);
        }
    }
}
