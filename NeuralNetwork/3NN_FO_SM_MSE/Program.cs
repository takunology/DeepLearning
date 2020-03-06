using System;

namespace _3NN_FO_SM_MSECEE
{
    class Program : MatrixData
    {
        static void Main(string[] args)
        {           
            int Neuron = 10; //ニューロンの数
            int Sample = 5; //サンプル数


            //Console.Write("入力層のニューロン数：");
            //Neuron = int.Parse(Console.ReadLine()); 
            _ = new InputLayer(Sample);//Neuron行1列として初期化

            //Console.Write("\n第1中間層のニューロン数：");
            //Neuron = int.Parse(Console.ReadLine());
            _ = new MiddleLayer(Neuron+5);//Neuron列として初期化

            //Console.Write("\n第2中間層のニューロン数：");
            //Neuron = int.Parse(Console.ReadLine());
            _ = new MiddleLayer(Neuron);//Neuron列として初期化
            
            //Console.Write("\n出力層のニューロン数：");
            //Neuron = int.Parse(Console.ReadLine());
            _ = new OutputLayer(Sample);//Neuron列として初期化

            //二乗和誤差による損失計算
            _ = new CheckLabel();

            Console.ReadKey();
        }
    }
}
