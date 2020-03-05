using System;
using System.Collections.Generic;
using System.Text;

namespace _3NN_FO_SM_MSE
{
    public class InputLayer : MatrixData
    {
        public InputLayer(int Neuron)
        {
            ROW_IN = 1; //入力層の1行は確定している
            COL_IN = Neuron; 
            InputMatrix = new double[ROW_IN, COL_IN];

            Console.WriteLine("パラメータ入力：");
            for (int i = 0; i < ROW_IN; i++)
            {
                for(int j = 0; j < COL_IN; j++)
                {
                    //入力層への入力
                    //InputMatrix[i, j] = double.Parse(Console.ReadLine());
                    InputMatrix[i, j] = 1*(j+1);
                }
            }
#if DEBUG
            ShowInputLayer();
#endif
        }

        public void ShowInputLayer() //入力データの表示
        {
            for (int i = 0; i < ROW_IN; i++)
            {
                Console.Write("|");
                for (int j = 0; j < COL_IN; j++)
                {
                    Console.Write(string.Format("{0, 4} ", InputMatrix[i, j])); //入力層の出力
                }
                Console.WriteLine("|");
            }
        }
    }
}
