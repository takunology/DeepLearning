using System;
using System.Collections.Generic;
using System.Text;

namespace _3NN_FO_SM_MSE
{
    public class OutputLayer : MatrixData
    {
        public OutputLayer(int Neuron)
        {
            Function function = new Function();

            ROW_OUT = COL_MIDDLE; //入力(中間)行列の列と中間層行列の行が共通
            COL_OUT = Neuron; //出力ニューロンの数が列の数になる

            Weight(ROW_OUT, COL_OUT); //出力層重みパラメータを得る
#if DEBUG
            Console.WriteLine("\n----- 出力層重み行列 -----");
            ShowWeight(); //重み行列の表示
#endif

            OutputMatrix = new double[ROW_MIDDLE, COL_WEIGHT]; //行列の行数と列数を更新
            double ExpSum = 0; //ソフトマックス関数で使用する総和
#if DEBUG
            double OutSum = 0; //ソフトマックス関数確認用変数
#endif
            for (int i = 0; i < ROW_MIDDLE; i++) //中間行列の行数
            {
                for (int j = 0; j < COL_WEIGHT; j++) //重み行列（作用行列）の列数
                {
                    for (int k = 0; k < COL_MIDDLE; k++) //共通要素（中間行列の列数 or 作用行列の行数）
                    {
                        //kが共通成分 -> 出力行列 = 中間行列 * 重み行列 
                        OutputMatrix[i, j] += (MiddleMatrix[i, k] * WeightMatrix[k, j]);
                    }
                    ExpSum += Math.Exp(OutputMatrix[i, j]); //指数関数の総和
                }
            }

            for (int i = 0; i < OutputMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < OutputMatrix.GetLength(1); j++)
                {
                    OutputMatrix[i, j] = function.Softmax(OutputMatrix[i, j], ExpSum);
                    OutSum += OutputMatrix[i, j];
                }
            }

#if DEBUG
            Console.WriteLine("\n----- 出力層の出力 -----");
            ShowMiddle();
            Console.WriteLine($"\n出力層の確率合計(DEBUG)：{OutSum}");
            Console.WriteLine();
#endif
        }

        public void Weight(int row, int col)
        {
            ROW_WEIGHT = row;
            COL_WEIGHT = col;
            WeightMatrix = new double[row, col]; //行列の行数と列数を更新
            Random rnd = new Random();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
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

        public void ShowMiddle() //出力層の表示
        {
            for (int i = 0; i < ROW_MIDDLE; i++) //入力行
            {
                Console.Write("|");
                for (int j = 0; j < COL_WEIGHT; j++) //重み列
                {
                    Console.Write(string.Format("{0,8} ", OutputMatrix[i, j]));
                }
                Console.WriteLine("|");
            }
        }
    }
}