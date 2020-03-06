using System;

namespace _3NN_Minibatch
{
    class Program : MatrixData
    {
        static void Main(string[] args)
        {           
            int Neuron = 10; //中間層ニューロンの数
            int Output = 10; //出力層（分類）の数
            int BatchSize = 10; //バッチサイズ

            //訓練データ読み込み
            for(int i = 0; i < BatchSize; i++)
            {
                GetTrainingData getTrainingData = new GetTrainingData();
                getTrainingData.GetData(); //入力データを取得

                Console.WriteLine($"{i+1}回目");
                //Console.ReadKey();

                //Console.Write("入力層のニューロン数：");
                //Neuron = int.Parse(Console.ReadLine()); 
                _ = new InputLayer(TrainingInputData.GetLength(1));//Neuron行1列として初期化

                //Console.Write("\n第1中間層のニューロン数：");
                //Neuron = int.Parse(Console.ReadLine());
                _ = new MiddleLayer(Neuron + 5);//Neuron列として初期化

                //Console.Write("\n第2中間層のニューロン数：");
                //Neuron = int.Parse(Console.ReadLine());
                _ = new MiddleLayer(Neuron);//Neuron列として初期化

                //Console.Write("\n出力層のニューロン数：");
                //Neuron = int.Parse(Console.ReadLine());
                _ = new OutputLayer(Output);//Neuron列として初期化

                //二乗和誤差による損失計算
                _ = new CheckLabel();                
            }

            ErrorAverage = ErrorSum / BatchSize;

            Console.WriteLine($"\n誤差合計：{ErrorSum}\n平均誤差：{ErrorAverage}");
            Console.ReadKey();

        }
    }
}
