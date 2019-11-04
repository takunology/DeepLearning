using System;
using System.Collections.Generic;
using System.Text;

namespace _3NN_NotLearningCLI
{
    public class Matrix
    {
        static int Ax = 0, Ay = 0;
        static int Bx = 0, By = 0;

        public double[,] MatrixA = new double[Ax, Ay];
        public double[,] MatrixB = new double[Bx, By];
        public double[,] MatrixC = new double[Ax, By];
        public double[,] MatrixD = new double[Ax, Ay];

        bool f = false; //隠れ層行列計算のフラグ
        
        //行列計算（層ごとに更新
        public void InputMatrix(int x, int y)
        {
            Ax = x;
            Ay = y;
            MatrixA = new double[Ax, Ay];
            Random rndX = new Random();
            for (int i = 0; i < Ax; i++)
            {
                for (int j = 0; j < Ay; j++)
                {
                    //MatrixA[i, j] = double.Parse(rndX.Next(0, 3).ToString());
                    Console.Write($"{i + 1}行{j + 1}列の要素：");
                    MatrixA[i, j] = double.Parse(Console.ReadLine());
                }
            }

#if DEBUG
            Console.WriteLine("入力行列");
            for (int i = 0; i < Ax; i++)
            {
                Console.Write("|");
                for (int j = 0; j < Ay; j++)
                {
                    Console.Write(string.Format("{0,4}", MatrixA[i, j]));
                }
                Console.WriteLine(" |");
            }
#endif
        }

        public void WeightMatrix(int x, int y) //重みの行列
        {
            Bx = x;
            By = y;
            MatrixB = new double[Bx, By];
            Random rndY = new Random();
            for (int i = 0; i < Bx; i++)
            {
                for (int j = 0; j < By; j++)
                {
                    MatrixB[i, j] = double.Parse(rndY.Next(0, 4).ToString());
                }
            }
#if DEBUG
            Console.WriteLine("重み行列");
            for (int i = 0; i < Bx; i++)
            {
                Console.Write("|");
                for (int j = 0; j < By; j++)
                {
                    Console.Write(string.Format("{0,4}", MatrixB[i, j]));
                }
                Console.WriteLine(" |");
            }
#endif
        }

        public void FirstMatrixCalc() //第一層の行列計算
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
            f = true; //1層目の計算終了フラグ
#if DEBUG
            Console.WriteLine("\n一層目終了");
            for (int i = 0; i < Ax; i++)
            {
                Console.Write("|");
                for (int j = 0; j < By; j++)
                {
                    Console.Write(string.Format("{0,4}", MatrixC[i, j]));
                }
                Console.WriteLine(" |");
            }
#endif
        }

        public void MatrixCalc() //第二層以降の行列計算
        {
            MatrixD = new double[Ax, By];
            for (int i = 0; i < Ax; i++)
            {
                for (int j = 0; j < By; j++)
                {
                    for (int k = 0; k < Ay; k++) //共通要素数は k で変数を分けて考える
                    {
                        MatrixD[i, j] += (MatrixC[i, k] * MatrixB[k, j]);
                    }
                }
            }
#if DEBUG
            Console.WriteLine("\n二層目終了");
            for (int i = 0; i < Ax; i++)
            {
                Console.Write("|");
                for (int j = 0; j < By; j++)
                {
                    Console.Write(string.Format("{0,4}", MatrixD[i, j]));
                }
                Console.WriteLine(" |");
                Console.Write($"\nAx:{Ax}, Ay:{Ay}, Bx:{Bx}, By:{By}");
            }
#endif
        }

    }
}
