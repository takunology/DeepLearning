using System;
using System.IO;

namespace ReadData
{
    class Program
    {
        static double[] InputData = new double[0];
        static void Main(string[] args)
        {
            Console.WriteLine("Read from txt.");
            OpenFile();

            foreach(var value in InputData)
            {
                Console.WriteLine($"{value}");
            }
        }

        static void OpenFile()
        {
            string FilePath = "../../../../JpegToData/data/2/20.txt";
            StreamReader streamReader = new StreamReader(FilePath);

            string str = streamReader.ReadToEnd(); //末尾まで読み込む
            string[] tmpdata = str.Split(','); //カンマごとに区切る
            InputData = new double[tmpdata.Length]; //データ数で自動拡張
            
            for(int i = 0; i < tmpdata.Length; i++)
            {
                InputData[i] = double.Parse(tmpdata[i]);
            }

            for(int i = 0; i < tmpdata.Length; i++)
            {
                if (i % 32 == 0)
                {
                    Console.WriteLine();
                }

                if (InputData[i] < 1)
                {
                    Console.Write("■");
                }
                else
                {
                    Console.Write("□");
                }
            }
            streamReader.Close(); //ファイルを閉じる
        }
    }
}
