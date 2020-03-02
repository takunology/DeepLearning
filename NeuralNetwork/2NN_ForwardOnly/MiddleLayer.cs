using System;
using System.Collections.Generic;
using System.Text;

namespace _2NN_ForwardOnly
{
    class MiddleLayer : MatrixData
    {
        public MiddleLayer(int Neuron)
        {
            Function function = new Function();
            //[i, n] * [n, neuron] の形になるよう列と行を合わせる
            ROW_WEIGHT = COL_IN; //入力行列の列と中間層行列の行が共通
            COL_WEIGHT = Neuron; //中間ニューロンの数が列の数になる

            Weight(ROW_WEIGHT, COL_WEIGHT); //中間層重みパラメータを得る
#if DEBUG
            Console.WriteLine("中間層重み行列");
            ShowWeight(); //重み行列の表示
            Console.WriteLine();
#endif

            MiddleMatrix = new double[ROW_IN, COL_WEIGHT]; //行列の行数と列数を更新
            COL_MIDDLE = COL_WEIGHT;

            for(int i = 0; i < ROW_IN; i++) //入力行列の行数
            {
                for(int j = 0; j < COL_WEIGHT; j++) //重み行列（作用行列）の列数
                {
                    for(int k = 0; k < COL_IN; k++) //共通要素（入力行列の列数 or 作用行列の行数）
                    {
                        //jが共通成分 -> 中間行列 = 入力行列 * 重み行列 
                        MiddleMatrix[i, j] += (InputMatrix[i, k] * WeightMatrix[k, j]);
                    }
                    MiddleMatrix[i, j] = function.Sigmoid(MiddleMatrix[i, j]);
                }
            }
#if DEBUG
            Console.WriteLine("中間層の出力");
            ShowMiddle();
            Console.WriteLine();
#endif
        }

        public void Weight(int row, int col)
        {
            ROW_WEIGHT = row;
            COL_WEIGHT = col;
            WeightMatrix = new double[row, col]; //行列の行数と列数を更新
            Random rnd = new Random();

            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    //重みパラメータを乱数決定 (-1～1)
                    double rndVal = double.Parse(rnd.Next(0, 2000).ToString());
                    rndVal = double.Parse(((rndVal - 1000) / 1000).ToString());
                    WeightMatrix[i, j] = rndVal;
                }
            }
        }

        public void ShowWeight() //重み行列の表示
        {
            for (int i = 0; i < ROW_WEIGHT; i++)
            {
                Console.Write("|");
                for (int j = 0; j < COL_WEIGHT; j++)
                {
                    Console.Write(string.Format("{0, 8} ", WeightMatrix[i, j]));
                }
                Console.WriteLine("|");
            }
        }

        public void ShowMiddle() //中間層の表示
        {
            for (int i = 0; i < ROW_IN; i++) //入力行
            {
                Console.Write("|");
                for (int j = 0; j < COL_WEIGHT; j++) //重み列
                {
                    Console.Write(string.Format("{0,8} ", MiddleMatrix[i, j]));
                }
                Console.WriteLine("|");
            }
        }
    }
}
