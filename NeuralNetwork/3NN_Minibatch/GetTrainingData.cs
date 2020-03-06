using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _3NN_Minibatch
{
    public class GetTrainingData : MatrixData
    {
        public void GetData()
        {
            int trainingdata = 100; //入っているデータの数 100
            int select = 0; //選ばれたデータ
            Random rnd = new Random();
            select = rnd.Next(1, trainingdata);
            OpenFile(select);
            Console.WriteLine($"訓練データ {select}.txt を読み込みました。");
        }

        public void OpenFile(int select)
        {
            string FilePath = $"../../../../JpegToData/data/2/{select}.txt";
            StreamReader streamReader = new StreamReader(FilePath);

            string str = streamReader.ReadToEnd(); //末尾まで読み込む
            string[] tmpdata = str.Split(','); //カンマごとに区切る
            TrainingInputData = new double[1, tmpdata.Length]; //データ数で自動拡張

            for (int i = 0; i < tmpdata.Length; i++)
            {
                TrainingInputData[0, i] = double.Parse(tmpdata[i]);
            }
        }
    }
}
