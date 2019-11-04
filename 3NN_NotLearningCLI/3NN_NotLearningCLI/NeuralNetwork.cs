using System;
using System.Collections.Generic;
using System.Text;

namespace _3NN_NotLearningCLI
{
    public class NeuralNetwork : Matrix
    {
        int x = 0, y = 0;
        public void InputLayer() //入力層は行列Aだけ作る
        {
            x = 1; //入力行列の固定値
            Console.Write("入力層のニューロンの数：");
            y = int.Parse(Console.ReadLine());

            InputMatrix(x, y); //入力層
            //1行y列の行列
        }

        public void FirstHideLayer() //1層目の隠れ層
        {
            x = y; //共通数
            Console.Write("\n隠れ層（第一層）のニューロンの数：");
            y = int.Parse(Console.ReadLine());
            WeightMatrix(x, y); //重みの行列
            FirstHideCalc(); //第一層目の行列積
        }

        public void SecondHideLayer() //2層以降の隠れ層
        {
            x = y;
            Console.Write("\n隠れ層（第二層）のニューロンの数：");
            y = int.Parse(Console.ReadLine());
            WeightMatrix(x, y); //重みの行列
            SecondHideCalc(); //第二層目の行列積
        }

        public void OutputLayer()
        {
            x = y;
            Console.Write("\n出力層のニューロンの数：");
            y = int.Parse(Console.ReadLine());
            WeightMatrix(x, y); //重みの行列
            OutPut();
        }
    }
}
