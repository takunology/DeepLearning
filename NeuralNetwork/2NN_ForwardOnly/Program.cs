using System;

namespace _2NN_ForwardOnly
{
    class Program
    {
        static void Main(string[] args)
        {           
            int Neuron = 3; //ニューロンの数

            Console.Write("入力層のニューロン数：");
            Neuron = int.Parse(Console.ReadLine()); 
            _ = new InputLayer(Neuron);//Neuron行1列として初期化

            Console.Write("\n中間層のニューロン数：");
            Neuron = int.Parse(Console.ReadLine());
            _ = new MiddleLayer(Neuron);//Neuron列として初期化

            Console.Write("\n出力層のニューロン数：");
            Neuron = int.Parse(Console.ReadLine());
            _ = new OutputLayer(Neuron);//Neuron列として初期化

            Console.ReadKey();
        }
    }
}
