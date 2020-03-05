using System;
using System.Collections.Generic;
using System.Text;

namespace _3NN_FO_SM_MSE
{
    public class CheckLabel : MatrixData
    {
        static int Answer = 0; // 正解の要素を選択するための変数
        static double[] ErrorValue = new double[0];
        static double[] AnsLabel = new double[0];

        public CheckLabel()
        {
#if DEBUG
            Console.WriteLine("\n正解のラベル（要素）を選ぶ");
            Console.Write($"　{0}～{OutputMatrix.GetLength(1)}？ > ");
            Answer = int.Parse(Console.ReadLine());

            ErrorValue = new double[OutputMatrix.GetLength(1)]; //誤差値 -> 出力ニューロンの数だけ用意
            AnsLabel = new double[OutputMatrix.GetLength(1)]; //ラベルの要素 -> 正解の要素は1で初期化
            AnsLabel[Answer] = 1; //正解ラベル（仮）
#endif 
        }

        //二乗和誤差 Mean Squared Error
        public void MSE()
        {
            double sum = 0;
            for(int i = 0; i < OutputMatrix.GetLength(1); i++)
            {
                sum += Math.Pow(OutputMatrix[0, i] - AnsLabel[i], 2);
            }

            for(int i = 0; i < OutputMatrix.GetLength(1); i++)
            {
                ErrorValue[i] = OutputMatrix[0, i] / sum;
            }
        }
    }
}
