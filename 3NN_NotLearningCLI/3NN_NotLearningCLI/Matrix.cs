using System;
using System.Collections.Generic;
using System.Text;

namespace _3NN_NotLearningCLI
{
    public class Matrix
    {
        static int Ax = 0, Ay = 0;
        static int Bx = 0, By = 0;
        double[,] MatrixA = new double[Ax, Ay];
        double[,] MatrixB = new double[Bx, By];
        double[,] MatrixC = new double[Ax, By];

        public void InputMatrixA(int x, int y)
        {
            Ax = x;
            Ay = y;
            MatrixA = new double[Ax, Ay];

            for (int i = 0; i < Ax; i++)
            {
                for(int j = 0; j < Ay; j++)
                {
                    Console.Write($"{i + 1}行{j + 1}列の要素：");
                    MatrixA[i, j] = double.Parse(Console.ReadLine());
                }
            }
        }

        public void InputMatrixB(int x, int y)
        {
            Bx = x;
            By = y;
            MatrixB = new double[Bx, By];
            for (int i = 0; i < Bx; i++)
            {
                for (int j = 0; j < By; j++)
                {
                    Console.Write($"{i + 1}行{j + 1}列の要素：");
                    MatrixB[i, j] = double.Parse(Console.ReadLine());
                }
            }
        }

        public void MatrixCalc()
        {
            MatrixC = new double[Ax, By];
            for (int i = 0; i < Ax; i++)
            {
                for (int j = 0; j < By; j++)
                {
                    for (int k = 0; k < Ay; k++) //共通要素数は k で変数を分けて考える
                    {
                        MatrixC[i, j] += (MatrixA[i, k] * MatrixB[k, j]);
                    }
                }
            }
        }

        public void MatrixCalcShow()
        {
            for (int i = 0; i < Ax; i++)
            {
                Console.Write("|");
                for (int j = 0; j < By; j++)
                {
                    Console.Write(string.Format("{0,4}", MatrixC[i, j]));
                }
                Console.WriteLine(" |");
            }
        }

        public void show()
        {
            Console.WriteLine($"Ax:{Ax} Ay:{Ay} Bx:{Bx} By:{By}");
            Console.WriteLine($"Matrix:{MatrixA[Ax,Ay]}");
        }
    }
}
