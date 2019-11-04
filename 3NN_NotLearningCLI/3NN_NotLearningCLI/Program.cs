using System;

namespace _3NN_NotLearningCLI
{
    public class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("3 Level NeuralNetwork Forward only.");
            NeuralNetwork nw = new NeuralNetwork();
            nw.InputLayer(); //入力層
            nw.HideLayer(); //隠れ層第一層
            nw.HideLayerNext(); //隠れ層第二層
            
        }
    }
}
