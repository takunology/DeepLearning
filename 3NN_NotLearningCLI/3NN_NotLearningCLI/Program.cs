using System;

namespace _3NN_NotLearningCLI
{
    public class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("3 Level NeuralNetwork Forward only.");
            
            NeuralNetwork NN = new NeuralNetwork();
            
            NN.InputLayer(); //入力層
            NN.FirstHideLayer(); //隠れ層第一層
            NN.SecondHideLayer(); //隠れ層第二層
            NN.OutputLayer(); //出力層
        }
    }
}
