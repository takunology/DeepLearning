using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace JpegToData
{
    class Program
    {
        static string FilePath = "";
        static float[,] JpegData = new float[0, 0];
        static int Width = 0;
        static int Height = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Get Brihtness.");

            int label = 2; //2の手書き数字を変換する
            int num = 100; //手書き数字の枚数

            for(int i = 1; i <= num; i++)
            {
                GetData(label, i);
                WriteToFile(label, i);
                Console.WriteLine($"File {i}.txt Created.");
            }

            Console.WriteLine("Finish.");
#if DEBUG
            /*for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write($"{JpegData[i, j]}"+"\t");
                }
                Console.WriteLine();
            }*/
#endif
        }

        static void GetData(int label, int num)
        {
            
            FilePath = $"../../../training/{label.ToString()}/two{num.ToString()}.jpg";
            Bitmap bitmap = new Bitmap(FilePath);

            Width = bitmap.Width;
            Height = bitmap.Height;

            JpegData = new float[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for(int j = 0; j < Width; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j); //[i, j]の色情報にアクセス
                    JpegData[i, j] = pixel.GetBrightness();
                }
            }
        }

        static void WriteToFile(int label, int num)
        {
            Encoding encode = Encoding.GetEncoding("utf-8");
            FilePath = $"../../../data/{label.ToString()}/{num.ToString()}.txt";
            Directory.CreateDirectory("../../../data/2");

            StreamWriter streamWriter = new StreamWriter(FilePath, false, encode);

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (i == 31 && j == 31)
                    {
                        streamWriter.Write($"{JpegData[i, j]}");
                        break;
                    }
                    streamWriter.Write($"{JpegData[i, j]},");     
                }
            }

            streamWriter.Close();
        }
    }
}
