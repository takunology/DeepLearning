using System;
using System.Collections.Generic;
using System.Text;

namespace _3NN_FO_SM_MSECEE
{
    public class CheckLabel : MatrixData
    {
        static int Answer = 0; // 正解の要素を選択するための変数
        static double[] AnsLabel = new double[0];

        public CheckLabel()
        {
#if DEBUG          

            for(int i = 0; i < OutputMatrix.GetLength(1); i++)
            {
                Answer = i; //一通りの正解ラベルで比較
                AnsLabel = new double[OutputMatrix.GetLength(1)]; //ラベルの要素 -> 正解の要素は1で初期化
                AnsLabel[Answer] = 1; //正解ラベルは確率100% (1)とみなす
                //MSE();
                CEE();
            }

            /*
            Console.WriteLine("\n正解のラベル（要素）を選ぶ");
            Console.Write($"　{0}～{OutputMatrix.GetLength(1)}？ > ");
            Answer = int.Parse(Console.ReadLine());
            AnsLabel = new double[OutputMatrix.GetLength(1)]; //ラベルの要素 -> 正解の要素は1で初期化
            AnsLabel[Answer] = 1; //正解ラベルは確率100% (1)とみなす
            MSE();
            */
#endif

        }

        //二乗和誤差 Mean Squared Error
        public void MSE()
        {
            double sum = 0;
            for (int i = 0; i < OutputMatrix.GetLength(1); i++)
            {
                // (出力値 - ラベル)^2 を sum に加算していく（総和）
                sum += Math.Pow(OutputMatrix[0, i] - AnsLabel[i], 2);
            }
            ErrorValue = sum / 2; //全体を2で割る
            Console.WriteLine($"正解ラベル : {Answer} => 損失度：{ErrorValue}");
        }

        //交差エントロピー誤差 Cross Entropy Error
        public void CEE()
        {
            double sum = 0;
            for(int i = 0; i < OutputMatrix.GetLength(1); i++)
            {
                sum += AnsLabel[i] * Math.Log10(OutputMatrix[0, i]);
            }
            ErrorValue = sum * (-1);
            Console.WriteLine($"正解ラベル : {Answer} => 損失度：{ErrorValue}");
        }
    }
}
